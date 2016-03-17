using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using Interfaces;
    using DatabaseLayer;
    using Validation;

    public class LogInViewModel : ILogInViewModel
    {
        // Return codes described in interface documentation

        private readonly Model model = new Model();
        public int LogIn(string username, string password)
        {
            if (Validation.IsNullOrEmpty(username) || Validation.IsNullOrEmpty(password))
            {
                return -3;
            }

            UserSet user = this.model.GetAllUsers().FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return -1;
            }

            if (!DataAccess.PasswordHash.ValidatePassword(password,user.PasswordHash))
            {
                return -2;
            }

            return user.Id;
        }
    }
}
