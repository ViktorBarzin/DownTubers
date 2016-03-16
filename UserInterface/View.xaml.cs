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
			Player.MediaPlayer.Play(new Uri(@"http://37.157.138.76/videos/GOT_Best_Scene.mp4"));
		}

        private void BtnUserSearch_OnClick(object sender, RoutedEventArgs e)
        {
			//this.dataBinding.BtnUserSearchClick(this.TxtAdminUserSearch.Text);
		}

        private void BtnProfileEdit_OnClick(object sender, RoutedEventArgs e)
        {
            View newView = this;
            UserProfileEditTab editTab = new UserProfileEditTab(ref newView);
            editTab.ShowDialog();
        }

	    private void BtnPause_OnClick(object sender, RoutedEventArgs e)
	    {
		    if (Player.MediaPlayer.IsPlaying)
		    {
			    Player.MediaPlayer.Pause();
			    BtnPause.Content = "Play";
		    }
		    else
		    {
				Player.MediaPlayer.Play();
				BtnPause.Content = "Pause";
			}
	    }

	    private void SdrVolume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	    {
			if(Player.MediaPlayer?.Audio != null)
				Player.MediaPlayer.Audio.Volume = (int)SdrVolume.Value;
	    }
    }
}
