using VideoPlayer.Utils;
using Xamarin.Forms;

namespace VideoPlayer.Pages
{

	public class VideoPage : ContentPage
	{


		public VideoPage()
		{
			UrlCamera.Url = "rtsp://admin:admin@engenharianewline.dyndns.org:554/cam/realmonitor?channel=1&subtype=1";
		}


	}
}
