using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    public sealed partial class AnimalPage : Page
    {
        public Animal Animal { get; set; }

        public AnimalPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Animal = (Animal)e.Parameter;

            SetDescriptionHtml();
        }

        private void SetDescriptionHtml()
        {
            var html = "<html><body>" + Animal.Description + "</body></html>";

            Description.NavigateToString(html);
        }

        private async void SponsorAnimal_OnClick(object sender, RoutedEventArgs e)
        {
            RegisterGoalAsync(Goal.SponsorAnimal, "Sponsored");

            var dialog = new MessageDialog("You have sponsored");
            await dialog.ShowAsync();
        }

        private async void Shop_OnClick(object sender, RoutedEventArgs e)
        {
            RegisterGoalAsync(Goal.BuyToy, "Toy Bought");

            var dialog = new MessageDialog("Your toy is on it's way, the shop assistant will be with you shortly");
            await dialog.ShowAsync();
        }

        private async void RegisterGoalAsync(Goal goal, string goalText)
        {
            var authCookie = CurrentSession.LoadAuthCookie();

            var goalService = new SitecoreGoalService(authCookie);

            var person = CurrentSession.LoadCurrentPerson();

            await goalService.RegisterGoalAsync(goal, person.UniqueIdentifier, goalText + " " + Animal.Name);
        }
    }
}
