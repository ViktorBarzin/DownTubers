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

		private UserSet _loggedInUser;
		private VideoSet _playingVideo;
		private Model _model;
		private List<IVideoSearchResult> _videoSearchResults;

		public ObservableCollection<IVideoSearchResult> VideoSearchResults => new ObservableCollection<IVideoSearchResult>(_videoSearchResults);


		public ViewModel(int userId)
		{
			_model = new Model();
			_loggedInUser = _model.GetAllUsers().FirstOrDefault(x => x.Id == userId);
			var test = new VideoSet() { Title = "TestTitle", Description = "VideoDescriptionlalalallalaasdfasdf" };

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
			throw new NotImplementedException();
		}

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
