using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        private void ContactLookUp_OnClick(object sender, RoutedEventArgs e)
        {
            StoreUserSession(EmailAddress.Text);

            this.Frame.Navigate(typeof (Page1));
        }

        private void StoreUserSession(string emailAddress)
        {
            ((App)Application.Current).CurrentUserEmail = emailAddress;
        }
    }
}
