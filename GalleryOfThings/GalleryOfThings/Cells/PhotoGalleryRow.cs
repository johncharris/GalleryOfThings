using GalleryOfThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using FFImageLoading.Forms;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GalleryOfThings.Cells
{
    public class PhotoGalleryRow : ViewCell
    {
        public static readonly BindableProperty ColumnCountProperty = BindableProperty.Create<PhotoGalleryRow, int>(x => x.ColumnCount, 3);
        public static readonly BindableProperty PhotosProperty = BindableProperty.Create<PhotoGalleryRow, ObservableCollection<Photo>>(x => x.Photos, new ObservableCollection<Photo>());

        public int ColumnCount { get { return (int)GetValue(ColumnCountProperty); } set { SetValue(ColumnCountProperty, value); } }
        public ObservableCollection<Photo> Photos { get { return (ObservableCollection<Photo>)GetValue(PhotosProperty); } set { SetValue(PhotosProperty, value); } }

        StackLayout root = new StackLayout { Orientation = StackOrientation.Horizontal };
        List<PhotoGalleryCell> cells = new List<PhotoGalleryCell>();

        public PhotoGalleryRow()
        {
            View = root;

            Photos.CollectionChanged += Photos_CollectionChanged;
        }

        private void Photos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                root.Children.Add(new CachedImage { WidthRequest = 100, HeightRequest = 100, Source = ((Photo)e.NewItems[0]).LocalPath });

        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            root.Children.Clear();
            for (int i = 0; i < ColumnCount; i++)
            {
                if (Photos.Count > i)
                {
                    root.Children.Add(new CachedImage { HorizontalOptions = LayoutOptions.FillAndExpand, Source = Photos[i].LocalPath });
                }
                else
                    root.Children.Add(new BoxView { HorizontalOptions = LayoutOptions.FillAndExpand });
            }
        }
    }
}
