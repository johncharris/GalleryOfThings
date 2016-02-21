using GalleryOfThings.Models;
using GalleryOfThings.Pages;
using Plugin.Media;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GalleryOfThings.ViewModels
{
    [ImplementPropertyChanged]
    public class ThingListViewModel : BaseViewModel
    {
        const int PhotoColumnCount = 3;

        public bool IsTakePhotoVisible { get { return Device.Idiom == TargetIdiom.Tablet; } }

        public ObservableCollection<Thing> AllTheThings { get; set; } = new ObservableCollection<Thing>();
        public List<Thing> FilteredThings
        {
            get
            {
                if (string.IsNullOrEmpty(FilterText))
                    return new List<Thing>(AllTheThings);
                else
                    return AllTheThings.Where(x => x.Name.ToUpper().Contains(FilterText.ToUpper())).ToList();
            }
        }

        public string FilterText { get; set; }

        public ThingListViewModel(ContentPage page) : base(page)
        {
        }

        protected override async Task OnPageAppearing()
        {
            await base.OnPageAppearing();

            // Load the things
            AllTheThings.Add(new Thing("Google Thing", new Uri("http://lorempixel.com/100/100/"))
            {
                Photos = new ObservableCollection<Photo>(new[]
                {
                    new Photo { Description = "Test",  LocalPath = "http://lorempixel.com/300/300/", Title = "300x300" },
                    new Photo{ Description = "Test",  LocalPath = "http://lorempixel.com/200/200/", Title = "200x200" },
                    new Photo { Description = "Test",  LocalPath = "http://lorempixel.com/100/100/", Title = "100x100" },
                    new Photo { Description = "Test",  LocalPath = "http://lorempixel.com/350/350/", Title = "350x350" },
                    new Photo{ Description = "Test",  LocalPath = "http://lorempixel.com/250/250/", Title = "250x250" },
                    new Photo { Description = "Test",  LocalPath = "http://lorempixel.com/150/150/", Title = "150x150" },
                    new Photo { Description = "Test",  LocalPath = "http://lorempixel.com/150/150/", Title = "150x150" }

                })
            });
            AllTheThings.Add(new Thing("Bing Thing", new Uri("http://lorempixel.com/200/200/")));
            FilterText = string.Empty;
        }

        Thing _selectedThing;
        public Thing SelectedThing
        {
            get { return _selectedThing; }
            set
            {
                SetProperty(ref _selectedThing, value);
                if (value == null)
                    return;

                Navigation.PushAsync(new ThingDetailPage(value));

                // Unselect the row;
                SelectedThing = null;
            }
        }

        public ICommand AddPhotoCommand { get { return new Command(async () => await AddPhoto()); } }

        async Task AddPhoto()
        {
            //await CrossMedia.Current.Initialize();


            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = Guid.NewGuid().ToString() + ".jpg"
            //});

            //Photos.Add(new Photo { LocalPath = file.Path });
        }

    }
}
