using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Dropbox.Api;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace UserInterface
{
    using ViewModel;
    using Interfaces;
    using System.Windows.Media;
    public partial class View : Window, IView
    {
        private readonly IViewModel _viewModel;
        public static List<ResourceDictionary> Themes;
        public static int currentIndex = 0;
        private bool visible = true;
        //private bool isBlue = true;

        private int loggedInUserId;
        private string DownloadPath;
        private int priveleges;
        private int _currVideoId;

        // TODO : check below logic?
        public View() : this(1, 0)
        {
        }

        public View(int userId, int userPriveleges)
        {
            this.InitializeComponent();
            this.Player.MediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "VLCLibs"));
            this.Player.MediaPlayer.EndInit();
            this.Player.MediaPlayer.Click += (s, e) => BtnPause_OnClick(s, (RoutedEventArgs)e);
            this._viewModel = new ViewModel(userId, this);
            DataContext = this._viewModel;
            GrdMainVideo.Visibility = Visibility.Hidden;
			//this.ShowHideComment(visible);

	        using (var dbx = new DropboxClient("N6LeEI8nmwAAAAAAAAAGErJyYPZcGf-_TRbjpFICvxOrODJiK9YIGQcF-0buCnTC"))
	        {
		        Func<DropboxClient, string, string, Task> task1 = Download;

		        Func<Task> task2 = () => task1(dbx, "", "test.txt"); 

		        var task = Task.Run(task2);
		        task.Wait();
	        }


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
            UpdateTheme();

			
        }

		static async Task Download(DropboxClient dbx, string folder, string file)
		{
			using (var sw = new FileStream(file, FileMode.OpenOrCreate))
			{
				using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
				{
					byte[] data = await response.GetContentAsByteArrayAsync();
					sw.Write(data,0,data.Length);
				}
			}
		}

		static async Task ListRootFolder()
		{
			using (var dbx = new DropboxClient("N6LeEI8nmwAAAAAAAAAGErJyYPZcGf-_TRbjpFICvxOrODJiK9YIGQcF-0buCnTC"))
			{
				var list = await dbx.Files.ListFolderAsync(string.Empty);

				// show folders then files
				foreach (var item in list.Entries.Where(i => i.IsFolder))
				{
					MessageBox.Show(item.Name);
				}

				foreach (var item in list.Entries.Where(i => i.IsFile))
				{
					MessageBox.Show(item.Name);
				}
			}
		}

		static async Task Run()
		{
			using(var dbx = new DropboxClient("N6LeEI8nmwAAAAAAAAAGErJyYPZcGf-_TRbjpFICvxOrODJiK9YIGQcF-0buCnTC"))
			{
				var full = await dbx.Users.GetCurrentAccountAsync();
				MessageBox.Show(String.Format("{0} - {1}", full.Name.DisplayName, full.Email));
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
            if (this.Player.MediaPlayer?.Audio != null) this.Player.MediaPlayer.Audio.Volume = (int)this.SdrVolume.Value;
        }

        //private void BtnMainShowHideComments_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowHideComment(this.visible);
        //}

        public static void UpdateTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Themes[currentIndex]);
        }

        private void BtnMainSearch_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.VideoSearch(TxtMainSearch.Text);
            this.GrdMainVideo.Visibility = Visibility.Hidden;
            this.LsvMainSearchResults.Visibility = Visibility.Visible;
            this.Player.MediaPlayer.Stop();
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
            // TODO : upload button click here
            UploadTab uploadTab = new UploadTab(ref newView, this.loggedInUserId, int.Parse(videoLength));
            uploadTab.ShowDialog();
        }

        public void PlayVideo(Uri video)
        {
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

        private void BtnProfileLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Startup.Startup startUp = new Startup.Startup();

            if (MessageBox.Show("Are you sure?", "Log out!",
               MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
                Player.MediaPlayer.Stop();
                startUp.Show();
            }
            else
            {
                this.Show();
            }
        }
        private void BtnMainShowHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideComments();
        }

        public void ShowHideComments()
        {
            if (visible)
            {
                this.LsvMainComments.Visibility = Visibility.Visible;
                this.LvlMainFirstVideo.Visibility = Visibility.Visible;
                this.TxtMainWriteComment.Visibility = Visibility.Visible;
                this.BtnMainSendComment.Visibility = Visibility.Visible;

                this.visible = false;
            }
            else
            {
                this.LsvMainComments.Visibility = Visibility.Hidden;
                this.LvlMainFirstVideo.Visibility = Visibility.Hidden;
                this.TxtMainWriteComment.Visibility = Visibility.Hidden;
                this.BtnMainSendComment.Visibility = Visibility.Hidden;

                this.visible = true;
            }
        }

        private void BtnMainGoHome_Click(object sender, RoutedEventArgs e)
        {
            this.GrdMainStartScreen.Visibility = Visibility.Visible;
            this.LsvMainSearchResults.Visibility = Visibility.Visible;
            this.GrdMainVideo.Visibility = Visibility.Hidden;
            Player.MediaPlayer.Stop();
        }

        private void BtnFullscreen_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LsvMainSearchResults_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var result = (IVideoSearchResult)(LsvMainSearchResults.SelectedItem);

            if (result == null) return;

            _viewModel.PlayVideo(result.Id);
            _currVideoId = result.Id;
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

        private void BtnMainChangeTheme_OnClick(object sender, RoutedEventArgs e)
        {
            currentIndex++;

            if (currentIndex == Themes.Count)
            {
                currentIndex = 0;
            }

            UpdateTheme();
        }
    }
}
