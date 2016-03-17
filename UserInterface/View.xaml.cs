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
    using ViewModel;
    using Interfaces;

    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        private readonly IViewModel viewModel;
        private bool visible = true;

        public View()
        {
            this.InitializeComponent();
            this.Player.MediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "VLCLibs"));
            this.Player.MediaPlayer.EndInit();
            this.Player.MediaPlayer.Play(new Uri(@"http://37.157.138.76/videos/GOT_Best_Scene.mp4"));
            this.viewModel = new ViewModel();
            this.ShowHideComment(visible);
            this.GridMainVideo();
		}

        private void BtnUserSearch_OnClick(object sender, RoutedEventArgs e)
        {
			this.viewModel.SearchUsers(this.TxtAdminUserSearch.Text);
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
			    BtnPause.Content = "▶";
            }
		    else
		    {
				Player.MediaPlayer.Play();
				BtnPause.Content = "❚❚";
			}
	    }


	    private void SdrVolume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	    {
			if(this.Player.MediaPlayer?.Audio != null) this.Player.MediaPlayer.Audio.Volume = (int)this.SdrVolume.Value;
	    }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SearchUsers(string username)
        {
            throw new NotImplementedException();
        }

        public void SearchVideos(string videoTitle)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesToUser()
        {
            throw new NotImplementedException();
        }

        public void CancelChanges()
        {
            throw new NotImplementedException();
        }

        public void ProfilePictureCLick()
        {
            throw new NotImplementedException();
        }

        public void PlaylistClick(string playlistName)
        {
            throw new NotImplementedException();
        }

        public void UploadedVideoClick(string videoName)
        {
            throw new NotImplementedException();
        }

        public void LikedVideoClick(string videoName)
        {
            throw new NotImplementedException();
        }

        public void Edit(string videoName)
        {
            throw new NotImplementedException();
        }

        public void ShowHideComment(bool isShowed)
        {
            if (isShowed)
            {
                this.LvlMainFirstVideo.Visibility = Visibility.Visible;
                this.LvlMainSecondVideo.Visibility = Visibility.Visible;
                this.LvlMainThirdVideo.Visibility = Visibility.Visible;
                this.LvlMainFourthVideo.Visibility = Visibility.Visible;

                this.LblMainComments.Visibility = Visibility.Visible;
                this.TxtMainWriteComment.Visibility = Visibility.Visible;
                this.BtnMainSendComment.Visibility = Visibility.Visible;
            
                this.visible = !visible;

            }
            if (!isShowed)
            {

                this.LvlMainFirstVideo.Visibility = Visibility.Hidden;
                this.LvlMainSecondVideo.Visibility = Visibility.Hidden;
                this.LvlMainThirdVideo.Visibility = Visibility.Hidden;
                this.LvlMainFourthVideo.Visibility = Visibility.Hidden;

                this.LblMainComments.Visibility = Visibility.Hidden;
                this.TxtMainWriteComment.Visibility = Visibility.Hidden;
                this.BtnMainSendComment.Visibility = Visibility.Hidden;

                this.visible = !visible;
            }
        }

        public void VideoSearch(string search)
        {
            
        }

        public void Upload()
        {
            throw new NotImplementedException();
        }

        public void Download(string videoName)
        {
            throw new NotImplementedException();
        }

        public void OpenSuggestedVideo(string videoName)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void GridMainVideo()
        {
            this.GrdMainVideo.Visibility = Visibility.Hidden;
        }

        private void BtnMainShowHideComments_Click(object sender, RoutedEventArgs e)
        {
            ShowHideComment(this.visible);
        }

        private void TxtMainStartScreenSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.GrdMainVideo.Visibility = Visibility.Visible;
        }

        private void BtnMainStartScreenChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            //ResourceDictionary blueTheme = new ResourceDictionary();
            //blueTheme.Source = new Uri("BlueTheme.xaml", UriKind.Relative);
            //this.Resources.MergedDictionaries.Clear();
            //this.Resources.MergedDictionaries.Add(blueTheme);
        }
    }
}
