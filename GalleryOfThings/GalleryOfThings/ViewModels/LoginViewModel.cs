using GalleryOfThings.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GalleryOfThings.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(ContentPage page) : base(page)
        {

        }

        public Command LoginCommand {  get { return new Command(() => ((App)App.Current).ShowHomePage()); } }
    }
}
