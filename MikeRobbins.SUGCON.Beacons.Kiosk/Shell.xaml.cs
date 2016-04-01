using System.Linq;
using Windows.UI.Xaml.Controls;
using Intense.Presentation;
using MikeRobbins.SUGCON.Beacons.Kiosk.Pages;
using MikeRobbins.SUGCON.Beacons.Kiosk.ViewModels;

namespace MikeRobbins.SUGCON.Beacons.Kiosk
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            this.InitializeComponent();

            var vm = new ShellViewModel();
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Account login", PageType = typeof(WelcomePage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Visited Animals", PageType = typeof(VisitedAnimalsPage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Zoo Map", PageType = typeof(Map) });

            vm.BottomItems.Add(new NavigationItem { Icon = "", DisplayName = "Settings", PageType = typeof(SettingsPage) });

            // select the first top item
            vm.SelectedItem = vm.TopItems.First();

            this.ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame
        {
            get
            {
                return this.Frame;
            }
        }
    }
}
