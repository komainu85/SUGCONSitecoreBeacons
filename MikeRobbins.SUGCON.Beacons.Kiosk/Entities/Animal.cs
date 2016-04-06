using System;
using Windows.UI.Xaml.Media.Imaging;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Entities
{
    public class Animal
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public BitmapImage Image { get; set; }

        public void CreateBitmapImage(string imageUrl)
        {
            Image = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
        }
    }
}
