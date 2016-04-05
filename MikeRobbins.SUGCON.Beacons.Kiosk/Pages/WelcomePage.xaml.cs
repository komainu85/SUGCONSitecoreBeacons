using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MikeRobbins.SUGCON.Beacons.Kiosk.Contracts;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    public sealed partial class WelcomePage : Page
    {
        private readonly ISitecoreAuthenticationService _sitecoreAuthenticationService;

        public WelcomePage()
        {
            this.InitializeComponent();
            _sitecoreAuthenticationService = new SitecoreAuthenticationService();
        }

        private async void ContactLookUp_OnClick(object sender, RoutedEventArgs e)
        {
            await AuthenticateUser();
            await LoadPersonDetails();

            this.Frame.Navigate(typeof(VisitedAnimalsPage));
        }

        public async Task AuthenticateUser()
        {
            if (!string.IsNullOrEmpty(EmailAddress.Text))
            {
                var authCookie = await _sitecoreAuthenticationService.AuthenticateAsync();
                CurrentSession.StoreAuthCookie(authCookie);
            }
        }

        public async Task LoadPersonDetails()
        {
            if (!string.IsNullOrEmpty(EmailAddress.Text))
            {
                var authCookie = CurrentSession.LoadAuthCookie();
                var personService = new SitecorePersonService(authCookie);
                var person = await personService.GetUserDetailsAsync(EmailAddress.Text);

                CurrentSession.StorePerson(person);
            }
        }
    }
}
