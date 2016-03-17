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

    public class ViewModel : IViewModel
    {

        // TODO : implementation for viewmodel + adding classes for properties to display them
        // TODO : documentation

        // Admin panel search results

        public UserSet DetailedUserInfo { get; set; }
        
        public VideoSet DetailedVideoInfo { get; set; }
        
        public UserSearchResult UserSearchResult { get; set; }
        
        public VideoSearchResult VideoSearchResult { get; set; }

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
    }
}
