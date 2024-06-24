using _Диплом.Classes;
using Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace _Диплом.Windows
{
    /// <summary>
    /// Логика взаимодействия для DriverWindow.xaml
    /// </summary>
    public partial class DriverWindow : System.Windows.Window
    {
        public DriverWindow()
        {
            InitializeComponent();
        }



        private void PageLoaded(object sender, RoutedEventArgs e) => DataListGrid.ItemsSource = AppData.db.ПутевойЛист.ToList();

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void toExcelBtnClick(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; 
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DataListGrid.Columns.Count; j++) 
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; 
                sheet1.Columns[j + 1].ColumnWidth = 15; 
                myRange.Value2 = DataListGrid.Columns[j].Header;
            }
            for (int i = 0; i < DataListGrid.Columns.Count; i++)
            { 
                for (int j = 0; j < DataListGrid.Items.Count; j++)
                {
                    TextBlock b = DataListGrid.Columns[i].GetCellContent(DataListGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
    }
}
