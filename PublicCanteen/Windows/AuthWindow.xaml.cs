using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using PublicCanteen.Windows;
using PublicCanteen.DB;
using PublicCanteen.Classes;

namespace PublicCanteen.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnligin_Click(object sender, RoutedEventArgs e)
        {

           var userAuth = EFClass.entities.Employee.ToList().Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Text).FirstOrDefault();

            if (userAuth != null)
            {
                UserDataClass.userAuth = userAuth;

                ListOfDishesWindow listOfDishesWindow = new ListOfDishesWindow(UserDataClass.userAuth);
                listOfDishesWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Пользователь не найден, повторите попытку входа");
            }
         
        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "Введите логин")
            {
                txtLogin.Clear();
                txtLogin.Foreground = new SolidColorBrush(Colors.Black);
            }
            
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "Введите пароль")
            {
                txtPassword.Clear();
                txtPassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text == "")
            {
                txtLogin.Foreground = new SolidColorBrush(Colors.Gray);
                txtLogin.Text = "Введите логин";
            }

        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Foreground = new SolidColorBrush(Colors.Gray);
                txtPassword.Text = "Введите пароль";
            }
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
