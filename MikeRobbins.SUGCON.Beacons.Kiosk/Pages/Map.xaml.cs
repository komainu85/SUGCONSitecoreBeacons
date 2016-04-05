using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        public Map()
        {
            this.InitializeComponent();

            SetMap();
        }

        private void SetMap()
        {
            var cityPosition = new BasicGeoposition() { Latitude = 55.6381385, Longitude = 12.5764086 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl.Center = cityCenter;
            MapControl.ZoomLevel = 12;
            MapControl.LandmarksVisible = true;
        }
    }
}
