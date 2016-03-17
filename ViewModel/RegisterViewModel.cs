using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RegisterViewModel
    {
        public bool Register(params string[] inputs)
        {
            foreach (var text in inputs)
            {
                return true;
            }
            return true;
        }
    }
}
