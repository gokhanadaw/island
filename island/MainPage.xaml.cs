using Microsoft.Maui.Controls;
namespace island
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnMenuButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

    }

}
