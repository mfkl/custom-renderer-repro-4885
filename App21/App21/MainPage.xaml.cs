using System.Diagnostics;
using Xamarin.Forms;

namespace App21
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += Pan_PanUpdated;
            videoView.GestureRecognizers.Add(pan);
        }

        private void Pan_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            Debug.WriteLine("Pan Updated");
        }

        private void VideoView_Loaded(object sender, System.EventArgs e)
        {
            
        }
    }
}