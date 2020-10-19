using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Excel
{
    public class Table
    {
        private int rows = 20;
        private int columns = 10;
        private DataGridView tableContainer;
        private List<List<Cell>> data = new List<List<Cell>>();

        public Table(DataGridView tableContainer)
        {
            SetTable(tableContainer);
        }

        public void SetTable(DataGridView tableContainer)
        {
            tableContainer.RowHeadersVisible = true;
            tableContainer.ColumnCount = columns;
            tableContainer.ColumnHeadersVisible = true;

            for (int i = 0; i < columns; i++)
            {
                tableContainer.Columns[i].Name = Utils.ConvertToColumnFromNumber(i);
                tableContainer.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < rows; i++)
            {
                tableContainer.Rows.Add("");
                tableContainer.Rows[i].HeaderCell.Value = i.ToString();
            }

            tableContainer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            tableContainer.RowHeadersDefaultCellStyle.Padding = new Padding(1);
            tableContainer.AllowUserToAddRows = false;

            this.tableContainer = tableContainer;

            InitializeData();
        }

        private void InitializeData()
        {
            for (int i = 0; i < rows; i++)
            {
                var row = new List<Cell>();
                for (int j = 0; j < columns; j++)
                {
                    row.Add(new Cell(tableContainer, i, j));
                }
                data.Add(row);
            }
        }

        public Cell GetCell(int row, int column)
        {
            if(row >= rows || column >= columns)
            {
                return null;
            }
            return data[row][column];
        }

        public void SetCellExpression(int row, int column, string expression)
        {
            var cell = GetCell(row, column);
            var refs = ExtractRefs(expression);
            DeleteDependencies(cell, refs);
            foreach(var reference in refs)
            {
                var c = GetCell(reference.Row, reference.Column);
                if (c == null)
                    throw new ArgumentException(Constants.NullCellWarning);
                if (c.CheckLoop(cell))
                    throw new ArgumentException(Constants.Loop);

                c.AddDependency(cell);
            }
            cell.Expression = expression;
            cell.Calculate(ReplaceRefs(expression));
            if (expression == "")
                tableContainer[cell.Position.Column, cell.Position.Row].Value = "";

            RefreshDependencies(cell);
        }

        public void RefreshDependencies(Cell cell)
        {
            if (!cell.Dependencies.Any()) return;
            foreach(var dependency in cell.Dependencies)
            {
                dependency.Calculate(ReplaceRefs(dependency.Expression));
                RefreshDependencies(dependency);
            }
        }

        public void DeleteDependencies(Cell cell, List<Position> newRefs)
        {
            var oldRefs = ExtractRefs(cell.Expression);
            var diffs = oldRefs.Except(newRefs).ToList();
            foreach(var diff in diffs)
            {
                data[diff.Row][diff.Column].DeleteDependency(cell.Position);
            }
        }

        public List<Position> ExtractRefs(string expression)
        {
            var result = new List<Position>();
            if (expression == null)
                return result;

            string pattern = @"[A-Z]+[0-9]+";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (Match match in regex.Matches(expression))
            {
                result.Add(new Position(match.Value));
            }
            return result;
        }

        public string ReplaceRefs(string expression)
        {
            string pattern = @"[A-Z]+[0-9]+";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matchEvaluator = new MatchEvaluator(ConvertReference);
            return regex.Replace(expression, matchEvaluator);
        }

        public string ConvertReference(Match match)
        {
            var position = new Position(match.Value);
            var cell = GetCell(position.Row, position.Column);
            return cell.Value.ToString();
        }

        public void Export(StreamWriter streamWriter)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    streamWriter.Write(data[i][j].Empty
                        ? "e"
                        : data[i][j].Expression);
                    if(j == columns - 1 && i != rows - 1)
                    {
                        streamWriter.Write("\n");
                    } else if(j != columns - 1 || i != rows - 1)
                    {
                        streamWriter.Write(" ");
                    }
                }
            }
        }

        public void Clear()
        {
            tableContainer.Rows.Clear();
            tableContainer.Columns.Clear();
            tableContainer.Refresh();
            rows = 0;
            columns = 0;
            data = new List<List<Cell>>();
        }

        public void Import(StreamReader streamReader)
        {
            Clear();
            var tableData = streamReader.ReadToEnd().Split(Environment.NewLine.ToCharArray());
            rows = tableData.Length;
            columns = tableData[0].Split(' ').Length;
            SetTable(tableContainer);
            for(int i = 0; i < rows; i++)
            {
                var cellsRow = new List<Cell>();
                string[] line = tableData[i].Split(' ');
                columns = line.Length;

                for(int j = 0; j < columns; j++)
                {
                    var cell = new Cell(tableContainer, i, j);
                    if(line[j] != "e")
                    {
                        cell.Expression = line[j];
                    }
                        
                    cellsRow.Add(cell);
                }
                foreach(var row in data)
                {
                    foreach(var cell in row)
                    {
                        if (cell.Expression != null)
                        {
                            string expression = ReplaceRefs(cell.Expression);
                            cell.Calculate(expression);
                        }
                    }
                }


                data[i] = (cellsRow);
            }
        }

        public void AddRow()
        {
            var row = new List<Cell>();
            rows++;
            for (int j = 0; j < columns; j++)
            {
                row.Add(new Cell(tableContainer, rows - 1, j));
            }
            data.Add(row);
            tableContainer.Rows.Add();
            tableContainer.Rows[rows - 1].HeaderCell.Value = (rows - 1).ToString();
        }

        public void DeleteRow()
        {
            int index = rows - 1;
            foreach(var cell in data[index])
            {
                if (cell.Dependencies.Any() && 
                    cell.Dependencies.Find(c => c.Position.Row != index) != null)
                {
                    MessageBox.Show(Constants.DeleteDependenciesMsg);
                    return;
                }
            }
            data.RemoveAt(index);
            tableContainer.Rows.RemoveAt(index);
            rows--;
        }

        public void AddColumn()
        {
            columns++;
            tableContainer.ColumnCount = columns;
            tableContainer.Columns[columns - 1].Name =
                Utils.ConvertToColumnFromNumber(columns - 1);
            tableContainer.Columns[columns - 1].SortMode =
                DataGridViewColumnSortMode.NotSortable;

            for (int i = 0; i < rows; i++)
            {
                data[i].Add(new Cell(tableContainer, i, columns - 1));
            }
        }

        public void DeleteColumn()
        {
            int index = columns - 1;
            foreach (var row in data)
            {
                if (row[index].Dependencies.Any() &&
                    row[index].Dependencies.Find(c => c.Position.Row != index) != null)
                {
                    MessageBox.Show(Constants.DeleteDependenciesMsg);
                    return;
                }
            }
            foreach (var row in data)
            {
                row.RemoveAt(index);
            }
            columns--;
            tableContainer.ColumnCount = columns;
        }
    }
}
