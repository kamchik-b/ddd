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
    /// Interaction logic for SingUpWindow.xaml
    /// </summary>
    public partial class SingUpWindow : Window
    {
        public SingUpWindow()
        {
            InitializeComponent();
        }
        public User CreatedUser { get; private set; }
        private void signUpBt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Login and password cannot be empty!");
                return;
            }
            using (var db = new FilmFlowContext())
            {
                bool exists = db.Users.Any(u => u.Login == txtLogin.Text);
                if(exists)
                {
                    MessageBox.Show("This login is already taken!");
                    return;
                }
                var user = new User
                {
                    Login = txtLogin.Text,
                    Password = txtPassword.Password,
                    AvatarPath = avatar_path
                };
                
                db.Users.Add(user);
                db.SaveChanges();

                CreatedUser = user;
                this.DialogResult = true;
                this.Close();
            }
        }
        private string avatar_path;
        private void chooseImageBt_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                avatar_path = dlg.FileName;
                avatarImg.Source = new BitmapImage(new Uri(avatar_path));
            }
        }
    }
}
