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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechoLand.Windows;

namespace TechoLand
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AvtorizationWindow : Window
    {
        TechnoDBContext db = new TechnoDBContext();
        List<User> users;
        public AvtorizationWindow()
        {
            InitializeComponent();
            users = db.Users.ToList();
        }

        private void Message(string message)
        {
            MessageBox.Show(message);
        }
        private void AvtorizationUser_Click(object sender, RoutedEventArgs e)
        {
            bool verefication = false;
            int role = 0;
            string name = "";
            int userid = 0;
            List<User> rightuser = users.Where(u => u.Login.Contains(Login.Text) && u.Password.Contains(Password.Password)).ToList();
            if (string.IsNullOrWhiteSpace(Login.Text) == false)
            {
                if (string.IsNullOrWhiteSpace(Password.Password) == false)
                {
                    if (rightuser.Count > 0)
                    {
                        if (Login.Text == rightuser[0].Login && Password.Password == rightuser[0].Password)
                        {
                            role = rightuser[0].RoleId;
                            name = rightuser[0].Name + " " + rightuser[0].Surname;
                            userid = rightuser[0].Id;
                            verefication = true;
                            Login.Text = "";
                            Password.Password = "";
                        }
                    }
                }
                else
                {
                    Message("Пустой пароль");
                }
            }
            else if (string.IsNullOrWhiteSpace(Password.Password) == false)
            {
                Message("Пустой логин");
            }
            else
            {
                Message("Пустой логин и пароль");
            }
            if (verefication)
            {
                Production production = new Production(role, userid, name, this);
                production.Show();
                this.Hide();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Login.Text) == false)
                {
                    if (string.IsNullOrWhiteSpace(Password.Password) == false)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }

    }
}
