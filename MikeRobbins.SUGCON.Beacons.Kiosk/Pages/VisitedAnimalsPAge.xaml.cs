using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Pages
{
    public sealed partial class VisitedAnimalsPage : Page
    {
        private readonly ObservableCollection<Animal> _animals = new ObservableCollection<Animal>();

        public VisitedAnimalsPage()
        {
            this.InitializeComponent();

            LoadVisitedAnimals();
        }

        public void LoadVisitedAnimals()
        {
            var currentPerson = GetCurrentPerson();

            if (currentPerson !=null)
            { 
                foreach (var animal in currentPerson.Animals)
                {
                    _animals.Add(animal);
                }
            }
        }

        private Person GetCurrentPerson()
        {
            return ((App)Application.Current).CurrentPerson;
        }

        private void Animal_OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var animalPanel = sender as StackPanel;

            var animal = animalPanel?.DataContext as Animal;

            Frame.Navigate(typeof (AnimalPage), animal);
        }
    }
}
