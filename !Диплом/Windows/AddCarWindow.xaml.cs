using _Диплом.Classes;
using _Диплом.db;
using System.Linq;
using System.Windows;

namespace _Диплом.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
            CarTypeBox.ItemsSource = AppData.db.ТипАвтомобиля.ToList();
            FuelType.ItemsSource = AppData.db.ТипТоплива.ToList();


        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            db.Автомобиль car = new db.Автомобиль();

            var ct = CarTypeBox.SelectedItem as ТипАвтомобиля;
            car.ТипАвтомобиля = ct.CarTypeID;

            var f = FuelType.SelectedItem as ТипТоплива;
            car.ТипТоплива = f.FuelTypeID;

            car.Марка = BrandBox.Text;
            car.РегистрационныйНомер = RegPlateBox.Text;


            AppData.db.Автомобиль.Add(car);
            AppData.db.SaveChanges();
            MessageBox.Show("Авотмобиль добавлен");
            SupervisorWindow supervisorWindow = new SupervisorWindow();
            supervisorWindow.Show();
            this.Close();

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
    }
}
