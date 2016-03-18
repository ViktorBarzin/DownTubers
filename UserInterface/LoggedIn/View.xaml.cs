
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using Dropbox.Api;
using System.Threading.Tasks;

namespace UserInterface
{
    using System.Text;
    using System.Windows.Input;

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
  
        async Task Download(DropboxClient dbx, string folder, string file)
        {
            using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
            {
                Console.WriteLine(await response.GetContentAsStringAsync());
            }
        }

        private void BtnMainDownload_OnClick(object sender, RoutedEventArgs e)
        {
            // OLD DOWNLOAD METHOD FOR HTTP server
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //DialogResult result = fbd.ShowDialog();
            //this.PbrMainVideoDownload.Visibility = Visibility.Visible;

            //string[] filees = Directory.GetFiles(fbd.SelectedPath);
            //DownloadPath = fbd.SelectedPath; // + nameOfNewFile;

            //try
            //{

            //	// Delete the file if it exists.
            //	if (File.Exists(DownloadPath))
            //	{
            //		File.Delete(DownloadPath);
            //	}

            //	// Create the file. 
            //	using (WebClient client = new WebClient())
            //	{
            //		var downloadURI = "http://37.157.138.76/videos/GOT_Best_Scene.mp4";
            //		DownloadPath = fbd.SelectedPath + "\\" + downloadURI.Split('/').Last();
            //		var webClient = new WebClient();
            //		webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //		webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            //		webClient.DownloadFileAsync(new Uri(downloadURI), DownloadPath);
            //	}
            //}
            //catch
            //{
            //	throw new FileLoadException();
            //}
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

        private void BtnMainSendComment_OnClick(object sender, RoutedEventArgs e)
        {
            //StringBuilder comments = new StringBuilder(this.lbl);
            this.LsvMainComments.Items.Add(string.Format(this._viewModel.GetUserById(this.loggedInUserId)));
            this.LsvMainComments.Items.Add(this.TxtMainWriteComment.Text);
            
            this.TxtMainWriteComment.Text = string.Empty;
            this.LsvMainComments.ScrollIntoView(this.LsvMainComments.Items[this.LsvMainComments.Items.Count - 1]);
        }

        private void Keyboard_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }

            if (this.TxtMainSearch.IsFocused)
            {
                object sen = new object();
                RoutedEventArgs e2 = new RoutedEventArgs();
                this.BtnMainSearch_OnClick(sen,e2);
            }

            if (this.TxtMainWriteComment.IsFocused)
            {
                object sen = new object();
                RoutedEventArgs e2 = new RoutedEventArgs();
                this.BtnMainSendComment_OnClick(sen, e2);
            }
        }
    }
}
