using System.Diagnostics;
using Xamarin.Forms;

namespace App21
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            videoView.Loaded += VideoView_Loaded;
            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += Pan_PanUpdated;
            videoView.GestureRecognizers.Add(pan);
            _vm = BindingContext as MainViewModel;
            _vm.Initialize();
        }

        private void Pan_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            Debug.WriteLine("Pan Updated");
        }

        private void VideoView_Loaded(object sender, System.EventArgs e)
        {
           // _vm.MediaPlayer.Play();
            _vm.MediaPlayer.Mute = true;
        }

        void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e) => _vm.OnGesture(e);
    }
}
