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

namespace UserInterface
{
    using ViewModel;

    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        readonly RegisterViewModel registerViewModel = new RegisterViewModel();
        public Register()
        {
            this.InitializeComponent();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            Startup.Startup logInWindows = new Startup.Startup();
            this.Close();
            logInWindows.Show();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.registerViewModel.Register(
                this.TxtUsername.Text,
                this.TxtPassword.Password,
                this.TxtConfirmPassword.Password,
                this.TxtEmail.Text,
                this.TxtFirstName.Text,
                this.TxtLastName.Text,
                this.TxtDescription.Text))
            {
                MessageBox.Show("Registration successful !");
                Startup.Startup loginWindow = new Startup.Startup();
                this.Close();
                loginWindow.Show();
            }
            else
            {
                MessageBox.Show("Somthing went wrong, please check you input again !");
            }
        }
    }
}
