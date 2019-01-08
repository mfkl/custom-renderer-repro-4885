using Xamarin.Forms;
using CustomRenderer;
using CustomRenderer.Platforms.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System;
using LibVLCSharp.Shared;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace CustomRenderer.Platforms.iOS
{
    public class VideoViewRenderer : ViewRenderer<VideoView, IOSVideoView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new IOSVideoView());
            }

            if (e.OldElement != null)
            {
                e.OldElement.MediaPlayerChanged -= OnMediaPlayerChanged;
            }

            if (e.NewElement != null)
            {
                e.NewElement.MediaPlayerChanged += OnMediaPlayerChanged;
            }
        }

        private void OnMediaPlayerChanged(object sender, MediaPlayerChangedEventArgs e)
        {
            Control.MediaPlayer = e.NewMediaPlayer;
        }
    }

    public class IOSVideoView : UIView
    {
        LibVLCSharp.Shared.MediaPlayer _mediaPlayer;

        /// <summary>
        /// The MediaPlayer object attached to this VideoView. Use this to manage playback and more
        /// </summary>
        public LibVLCSharp.Shared.MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                if (_mediaPlayer != value)
                {
                    Detach();
                    _mediaPlayer = value;

                    if (_mediaPlayer != null)
                    {
                        Attach();
                    }
                }
            }
        }

        void Attach()
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.NsObject = Handle;
            }
        }

        void Detach()
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.NsObject = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Detach the mediaplayer from the view and dispose the view
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Detach();
        }
        
    }
}
