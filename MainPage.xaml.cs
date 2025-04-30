using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace CarouselViewBug
{
    public partial class MainPage : ContentPage
    {
        readonly MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            _vm = (MainViewModel)BindingContext;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "Tapped event fired.";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
