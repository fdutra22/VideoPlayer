using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using VideoPlayer.Pages;
using Xamarin.Forms;

namespace VideoPlayer {
    public partial class App : Application {
        public App() {
            InitializeComponent();

			try
			{
				MainPage = new VideoPage();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
