#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using GeneraicPhoto.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GalleryOfThings.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public static string PageName { get; set; }
        public static string PreviousPageName { get; set; }

        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
                Page.Title = value;
            }
        }

        public ContentPage Page;
        protected INavigation Navigation;

        public BaseViewModel(ContentPage page)
        {
            this.Page = page;
            this.Navigation = page.Navigation;

            if (Title == null)
            {
                Title = page.Title;
            }

            page.Appearing += page_Appearing;
        }

        async void page_Appearing(object sender, EventArgs e)
        {
            PreviousPageName = PageName;
            PageName = Page.GetType().Name;

            await OnPageAppearing();
        }

        protected virtual async Task OnPageAppearing()
        {
            Debug.WriteLine($"Page {PageName} Appearing");
        }

        bool _isBusy;
        public bool IsBusy { get { return _isBusy; } set { SetProperty(ref _isBusy, value); } }
    }
}
