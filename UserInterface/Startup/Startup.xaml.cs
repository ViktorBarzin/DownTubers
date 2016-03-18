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

namespace UserInterface.Startup
{
    using Interfaces;

    using ViewModel;

    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Window
    {
        readonly ILogInViewModel logInViewModel = new LogInViewModel();

        public Startup()
        {
            this.InitializeComponent();
            ResourceDictionary darkTheme = new ResourceDictionary();
            darkTheme.Source = new Uri("/Themes/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary brightTheme = new ResourceDictionary();
            brightTheme.Source = new Uri("/Themes/BrightTheme.xaml", UriKind.Relative);
            View.Themes = new List<ResourceDictionary>();
            View.Themes.Add(darkTheme);
            View.Themes.Add(brightTheme);
            View.UpdateTheme();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var current = this;
            Register register = new Register();
            current.Close();
            register.Show();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            int[] userInfo = this.logInViewModel.LogIn(this.TxtUsername.Text, this.TxtPassword.Password);

            int userId = userInfo[0];
            int userPriveleges = userInfo[0];
            switch (userId)
            {
                case -1:
                    MessageBox.Show("User with this username not found !");
                    break;
                case -2:
                    MessageBox.Show("Username or password wrong !");
                    break;
                case -3:
                    MessageBox.Show("Please fill both username and password !");
                    break;
                default:
                    
                    View view = new View(userId,userPriveleges);
                    
                    this.Close();
                    view.Show();
                    break;
            }
        }

        private void BtnStartUpChangeTheme_OnClick(object sender, RoutedEventArgs e)
        {
            View.currentIndex++;
            if (View.currentIndex == View.Themes.Count)
            {
                View.currentIndex = 0;
            }
            View.UpdateTheme();
        }
    }
}
