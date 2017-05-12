using Foundation;
using UIKit;
using Xamarin.Forms;
using VideoPlayer.iOS;
using VideoPlayer.Utils;
using Xamarin.Forms.Platform.iOS;
using VitamioIOSBinding;
using VideoPlayer.Pages;

[assembly: ExportRenderer(typeof(VideoPage), typeof(VideoRendereriOS))]
namespace VideoPlayer.iOS {
	public partial class VideoRendereriOS : PageRenderer
	{
		public VMediaPlayer Player { get; set; }

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			Player = VMediaPlayer.SharedInstance();

			if (VideoCountiOS.Count == 1)
			{
				Player.SetupPlayerWithCarrierView(this.View, new VdoDelegate(this));
				Player.SetDataSource(NSUrl.FromString(UrlCamera.Url));
				Player.PrepareAsync();
				VideoCountiOS.Count = 2;
			}
			else
			{ //need to be used when have a navigation page and want turn back to the video
				Player.UnSetupPlayer();
				Player.SetupPlayerWithCarrierView(this.View, new VdoDelegate(this));
				Player.SetDataSource(NSUrl.FromString(UrlCamera.Url));
				Player.PrepareAsync();
			}

		
		}
	}
    public class VdoDelegate : VMediaPlayerDelegate {
        VideoRendereriOS Controller { get; set; }

        public VdoDelegate(VideoRendereriOS controller) {
            Controller = controller;
        }

        public override void DidPrepared(VMediaPlayer player, NSObject obj) {

            Controller.Player.Start();
        }

        public override void Error(VMediaPlayer player, NSObject obj) {
				           
        }

        public override void PlaybackCompleted(VMediaPlayer player, NSObject obj) {
           
        }

        public override void SetupPlayerPreference(VMediaPlayer player, NSObject obj) {
           
			player.SetVideoQuality(VideoQuality.High);
			player.UseCache = true;

        }

		public override void videoTrackLagging(VMediaPlayer player, NSObject obj)
		{
			
		}
    }
}