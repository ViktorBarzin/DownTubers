﻿namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Model
    {
        private DownTubersEntities Context { get; } = new DownTubersEntities();

        // Utility methods

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        // User logic

        public ICollection<UserSet> GetAllUsers()
        {
            return this.Context.UserSet.ToList();
        }

        public bool AddUser(UserSet user)
        {
            try
            {
                this.Context.UserSet.Add(user);
                this.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteUser(UserSet user)
        {
            try
            {
                this.Context.UserSet.Remove(
                this.Context.UserSet.FirstOrDefault(x => x.Id == user.Id && x.Username == user.Username));
                this.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditUser(UserSet updatedUser)
        {
            UserSet original = this.Context.UserSet.Find(updatedUser.Id);
            if (original == null)
            {
                return false;
            }

            this.Context.Entry(original).CurrentValues.SetValues(updatedUser);
            this.SaveChanges();
            return true;
        }

        // Videos logic

        public ICollection<VideoSet> GetAllVideos()
        {
            return this.Context.VideoSet.ToList();
        }

        public bool AddVideo(VideoSet video)
        {
            try
            {
                this.Context.VideoSet.Add(video);
                this.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteVideo(VideoSet video)
        {
            try
            {
                this.Context.VideoSet.Remove(
                this.Context.VideoSet.FirstOrDefault(x => x.Id == video.Id && x.Title == video.Title));
                this.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditVideo(VideoSet updatedVideo)
        {
            VideoSet original = this.Context.VideoSet.Find(updatedVideo.Id);
            if (original == null)
            {
                return false;
            }

            this.Context.Entry(original).CurrentValues.SetValues(updatedVideo);
            this.SaveChanges();
            return true;
        }

        // Subscribers logic

        public ICollection<UserSet> GetAllSubscribers(UserSet user)
        {
            return this.Context.UserSet.SelectMany(x => x.Subscriber).ToList();
        }

        // History logic

        public ICollection<HistorySet> GetFullHistory(UserSet user)
        {
            UserSet userToFind = this.Context.UserSet.Find(user.Id);
            if (userToFind != null)
            {
                return userToFind.HistorySet.ToList();
            }

            throw new ArgumentNullException("user");
        }

        public bool DeleteHistory(UserSet user)
        {
            UserSet userToFind = this.Context.UserSet.Find(user.Id);
            if (userToFind == null)
            {
                return false;
            }

            userToFind.HistorySet.Clear();
            this.SaveChanges();
            return true;
        }

        // Playlist logic

        public ICollection<PlaylistSet> GetAllPlaylists(UserSet user)
        {
            UserSet userToFind = this.Context.UserSet.Find(user.Id);
            if (userToFind != null)
            {
                return userToFind.PlaylistSet.Where(x => x.UserId == userToFind.Id).ToList();
            }

            throw new ArgumentNullException("user");
        }

        public bool DeletePlaylist(UserSet user, PlaylistSet playlistSet)
        {
            UserSet userToFind = this.Context.UserSet.Find(user.Id);
            if (userToFind == null)
            {
                return false;
            }

            PlaylistSet playlistToDelete = this.Context.PlaylistSet.Find(playlistSet.Id);
            if (playlistToDelete == null)
            {
                return false;
            }

            this.Context.PlaylistSet.Remove(userToFind.PlaylistSet.FirstOrDefault(x => x.Id == playlistSet.Id));
            this.SaveChanges();
            return true;
        }
    }
}
