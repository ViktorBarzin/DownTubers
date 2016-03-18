	using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Annotations;

namespace ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	//using DataAccess;

	using DatabaseLayer;

	using Interfaces;

	public sealed class ViewModel : IViewModel, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		private IView _view;
		private VideoSet _playingVideo;
		private Model _model;
		private List<IVideoSearchResult> _videoSearchResults;

		public ObservableCollection<IVideoSearchResult> VideoSearchResults => new ObservableCollection<IVideoSearchResult>(_videoSearchResults);
		public UserSet LoggedInUser { get; private set; }

//		public ObservableCollection<> 

		public ViewModel(int userId, IView view)
		{
			_view = view;
			_model = new Model();
			LoggedInUser = _model.GetAllUsers().FirstOrDefault(x => x.Id == userId);
			var test = new VideoSet() { Title = "TestTitle", Description = "VideoDescriptionlalalallalaasdfasdf" };
//			_loggedInUser.


			_videoSearchResults = new List<IVideoSearchResult>
			{
				new VideoSearchResult(test),
				new VideoSearchResult(test),
				new VideoSearchResult(test),
				new VideoSearchResult(test),
				new VideoSearchResult(test)
			};

			OnPropertyChanged("VideoSearchResults");
		}

		// admin panel ends
		public void CancelChanges()
		{
			throw new NotImplementedException();
		}

		public void Download(string videoName)
		{
			throw new NotImplementedException();
		}

		public void LikedVideoClick(string videoName)
		{
			throw new NotImplementedException();
		}

		public void Logout()
		{
			throw new NotImplementedException();
		}

		public void OpenSuggestedVideo(string videoName)
		{
			throw new NotImplementedException();
		}

		public void PlaylistClick(string playlistName)
		{
			throw new NotImplementedException();
		}

		public void ProfilePictureCLick()
		{
			throw new NotImplementedException();
		}

		public void SaveChangesToUser()
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

		public void ShowHideComment()
		{
			throw new NotImplementedException();
		}

		public void Upload()
		{
			throw new NotImplementedException();
		}

		public void UploadedVideoClick(string videoName)
		{
			throw new NotImplementedException();
		}

		public void VideoSearch(string search)
		{
			var results = _model.SearchVideo(search);
			_videoSearchResults.Clear();

			foreach (var videoSet in results)
			{
				_videoSearchResults.Add(new VideoSearchResult(videoSet));
			}

			OnPropertyChanged("VideoSearchResults");
		}

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void PlayVideo(int id)
		{
			string videoPath = "GOT_Best_Scene.mp4"; // Get video from model
			_view.PlayVideo(new Uri(@"https://www.dropbox.com/home/Apps/DownTubers?preview=test2.mkv"));
		}
	}
}
