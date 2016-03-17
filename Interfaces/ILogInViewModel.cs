using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    using DatabaseLayer;

    public interface ILogInViewModel
    {
        /// <summary>
        /// Used to log into the application.
        /// </summary>
        /// <param name="username">Username to log in with.</param>
        /// <param name="password">Password to log in with.</param>
        /// <returns>
        /// -1 : user not found
        /// -2 : password is wrong
        /// -3 : username or password empty
        /// >= 0 : logged in user id
        /// </returns>
        int LogIn(string username, string password);
    }
}
