using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryOfThings.Models
{
    [NotifyPropertyChanged]
    public class Photo
    {
        public string LocalPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
