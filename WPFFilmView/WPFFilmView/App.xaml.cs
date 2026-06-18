using System.Configuration;
using System.Data;
using System.Windows;
using WPFFilmView.Auth;
using WPFFilmView.Data;

namespace WPFFilmView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using(var db = new FilmFlowContext())
            {
                db.Database.EnsureCreated();
            }
            base.OnStartup(e);

            new RegisterWindow().Show();
        }
    }

}
