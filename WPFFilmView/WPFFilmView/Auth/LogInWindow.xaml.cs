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
using WPFFilmView.Data;

namespace WPFFilmView.Auth
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }
        public User LoggedUser { get; private set; }
        private void signInBt_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new FilmFlowContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == txtLogin.Text && u.Password == txtPassword.Password);

                if (user != null)
                {
                    LoggedUser = user;
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password :(");
                }
            }
        }
    }
}
