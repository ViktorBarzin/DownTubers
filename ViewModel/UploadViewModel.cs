using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using DatabaseLayer;

    using Interfaces;
    using Validation;

    public class UploadViewModel : IUploadViewModel
    {
        public bool Upload(int authorId,string filePath, string title, string description)
        {
            if (Validation.IsNullOrEmpty(filePath) || Validation.IsNullOrEmpty(title) || Validation.IsNullOrEmpty(description))
            {
                return false;
            }

            //VideoSet newVideo = new VideoSet() { Title = title,AuthorId = authorId,UploadTime = DateTime.Now,Description = description,Length = };
            return true;
        }
    }
}
