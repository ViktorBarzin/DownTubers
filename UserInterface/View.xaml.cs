using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Wpf;

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
			Player.MediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "VLCLibs"));
			Player.MediaPlayer.EndInit();
			Player.MediaPlayer.Play(new Uri(@"http://37.157.138.76/videos/The.Walking.Dead.S06E02.720p.HDTV.x264-KILLERS.mkv"));
			var media = Player.MediaPlayer.GetCurrentMedia();
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
