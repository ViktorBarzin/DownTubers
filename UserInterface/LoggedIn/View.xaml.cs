using System;
using System.ComponentModel;
using System.Windows;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

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
	    private string DownloadPath;
        private int priveleges;

        public View() : this (0, 0)
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

        private void BtnMainChangeTheme_Click(object sender, RoutedEventArgs e)
        {
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
            UploadTab uploadTab = new UploadTab(ref newView);
            uploadTab.ShowDialog();
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

	    private void BtnMainDownload_OnClick(object sender, RoutedEventArgs e)
		{

			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();
			this.PbrMainVideoDownload.Visibility = Visibility.Visible;

			string[] filees = Directory.GetFiles(fbd.SelectedPath);
			DownloadPath = fbd.SelectedPath; // + nameOfNewFile;

			try
			{

				// Delete the file if it exists.
				if (File.Exists(DownloadPath))
				{
					File.Delete(DownloadPath);
				}

				// Create the file. 
				using (WebClient client = new WebClient())
				{
					var downloadURI = "http://37.157.138.76/videos/GOT_Best_Scene.mp4";
					DownloadPath = fbd.SelectedPath + "\\" + downloadURI.Split('/').Last();
					var webClient = new WebClient();
					webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
					webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
					webClient.DownloadFileAsync(new Uri(downloadURI), DownloadPath);
				}
			}
			catch
			{
				throw new FileLoadException();
			}
		}

		private void Completed(object sender, AsyncCompletedEventArgs e)
		{
			System.Windows.MessageBox.Show("Download completed at Folder: \n {0}", DownloadPath);
			this.PbrMainVideoDownload.Visibility = Visibility.Hidden;

		}

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
		//	this.PbrMainVideoDownload.Value = 0;
			this.PbrMainVideoDownload.Value = e.ProgressPercentage;
		}


	}
}
