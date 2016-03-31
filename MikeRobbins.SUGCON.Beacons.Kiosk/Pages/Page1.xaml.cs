using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using SitecoreApi = MikeRobbins.SUGCON.Beacons.Kiosk.Services.SitecoreApi;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        private readonly ObservableCollection<Animal> _animals = new ObservableCollection<Animal>();

        public Page1()
        {
            this.InitializeComponent();

            LoadVisitedAnimals();
        }

        private string LoadCurrentUserEmail()
        {
            return ((App)Application.Current).CurrentUserEmail;
        }

        public async void LoadVisitedAnimals()
        {
            var currentUserEmail = LoadCurrentUserEmail();

            if (!string.IsNullOrEmpty(currentUserEmail))
            {
                var sitecoreApi = new SitecoreApi();

                var authCookie = await sitecoreApi.Authenticate();

                var personViewModel = await sitecoreApi.GetUserDetails(authCookie, currentUserEmail);

                foreach (var animal in personViewModel.Animals)
                {
                    _animals.Add(animal);
                }
            }
        }
    }
}
