using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoPlayer.Utils {
	public  class VideoViewForms : ContentPage {



        public static readonly BindableProperty UrlRtsp =
            BindableProperty.Create<VideoViewForms, string>(p => p.Url, "");

        public string Url
        {
            get { return (string)GetValue(UrlRtsp); }
            set { SetValue(UrlRtsp, value); }
        }
    }
}
