using CommunityToolkit.Maui.Views;

namespace BUG_Popup_MAUI_Community_Toolkit
{
    public partial class MainPage : ContentPage
    {
        PopupManager mngr;

        public MainPage()
        {
            InitializeComponent();
            mngr = new();
        }

        private async void BtnTRUE_Clicked(object sender, EventArgs e)
        {
            await mngr.ShowOkPopupAsync("Popup with canbedismissed set to FALSE", OkEventHandler, true);
        }

        private async void BtnFALSE_Clicked(object sender, EventArgs e)
        {
            await mngr.ShowOkPopupAsync("Popup with canbedismissed set to FALSE", OkEventHandler, false);
        }

        private void OkEventHandler(object sender, bool result)
        {
            var popup = (Popup)((Element)sender).Parent.Parent;
            popup.Close();
        }

    }
}