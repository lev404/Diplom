using _Диплом.Classes;
using _Диплом.db;
using System;
using System.Linq;
using System.Windows;

namespace _Диплом.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTreailerWindow.xaml
    /// </summary>
    public partial class AddTreailerWindow : Window
    {
        public AddTreailerWindow()
        {
            InitializeComponent();

            TrailerType.ItemsSource = AppData.db.ТипПрицепа.ToList();
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить добавление?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SupervisorWindow supervisorWindow = new SupervisorWindow();
                supervisorWindow.Show();
                this.Close();
            }
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            db.Прицеп trailer = new db.Прицеп();

            var t = TrailerType.SelectedItem as ТипПрицепа;
            trailer.ТипПрицепа = t.TrailerTypeID;

            trailer.Марка = Brand.Text;
            trailer.ГаражныйНомер = Convert.ToInt32(GarageNum.Text);
            trailer.РегистрационныйНомер = RegPlate.Text;

            AppData.db.Прицеп.Add(trailer);
            AppData.db.SaveChanges();
            MessageBox.Show("Прицеп добавлен");

            SupervisorWindow supervisorWindow = new SupervisorWindow();
            supervisorWindow.Show();
            this.Close();
        }
    }
}
