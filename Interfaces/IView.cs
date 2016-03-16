﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IView
    {
        // Utility methods

        void SaveChanges();

        // Admin tab updates
        void SearchUsers(string username);

        void SearchVideos(string videoTitle);

        void SaveChangesToUser();

        void CancelChanges();

        // Profile tab updates

        void Logout();

        void Edit();
    }
}
