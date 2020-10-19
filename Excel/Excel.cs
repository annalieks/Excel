using System;
using System.IO;
using System.Windows.Forms;

namespace Excel
{
    public partial class Excel : Form
    {
        private Table table;

        public Excel()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            table = new Table(tableContainer); 
        }

        private void helpItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Constants.HelpMsg);
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            ProcessOpenFileClick();
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            ProcessSaveFileClick();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            ProcessEnterClick();
        }
        private void addRowBtn_Click(object sender, EventArgs e)
        {
            ProcessAddRowClick();
        }
        private void deleteRowBtn_Click(object sender, EventArgs e)
        {
            ProcessDeleteRowClick();
        }

        private void addColumnBtn_Click(object sender, EventArgs e)
        {
            ProcessAddColumnClick();
        }
        private void deleteColumnBtn_Click(object sender, EventArgs e)
        {
            ProcessDeleteColumnClick();
        }

        private void tableContainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProcessCellClick();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCancel(e);
        }

        private static void CloseCancel(FormClosingEventArgs e)
        {
            const string message = Constants.ConfirmExitMsg;
            const string caption = Constants.ConfirmExitHeader;
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }    


        private void Excel_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ProcessEnterClick()
        {
            if (tableContainer.CurrentCell == null) return;

            int row = tableContainer.CurrentCell.RowIndex;
            int column = tableContainer.CurrentCell.ColumnIndex;
            var expression = textBox.Text;

            try
            {
                table.SetCellExpression(row, column, expression);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.Length > 0
                    ? exception.Message
                    : Constants.IncorrectExprMsg);
                return;
            }
            textBox.Clear();
        }

        private void ProcessCellClick()
        {
            int row = tableContainer.CurrentCell.RowIndex;
            int column = tableContainer.CurrentCell.ColumnIndex;

            var cell = table.GetCell(row, column);
            if (cell == null) return;

            textBox.Text = cell.Expression;
            textBox.Focus();
        }

        private void ProcessSaveFileClick()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ExcelFile|*.xyz";
            saveFileDialog.Title = "Save table";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                var fstream = (FileStream)saveFileDialog.OpenFile();
                var streamWriter = new StreamWriter(fstream);
                table.Export(streamWriter);
                streamWriter.Close();
                fstream.Close();
            }
        }

        private void ProcessOpenFileClick()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ExcelTable|*.xyz";
            openFileDialog.Title = "Оберіть файл для імпорту";
            if (openFileDialog.ShowDialog() != DialogResult.OK) 
                return;

            const string message = Constants.ConfirmImportMsg;
            const string caption = Constants.ConfirmImportHeader;
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.OKCancel,
                             MessageBoxIcon.Question);

            if (result == DialogResult.Cancel) return;

            var streamReader = new StreamReader(openFileDialog.FileName);
            table.Import(streamReader);
            streamReader.Close();
        }

        private void ProcessAddRowClick()
        {
            table.AddRow();
        }
        private void ProcessAddColumnClick()
        {
            table.AddColumn();
        }

        private void ProcessDeleteRowClick()
        {
            table.DeleteRow();
        }

        private void ProcessDeleteColumnClick()
        {
            table.DeleteColumn();
        }

    }
}
