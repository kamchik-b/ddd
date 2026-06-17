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

namespace WPFFilmView.Auth
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void logInBt_Click(object sender, RoutedEventArgs e)
        {
            var logInWindow = new LogInWindow();
            bool? result = logInWindow.ShowDialog();

            if(result == true) 
            { 
                var mainWindow = new MainWindow(logInWindow.LoggedUser);
                mainWindow.Show();
                this.Close();
            }
        }

        private void signUpBt_Click(object sender, RoutedEventArgs e)
        {
            var singUpWindow = new SingUpWindow();
            bool? result = singUpWindow.ShowDialog();

            if(result == true)
            {
                var mainWindow = new MainWindow(singUpWindow.CreatedUser);
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
