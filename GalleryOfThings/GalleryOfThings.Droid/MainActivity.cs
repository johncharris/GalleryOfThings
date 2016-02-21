using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using FFImageLoading.Forms;
using FFImageLoading.Forms.Droid;

namespace GalleryOfThings.Droid
{
    [Activity (Label = "Gallery Of Things", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@style/MyTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            CachedImageRenderer.Init ();

            base.OnCreate (savedInstanceState);
            global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
            LoadApplication (new App ());
        }
    }
}

