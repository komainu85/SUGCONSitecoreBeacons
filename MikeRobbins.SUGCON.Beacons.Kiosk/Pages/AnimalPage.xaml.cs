using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AnimalPage : Page
    {
        public Animal Animal { get; set; }

        public AnimalPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Animal = (Animal)e.Parameter;
        }
    }
}
