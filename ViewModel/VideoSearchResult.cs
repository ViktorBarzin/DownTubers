using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using System.ComponentModel;

    using DatabaseLayer;

    public class VideoSearchResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<VideoSet> VideosToVisualize { get; set; }

        public string FormattedString { get; set; }

        public void FormatVideoResult()
        {
            // todo : format videos for visualization
        }
    }
}
