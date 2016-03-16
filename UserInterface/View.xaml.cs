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

namespace UserInterface
{
    using System.Collections.Specialized;
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {

        public View()
        {
            this.InitializeComponent();
        }

        private void BtnUserSearch_OnClick(object sender, RoutedEventArgs e)
        {
           //this.dataBinding.BtnUserSearchClick(this.TxtAdminUserSearch.Text);
        }

        private void BtnProfileEdit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
