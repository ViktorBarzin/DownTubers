using System;
using Dropbox.Api;
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
using System.Windows.Shapes;
using Dropbox.Api.Files;

namespace UserInterface
{
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;

//    using HigLabo.Net.Dropbox;

    using Interfaces;

    using Microsoft.Win32;

    using ViewModel;
    /// <summary>
    /// Interaction logic for UploadTab.xaml
    /// </summary>
    public partial class UploadTab : Window
    {
        private View parent;

        private readonly IUploadViewModel uploadViewModel;

        private readonly int authorId;

        private string filePath = string.Empty;

        private readonly int videoLength;

        public UploadTab(ref View parent, int authorId,int videoLength)
        {

            this.parent = parent;
            this.authorId = authorId;
            this.videoLength = videoLength;
            this.uploadViewModel = new UploadViewModel();
            this.InitializeComponent();
        }

        private void BtnUploadBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.TxtUploadBrowse.Text = openFileDialog.FileName;
            }
        }

		static async Task Upload(DropboxClient dbx, string folder, string file, string filePath)
		{
			using(var mem = new FileStream(filePath, FileMode.Open))
			{
				var updated = await dbx.Files.UploadAsync(
					folder + "/" + file,
					WriteMode.Overwrite.Instance,
					body: mem);
				//				Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
			}
		}

		private void BtnUploadSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.uploadViewModel.Upload(this.authorId,this.filePath, TxtUploadTitle.Text, TxtUploadDescription.Text,this.videoLength))
            {
				// TODO : change stuff for upload
				//MessageBox.Show("Starting upload");
				//                DropboxClient client = new DropboxClient();

				//                DropboxCommand command = new UploadFileCommand();

				//NameValueCollection nvc = new NameValueCollection();
				//nvc.Add("id", "TTR");
				//nvc.Add("btn-submit-photo", "Upload");
				//HttpUploadFile(@"http://37.157.138.76/videos/",
				//     filePath, TxtUploadTitle.Text, "mp4/mkv", nvc);
				using(var dbx = new DropboxClient("N6LeEI8nmwAAAAAAAAAGErJyYPZcGf-_TRbjpFICvxOrODJiK9YIGQcF-0buCnTC"))
				{
					Func<DropboxClient, string, string, string, Task> task1 = Upload;

					Func<Task> task2 = () => task1(dbx, "", "test2.mkv", "test.mkv");

					var task = Task.Run(task2);
					task.Wait();
				}
			}
            else
            {
                //MessageBox.Show("Something fucked up");
            }
        }

        private void BtnUploadExit_OnClick(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        //public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        //{
        //    MessageBox.Show((string.Format("Uploading {0} to {1}", file, url)));
        //    string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        //    byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

        //    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
        //    wr.ContentType = "multipart/form-data; boundary=" + boundary;
        //    wr.Method = "POST";
        //    wr.KeepAlive = true;
        //    wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

        //    Stream rs = wr.GetRequestStream();

        //    string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
        //    foreach (string key in nvc.Keys)
        //    {
        //        rs.Write(boundarybytes, 0, boundarybytes.Length);
        //        string formitem = string.Format(formdataTemplate, key, nvc[key]);
        //        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
        //        rs.Write(formitembytes, 0, formitembytes.Length);
        //    }
        //    rs.Write(boundarybytes, 0, boundarybytes.Length);

        //    string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
        //    string header = string.Format(headerTemplate, paramName, file, contentType);
        //    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
        //    rs.Write(headerbytes, 0, headerbytes.Length);

        //    FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
        //    byte[] buffer = new byte[4096];
        //    int bytesRead = 0;
        //    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
        //    {
        //        rs.Write(buffer, 0, bytesRead);
        //    }
        //    fileStream.Close();

        //    byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
        //    rs.Write(trailer, 0, trailer.Length);
        //    rs.Close();

        //    WebResponse wresp = null;
        //    try
        //    {
        //        wresp = wr.GetResponse();
        //        Stream stream2 = wresp.GetResponseStream();
        //        StreamReader reader2 = new StreamReader(stream2);
        //        MessageBox.Show(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("Error uploading file", ex));
        //        if (wresp != null)
        //        {
        //            wresp.Close();
        //            wresp = null;
        //        }
        //    }
        //    finally
        //    {
        //        wr = null;
        //    }
        //}
    }
}
