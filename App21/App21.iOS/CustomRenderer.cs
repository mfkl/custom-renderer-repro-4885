using App21;
using App21.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace App21.iOS
{
    public class VideoViewRenderer : ViewRenderer<VideoView, IOSVideoView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);

            SetNativeControl(new IOSVideoView());
        }
    }

    public class IOSVideoView : UIView
    {
    }
}