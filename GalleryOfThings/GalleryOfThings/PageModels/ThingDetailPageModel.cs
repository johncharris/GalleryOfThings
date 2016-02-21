using FreshMvvm;
using GalleryOfThings.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GalleryOfThings.ViewModels
{
    [ImplementPropertyChanged]
    public class ThingDetailPageModel : FreshBasePageModel
    {
        public Thing Thing { get; set; }

        public List<PhotoRowHolder> PhotoRows { get; set; } = new List<PhotoRowHolder>();

        public ThingDetailPageModel()
        {

        }

        public override void Init(object initData)
        {
            base.Init(initData);

            Thing = initData as Thing;

            // Load the photos
            for (int i = 0; i < Math.Floor((float)Thing.Photos.Count / 3); i++)
            {
                PhotoRowHolder row = new PhotoRowHolder();
                for (int x = 0; x < 3; x++)
                {
                    if (Thing.Photos.Count >= (i * 3) + x)
                        row.Photos.Add(Thing.Photos[(i * 3) + x]);
                }
                PhotoRows.Add(row);
            }
        }

        public class PhotoRowHolder
        {
            public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
        }
    }
}
