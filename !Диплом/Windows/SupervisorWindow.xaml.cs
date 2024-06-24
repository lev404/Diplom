using _Диплом.Classes;
using _Диплом.db;
using Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;


namespace _Диплом.Windows
{

    public partial class SupervisorWindow : System.Windows.Window
    {
        public SupervisorWindow()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DataListGrid.ItemsSource = AppData.db.ПутевойЛист.ToList();
            DataUserGrid.ItemsSource = AppData.db.Пользователь.ToList();
            DataCarGrid.ItemsSource = AppData.db.Автомобиль.ToList();
            DataTrailerGrid.ItemsSource = AppData.db.Прицеп.ToList();

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

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void AddListBtnClick(object sender, RoutedEventArgs e)
        {
            AddListWindow addListWindow = new AddListWindow();
            addListWindow.Show();
            this.Close();
        }

        private void EditListBtnClick(object sender, RoutedEventArgs e)
        {
            DataListGrid.IsReadOnly = false;
            DataListGrid.BeginEdit();
        }

        private void AddUserBtnClick(object sender, RoutedEventArgs e)
        {
            AddDriverWindow addDriverWindow = new AddDriverWindow();
            addDriverWindow.Show();
            this.Close();
        }

        private void EditUserBtnClick(object sender, RoutedEventArgs e)
        {
            DataUserGrid.IsReadOnly = false;
            DataUserGrid.BeginEdit();
        }

        private void AddCarBtnClick(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.Show();
            this.Close();
        }

        private void EditCarBtnClick(object sender, RoutedEventArgs e)
        {
            DataCarGrid.IsReadOnly = false;
            DataCarGrid.BeginEdit();
        }

        private void AddTrailerBtnClick(object sender, RoutedEventArgs e)
        {
            AddTreailerWindow addTreailerWindow = new AddTreailerWindow();
            addTreailerWindow.Show();
            this.Close();
        }

        private void EditTrailerBtnClick(object sender, RoutedEventArgs e)
        {
            DataTrailerGrid.IsReadOnly = false;
            DataTrailerGrid.BeginEdit();
        }

        private void SaveListBtnClick(object sender, RoutedEventArgs e)
        {
            AppData.db.SaveChanges();
            DataListGrid.IsReadOnly = true;
            DataListGrid.UpdateLayout();
            MessageBox.Show("Изменения успешно сохранены!");
        }

        private void DeleteListBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данныую строку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var list = DataListGrid.SelectedItem as ПутевойЛист;
                AppData.db.ПутевойЛист.Remove(list);
                AppData.db.SaveChanges();

                DataListGrid.ItemsSource = AppData.db.ПутевойЛист.ToList();
                MessageBox.Show("Строка успешно удалена!");
            }
        }

        private void SaveUserBtnClick(object sender, RoutedEventArgs e)
        {
            AppData.db.SaveChanges();
            DataUserGrid.IsReadOnly = true;
            DataUserGrid.UpdateLayout();
            MessageBox.Show("Изменения успешно сохранены!");
        }

        private void DeleteUserBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данныую строку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var user = DataUserGrid.SelectedItem as Пользователь;
                AppData.db.Пользователь.Remove(user);
                AppData.db.SaveChanges();

                DataUserGrid.ItemsSource = AppData.db.Пользователь.ToList();
                MessageBox.Show("Строка успешно удалена!");
            }
        }

        private void SaveCarBtnClick(object sender, RoutedEventArgs e)
        {
            AppData.db.SaveChanges();
            DataCarGrid.IsReadOnly = true;
            DataCarGrid.UpdateLayout();
            MessageBox.Show("Изменения успешно сохранены!");
        }

        private void DeleteCarBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данныую строку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var car = DataCarGrid.SelectedItem as Автомобиль;
                AppData.db.Автомобиль.Remove(car);
                AppData.db.SaveChanges();

                DataCarGrid.ItemsSource = AppData.db.Автомобиль.ToList();
                MessageBox.Show("Строка успешно удалена!");
            }
        }

        private void SaveTrailerBtnClick(object sender, RoutedEventArgs e)
        {
            AppData.db.SaveChanges();
            DataTrailerGrid.IsReadOnly = true;
            DataTrailerGrid.UpdateLayout();
            MessageBox.Show("Изменения успешно сохранены!");
        }

        private void DeletreTrailerBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данныую строку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var trailer = DataTrailerGrid.SelectedItem as Прицеп;
                AppData.db.Прицеп.Remove(trailer);
                AppData.db.SaveChanges();

                DataTrailerGrid.ItemsSource = AppData.db.Прицеп.ToList();
                MessageBox.Show("Строка успешно удалена!");
            }
        }
    }
}
