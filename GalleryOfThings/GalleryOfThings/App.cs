using GalleryOfThings.Helpers;
using GalleryOfThings.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using FreshMvvm;
using GalleryOfThings.ViewModels;

namespace GalleryOfThings
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            //if (!Settings.LoggedIn)
            //    MainPage = new LoginPage();
            //else
            //    ShowHomePage();

            //Show the Home Page
            var page = FreshPageModelResolver.ResolvePageModel<ThingListPageModel> ();
            var basicNavContainer = new FreshNavigationContainer (page);
            MainPage = basicNavContainer;
        }

        public void ShowHomePage ()
        {
            MainPage = new NavigationPage (new ThingListPage ());
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
