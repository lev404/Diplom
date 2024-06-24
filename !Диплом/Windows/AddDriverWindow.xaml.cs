using _Диплом.Classes;
using _Диплом.db;
using System;
using System.Linq;
using System.Windows;

namespace _Диплом.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDriverWindow.xaml
    /// </summary>
    public partial class AddDriverWindow : Window
    {
        public AddDriverWindow()
        {
            InitializeComponent();
            RoleBox.ItemsSource = AppData.db.Роль.ToList();
        }

        private void AddDriverBtnClick(object sender, RoutedEventArgs e)
        {
            db.Пользователь driver = new db.Пользователь();

            var g = RoleBox.SelectedItem as Роль;
            driver.Роль = g.RoleID;

            driver.Фамилия = SurnameBox.Text;
            driver.Имя = NameBox.Text;
            driver.Отчество = LastNameBox.Text;
            driver.ДатаРождения = Convert.ToDateTime(BirthdayBox.Text);
            driver.Пол = GenderBox.Text;
            driver.СерияПаспорта = Convert.ToInt32(PassportSeias.Text);
            driver.НомерПаспорта = Convert.ToInt32(PassportNumber.Text);
            driver.НомерЛицензии = Convert.ToInt32(LicenseNumber.Text);
            driver.НомерТелефона = Convert.ToInt64(PhoneNumber.Text);
            driver.Логин = Login.Text;
            driver.Пароль = Password.Text;

            AppData.db.Пользователь.Add(driver);
            AppData.db.SaveChanges();
            MessageBox.Show("Пользователь добавлен!");
            SupervisorWindow supervisorWindow = new SupervisorWindow();
            supervisorWindow.Show();
            this.Close();
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить добавление пользователя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SupervisorWindow supervisorWindow = new SupervisorWindow();
                supervisorWindow.Show();
                this.Close();
            }
        }
    }
}
