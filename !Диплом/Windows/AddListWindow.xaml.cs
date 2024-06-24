using _Диплом.Classes;
using _Диплом.db;
using System;
using System.Linq;
using System.Windows;

namespace _Диплом.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddListWindow.xaml
    /// </summary>
    public partial class AddListWindow : Window
    {
        public AddListWindow()
        {
            InitializeComponent();

            UserComboBox.ItemsSource = AppData.db.Пользователь.ToList();
            CarComboBox.ItemsSource = AppData.db.Автомобиль.ToList();
            TrailerComboBox.ItemsSource = AppData.db.Прицеп.ToList();
            ZakazchikComboBox.ItemsSource = AppData.db.Заказчик.ToList();
            ProductComboBox.ItemsSource = AppData.db.Продукт.ToList();
            ListTypeComboBox.ItemsSource = AppData.db.ТипПутевогоЛиста.ToList();

        }

        private void AddListBtnClick(object sender, RoutedEventArgs e)
        {
            db.ПутевойЛист list = new db.ПутевойЛист();

            var c = CarComboBox.SelectedItem as Автомобиль;
            list.CarID = c.CarID;

            var v = UserComboBox.SelectedItem as Пользователь;
            list.UserID = v.UserID;

            var t = TrailerComboBox.SelectedItem as Прицеп;
            list.TrailerID = t.TrailerID;

            var z = ZakazchikComboBox.SelectedItem as Заказчик;
            list.ZakazchikID = z.ZakazchikID;

            var p = ProductComboBox.SelectedItem as Продукт;
            list.ProductID = p.ProductID;

            var lt = ListTypeComboBox.SelectedItem as ТипПутевогоЛиста;
            list.ТипПутевогоЛиста = lt.ListTypeID;

            list.ВыездИзГаражаПоГрафику = Convert.ToDateTime(GarageExitTimePlaned.Text);
            list.ВыездИзГаражаФактический = Convert.ToDateTime(GarageExitTimeFacted.Text);
            list.НулевойПробегДоВыезда = Convert.ToInt32(ZeroMillage.Text);
            list.ПоказаниеСпидометраДоВыезда = Convert.ToInt32(SpeedometrMIllage.Text);
            list.ВыданоГорючего = Convert.ToInt32(FuelAdded.Text);
            list.ОстатокГорючегоПриВыезде = Convert.ToInt32(FuelLeft.Text);
            list.АдресПунктаПогрузки = LoadingAdress.Text;
            list.АдресПунктаРазгрузки = UnloadingAdress.Text;
            list.Расстояние = Convert.ToInt32(Distance.Text);

            AppData.db.ПутевойЛист.Add(list);
            AppData.db.SaveChanges();
            MessageBox.Show("Путевой лист добавлен!");
            SupervisorWindow supervisorWindow = new SupervisorWindow();
            supervisorWindow.Show();
            this.Close();


        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SupervisorWindow supervisorWindow = new SupervisorWindow();
                supervisorWindow.Show();
                this.Close();
            }
        }
    }
}
