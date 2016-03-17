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
    /// <summary>
    /// Interaction logic for UserProfileEditTab.xaml
    /// </summary>
    public partial class UserProfileEditTab : Window
    {
        private View parent;

        public UserProfileEditTab(ref View parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void BtnEdinPromote_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEditChangeLogo_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEditSave_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEditExit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtEditUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
