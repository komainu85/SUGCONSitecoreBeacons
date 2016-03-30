using Windows.UI.Xaml.Controls;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShopPage : Page
    {
        public ShopPage()
        {
            this.InitializeComponent();

            LoadVisitedAnimals();
        }

        public async void LoadVisitedAnimals()
        {
            var sitecoreApi = new SitecoreApi();

            var authCookie = await  sitecoreApi.Authenticate();

            var results = await sitecoreApi.GetUserDetails(authCookie, "test@test.com");

            Name.Text = results.FirstName;
        }
    }
}
