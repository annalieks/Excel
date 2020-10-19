using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Excel
{
    class Cell
    {
        private int cellValue;
        public bool Empty { get; set; }
        public int Value {
            get
            {
                return cellValue;
            }
            set
            {
                Empty = false;
                cellValue = value;
                parent[Position.Column, Position.Row].Value = value;
            }
        }
        public string Expression { get; set; }
        public Position Position { get; private set; }
        private DataGridView parent;
        public List<Cell> Dependencies { get; private set; }
        public Cell(DataGridView parent, int row, int column)
        {
            Empty = true;
            this.parent = parent;
            Position = new Position(row, column);
            Dependencies = new List<Cell>();
        }
        public void AddDependency(Cell cell)
        {
            Dependencies.Add(cell);
        }

        public void DeleteDependency(Position position)
        {
            Dependencies = Dependencies.Where(cell =>
                cell.Position.Row != position.Row
                && cell.Position.Column != position.Column).ToList();
        }
        private bool CheckDependencyLoop(List<Cell> cells)
        {
            if (!cells.Any())
            {
                return false;
            }
            foreach (var cell in cells)
            {
                if (cell.Position.Row == Position.Row
                    && cell.Position.Column == Position.Column
                    || CheckDependencyLoop(cell.Dependencies))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckLoop(Cell refCell)
        {
            if (refCell.Position.Row == Position.Row
               && refCell.Position.Column == Position.Column)
                return true;
            return CheckDependencyLoop(refCell.Dependencies);
        }

        public void Calculate(string expression)
        {
            Value = Calculator.Evaluate(expression);
        }
    }
}
