﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    using System.Reflection.Emit;
    using DatabaseLayer;

    public interface IViewModel
    {
        // Admin tab updates
        void SearchUsers(string username);

        void SearchVideos(string videoTitle);

        void SaveChangesToUser();

        void CancelChanges();

        UserSet DetailedUserInfo { get; set; }

        VideoSet DetailedVideoInfo { get; set; }

        // Profile tab updates

        void ProfilePictureCLick();

        void PlaylistClick(string playlistName);

        void UploadedVideoClick(string videoName);

        void LikedVideoClick(string videoName);

        // Main tab logic

        void ShowHideComment();

        void VideoSearch(string search);

        void Upload();

        void Download(string videoName);

        void OpenSuggestedVideo(string videoName);

        void Logout();
    }
}