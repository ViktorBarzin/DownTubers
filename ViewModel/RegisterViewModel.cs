using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using System.Windows.Forms;

    using DataAccess;

    using DatabaseLayer;

    using Validation;
    using System.Data;

    public class RegisterViewModel
    {
        readonly Model model = new Model();

        public bool Register(string username,string password,string confirmPassword,string email,string firstName,string lastName,string description)
        {
            if (Validation.IsNullOrEmpty(username) || Validation.IsNullOrEmpty(password) || Validation.IsNullOrEmpty(confirmPassword) || Validation.IsNullOrEmpty(email)||
                !Validation.ValidEmail(email))
            {
                return false;
            }

            if (password != confirmPassword)
            {
                return false;
            }

            UserSet userToAdd = new UserSet() {Username = username, PasswordHash = PasswordHash.HashPassword(password), Email = email};

            if (!Validation.IsNullOrEmpty(firstName))
            {
                userToAdd.FirstName = firstName;
            }

            if (!Validation.IsNullOrEmpty(lastName))
            {
                userToAdd.LastName = lastName;
            }

            if (!Validation.IsNullOrEmpty(description))
            {
                userToAdd.FirstName = description;
            }

            userToAdd.Registered = DateTime.Now;
            userToAdd.LastLogin = DateTime.Now;

            try
            {
                this.model.AddUser(userToAdd);
                this.model.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
        }
    }
}
