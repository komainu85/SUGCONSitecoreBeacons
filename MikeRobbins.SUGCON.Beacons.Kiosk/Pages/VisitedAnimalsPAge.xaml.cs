using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Intense.UI;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VisitedAnimalsPage : Page
    {
        private readonly ObservableCollection<Animal> _animals = new ObservableCollection<Animal>();

        public VisitedAnimalsPage()
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
                var sitecoreApi = new SitecoreAuthenticationService();

                var authCookie = await sitecoreApi.Authenticate();

                var person = await sitecoreApi.GetUserDetails(authCookie, currentUserEmail);

                StoreUserSession(person);

                foreach (var animal in person.Animals)
                {
                    _animals.Add(animal);
                }
            }
        }

        private void Animal_OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var animalPanel = sender as StackPanel;

            var animal = animalPanel?.DataContext as Animal;

            Frame.Navigate(typeof (AnimalPage), animal);
        }

        private void StoreUserSession(Person person)
        {
            ((App)Application.Current).CurrentPerson = person;
        }
    }
}
