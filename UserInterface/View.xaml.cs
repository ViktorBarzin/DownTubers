using System;
using System.Windows;
using System.IO;

namespace UserInterface
{
    using System.Collections.Specialized;
    using System.Windows.Input;
    using ViewModel;
    using Interfaces;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Input;/// <summary>
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

                this.TxtMainComments.Visibility = Visibility.Visible;
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

                this.TxtMainComments.Visibility = Visibility.Hidden;
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

        private void BtnMainChangeTheme_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMainSearch_OnClick(object sender, RoutedEventArgs e)
        {
            this.GrdMainVideo.Visibility = Visibility.Visible;
            this.GrdMainStartScreen.Visibility = Visibility.Hidden;
            this.Player.MediaPlayer.Pause();
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
