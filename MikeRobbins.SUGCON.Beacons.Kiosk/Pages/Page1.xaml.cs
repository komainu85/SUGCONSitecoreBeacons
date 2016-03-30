using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Models;

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
            var sitecoreApi = new SitecoreApi();

            var authCookie = await sitecoreApi.Authenticate();

            var personViewModel = await sitecoreApi.GetUserDetails(authCookie, LoadCurrentUserEmail());

            foreach (var animal in personViewModel.Animals)
            {
                _animals.Add(animal);
            }
        }
    }
}
