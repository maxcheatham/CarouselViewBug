using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace CarouselViewBug
{
    public partial class MainPage : ContentPage
    {
        readonly MainViewModel _vm;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            _vm = (MainViewModel)BindingContext;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            _vm.ModifyItemsSource();

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "This is a Toast";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
