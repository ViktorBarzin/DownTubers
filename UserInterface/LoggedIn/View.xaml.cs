using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;

namespace UserInterface
{
    using ViewModel;
    using Interfaces;

    public partial class View : Window, IView
    {
        private readonly IViewModel _viewModel;
        //private bool visible = true;
        //private bool isBlue = true;

        private int loggedInUserId;

        private int priveleges;

        public View() : this (0, 0)
        {
            
        }

        public View(int userId,int userPriveleges)
        {
            this.InitializeComponent();
            this.Player.MediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "VLCLibs"));
            this.Player.MediaPlayer.EndInit();
            this._viewModel = new ViewModel(userId, this);
	        DataContext = this._viewModel;
			GrdMainVideo.Visibility = Visibility.Hidden;
			//this.ShowHideComment(visible);


            this.loggedInUserId = userId;
            this.priveleges = userPriveleges;
            this.SetPrivileges(priveleges);

	        for (int i = 0; i < 6; i++)
	        {
	        LsvProfilePlayLists.Items.Add(0);

			}


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

        private void BtnMainChangeTheme_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnMainSearch_OnClick(object sender, RoutedEventArgs e)
        {
            //PlayVideo(new Uri(@"http://37.157.138.76/videos/GOT_Best_Scene.mp4"));
//            PlayVideo(new Uri(@"http://37.157.138.76/videos/GOT_Best_Scene.mp4"));
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
            UploadTab uploadTab = new UploadTab(ref newView);
            uploadTab.ShowDialog();
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
			this.GenerateRandomComments();
            this.Player.MediaPlayer.Play(video);
		}

	    private void GenerateRandomComments()
	    {
		    for (int i = 0; i < 10; i++)
		    {
				this.LsvMainComments.Items.Add("User" + i);
			    this.LsvMainComments.Items.Add("BLABLABLALBLABL");
		    }
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

	    private void LsvMainSearchResults_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	    {
		    var result = (IVideoSearchResult) (LsvMainSearchResults.SelectedItem);
			_viewModel.PlayVideo(result.Id);
	    }
    }
}
