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
        private Model model = new Model();

        public bool Upload(int authorId, string filePath, string title, string description, int videoLength)
        {
            if (Validation.IsNullOrEmpty(filePath) || Validation.IsNullOrEmpty(title) || Validation.IsNullOrEmpty(description))
            {
                return false;
            }

            VideoSet newVideo = new VideoSet() { Title = title, AuthorId = authorId, UploadTime = DateTime.Now, Description = description, Length = videoLength, Views = 0, Likes = 0, VideoPath = filePath };

            try
            {
                this.model.AddVideo(newVideo);
                this.model.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
