using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GalleryOfThings.Models
{
    [ImplementPropertyChanged]
    public class Thing
    {
        public string Name { get; set; }

        public Uri DefualtPhotoUri { get; set; }
        public ObservableCollection<Photo> Photos { get; set; }

        public string FirstImageUri {  get { return Photos.FirstOrDefault()?.LocalPath; } }

        public Thing(string name, Uri defaultPhotoUri)
        {
            this.Name = name;
            this.DefualtPhotoUri = defaultPhotoUri;
        }
    }
}
