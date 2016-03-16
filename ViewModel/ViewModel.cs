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
        // TODO : implementation for viewmodel + adding classes for properties
        // TODO : documentation tomorrow (:
        public UserSet DetailedUserInfo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public VideoSet DetailedVideoInfo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<UserSet> UserMatches
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<VideoSet> VideoMatches
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

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
