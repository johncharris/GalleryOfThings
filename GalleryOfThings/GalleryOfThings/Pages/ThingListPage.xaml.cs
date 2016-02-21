using GalleryOfThings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GalleryOfThings.Pages
{
    public partial class ThingListPage : ContentPage
    {
        public ThingListPage()
        {
            InitializeComponent();


            this.BindingContext = new ThingListViewModel(this);
        }
    }
}
