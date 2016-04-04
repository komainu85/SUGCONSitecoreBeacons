using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services;

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
                var sitecoreApi = new SitecoreAuthenticationService();

                var authCookie = await sitecoreApi.AuthenticateAsync();
                StoreAuthCookie(authCookie);
            }
        }

        public async Task LoadPersonDetails()
        {
            if (!string.IsNullOrEmpty(EmailAddress.Text))
            {
                var authCookie = GetAuthCookie();
                var personService = new SitecorePersonService(authCookie);
                var person = await personService.GetUserDetailsAsync(EmailAddress.Text);

                StorePerson(person);
            }
        }

        private void StoreAuthCookie(HttpCookie authCookie)
        {
            ((App)Application.Current).AuthCookie = authCookie;
        }

        private void StorePerson(Person person)
        {
            ((App)Application.Current).CurrentPerson = person;
        }

        private HttpCookie GetAuthCookie()
        {
            return ((App)Application.Current).AuthCookie;
        }
    }
}
