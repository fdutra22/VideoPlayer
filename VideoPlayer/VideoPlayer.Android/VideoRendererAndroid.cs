using Android.App;
using Android.Widget;
using IO.Vov.Vitamio;
using VideoPlayer.Droid;
using VideoPlayer.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using VideoPlayer.Pages;

[assembly: ExportRenderer(typeof(VideoPage), typeof(VideoRendererAndroid))]

namespace VideoPlayer.Droid
{
	public class VideoRendererAndroid : PageRenderer
	{
		private Activity activity;

		private IO.Vov.Vitamio.Widget.VideoView videoView;

		protected Android.Views.View NativeView;

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{

			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;


				activity = this.Context as Activity;

				videoView = new IO.Vov.Vitamio.Widget.VideoView(Forms.Context);

				videoView.SetVideoPath(UrlCamera.Url);
				videoView.SetMediaController(new IO.Vov.Vitamio.Widget.MediaController(activity));
				videoView.RequestFocus();

				var ll = new LinearLayout(Forms.Context);

				ll.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
				ll.SetPadding(10, 50, 10, 50);


				videoView.Start();

				ll.AddView(videoView);
				AddView(ll);
				NativeView = ll;


		}

		protected override void Dispose(bool disposing)
		{
			if (videoView != null)
			{
				videoView.StopPlayback();
				videoView = null;
			}
			base.Dispose(disposing);
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			if (NativeView != null)
			{
				var msw = MeasureSpec.MakeMeasureSpec(r - l, Android.Views.MeasureSpecMode.Exactly);
				var msh = MeasureSpec.MakeMeasureSpec(b - t, Android.Views.MeasureSpecMode.Exactly);

				NativeView.Measure(msw, msh);
				NativeView.Layout(0, 0, r - l, b - t);
			}


		}


	}


}

