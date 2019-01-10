using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App21
{
    public class VideoView : View
    {
    }
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var view = new VideoView() { BackgroundColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var recog = new PanGestureRecognizer();

            recog.PanUpdated += Recog_PanUpdated;
            view.GestureRecognizers.Add(recog);
            MainPage = new NavigationPage(
                new ContentPage()
                {
                    Content = new StackLayout()
                    {
                        Padding = 20,
                        Children =
                        {
                             view
                        }
                    }
                });
        }

        private void Recog_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            Debug.WriteLine("PanUpdated");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
