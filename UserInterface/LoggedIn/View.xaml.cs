using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace UserInterface
{
    using ViewModel;
    using Interfaces;

    public partial class View : Window, IView
    {
        private readonly IViewModel _viewModel;
        private List<ResourceDictionary> Themes;
        private int currentIndex;
        //private bool visible = true;
        //private bool isBlue = true;

        private int loggedInUserId;

        private int priveleges;

        // TODO : check below logic?
        public View() : this (1, 0)
        {
        }

        public View(int userId,int userPriveleges)
        {
            this.InitializeComponent();
            this.Player.MediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "VLCLibs"));
            this.Player.MediaPlayer.EndInit();
            this._viewModel = new ViewModel(this.loggedInUserId);
			GrdMainVideo.Visibility = Visibility.Hidden;
			//this.ShowHideComment(visible);


            this.loggedInUserId = userId;
            this.priveleges = userPriveleges;
            this.SetPrivileges(priveleges);

            ResourceDictionary darkTheme = new ResourceDictionary();
            darkTheme.Source = new Uri("/Themes/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary brightTheme = new ResourceDictionary();
            brightTheme.Source = new Uri("/Themes/BrightTheme.xaml", UriKind.Relative);
            Themes = new List<ResourceDictionary>();
            Themes.Add(darkTheme);
            Themes.Add(brightTheme);
            this.currentIndex = 0;
            UpdateTheme();
        }

        private void BtnUserSearch_OnClick(object sender, RoutedEventArgs e)
        {
			this._viewModel.SearchUsers(this.TxtAdminUserSearch.Text);
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
                this.TxtMainComments.Text = Player.MediaPlayer.Length.ToString();   

            }
	    }

	    private void SdrVolume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	    {
			if(this.Player.MediaPlayer?.Audio != null) this.Player.MediaPlayer.Audio.Volume = (int)this.SdrVolume.Value;
	    }

        //private void BtnMainShowHideComments_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowHideComment(this.visible);
        //}

        private void UpdateTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Themes[this.currentIndex]);
        }

        private void BtnMainChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            this.currentIndex++;
            if (currentIndex == Themes.Count)
            {
                currentIndex = 0;
            }
            UpdateTheme();
        }

        private void BtnMainSearch_OnClick(object sender, RoutedEventArgs e)
        {
            //PlayVideo(new Uri(@"http://37.157.138.76/videos/GOT_Best_Scene.mp4"));
            PlayVideo(new Uri(@"D:\movies\Ip.Man.3.2015.BDRip.x265.AAC-REFLUX\sample.mkv"));
        }

        private void BtnMainStartScreenChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            //ResourceDictionary blueTheme = new ResourceDictionary();
            //blueTheme.Source = new Uri("BlueTheme.xaml", UriKind.Relative);
            //this.Resources.MergedDictionaries.Clear();
            //this.Resources.MergedDictionaries.Add(blueTheme);
        }

        private void BtnMainUpload_OnClick(object sender, RoutedEventArgs e)
        {
            View newView = this;
            string videoLength = this.Player.MediaPlayer.Length.ToString();
            //UploadTab uploadTab = new UploadTab(ref newView,this.loggedInUserId,double.Parse(videoLength));
            //uploadTab.ShowDialog();
        }

        private void BtnMainDownload_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

	    public void PlayVideo(Uri video)
	    {
            this.BtnMainSearch.Visibility = Visibility.Visible;
            this.GrdMainVideo.Visibility = Visibility.Visible;
            this.LsvMainSearchResults.Visibility = Visibility.Hidden;
            this.Player.MediaPlayer.Play(video);
		}

        private void SetPrivileges(int userPriveleges)
        {
            switch (userPriveleges)
            {
                case 0:
                    this.Admin.Visibility = Visibility.Visible;
                    break;
                case 1:
                    this.Admin.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void BtnProfileLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Startup.Startup startup = new Startup.Startup();
            this.Close();
            startup.Show();
        }
    }
}
