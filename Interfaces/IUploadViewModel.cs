using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUploadViewModel
    {
        bool Upload(int authorId,string filePath, string title, string description);
    }
}
