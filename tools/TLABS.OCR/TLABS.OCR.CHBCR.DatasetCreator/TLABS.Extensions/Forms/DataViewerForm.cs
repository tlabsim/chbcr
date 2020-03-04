using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TLABS.Extensions;
using Excel = Microsoft.Office.Interop.Excel;

namespace TLABS
{
    public partial class DataViewerForm : Form
    {
        DataTable _Data;
        public DataTable Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                if (_Data != null)
                {
                    labNoData.Visible = false;
                    dgv.Visible = true;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = _Data;
                    dgv.DataSource = bs;
                }
                else
                {
                    labNoData.Visible = true;
                    dgv.Visible = false;
                }
            }
        }

        public DataViewerForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Data != null)
            {
                ExportToExcel();
            }
        }

        void ExportToExcel()
        {
            try
            {
                string ExcelFileName = string.Empty;
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Title = "Save data to excel file";
                SFD.DefaultExt = ".xlsx";
                SFD.AddExtension = true;
                SFD.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls";
                SFD.FilterIndex = 1;
                SFD.RestoreDirectory = true;

                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    ExcelFileName = SFD.FileName;

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.Sheets["Sheet1"] as Excel.Worksheet;
                    var columns = _Data.Columns.Count;
                    var rows = _Data.Rows.Count + 1;

                    Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];

                    object[,] data = new object[rows, columns];

                    for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                    {
                        data[0, columnNumber] = _Data.Columns[columnNumber].ColumnName.Replace('_', ' ').ToTitleCase();
                    }

                    for (int rowNumber = 1; rowNumber < rows; rowNumber++)
                    {
                        for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                        {
                            data[rowNumber, columnNumber] = _Data.Rows[rowNumber - 1][columnNumber].ToString();
                        }
                    }
                    range.Value = data;                    
                    workbook.SaveAs(ExcelFileName);
                    workbook.Close();
                    Marshal.ReleaseComObject(application);
                    MessageBox.Show("Data successfully exported to " + ExcelFileName, "Export complete");
                }
            }
            catch (Exception ex)
            {
                ex.ShowFullMessage();
            }

        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

       
    }
}
