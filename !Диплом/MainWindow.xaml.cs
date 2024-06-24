using _Диплом.Classes;
using System;
using System.Linq;
using System.Windows;

namespace _Диплом
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            string login = UserIDBox.Text;
            string password = UserPasswordBox.Password;
            var sign = AppData.db.Пользователь.FirstOrDefault(u => u.Логин == login && u.Пароль == password);

            if (String.IsNullOrEmpty(login) && String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите данные для входа!");
                return;
            }

            else if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            else if (String.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (sign != null)
            {
                if (sign.Роль == 1)
                {
                    _Диплом.Windows.DriverWindow driverWindow = new Windows.DriverWindow();
                    driverWindow.Show();
                    this.Close();
                }
                else if (sign.Роль == 2)
                {
                    _Диплом.Windows.SupervisorWindow supervisorWindow = new Windows.SupervisorWindow();
                    supervisorWindow.Show();
                    this.Close();
                }

                MessageBox.Show("Добро пожаловать, " + sign.Имя + "!", "Успешно!");
                return;
            }

            else
            {
                MessageBox.Show("Данный пользователь не найден в системе!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
