using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using System.ComponentModel;

    using DatabaseLayer;
    
    public class UserSearchResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<UserSet> UsersToVisualize { get; set; }

        public string FormattedString { get; set; }

        public void FormatUserResult()
        {
            // todo : format users for visualization
        }
    }
}
