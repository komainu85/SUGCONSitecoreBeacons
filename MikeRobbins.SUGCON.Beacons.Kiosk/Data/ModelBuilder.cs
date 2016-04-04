using System.Collections.Generic;
using System.Linq;
using Windows.Data.Json;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using MikeRobbins.SUGCON.Beacons.Kiosk.ViewModels;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Data
{
    public class ModelBuilder
    {
        public Person CreatePersonViewModel(string jsonString)
        {
            var root = JsonValue.Parse(jsonString).GetObject();

            var personalViewModel = new Person()
            {
                FirstName = root.GetNamedString("FirstName"),
                Surname = root.GetNamedString("Surname"),
                UniqueIdentifier = root.GetNamedString("Id"),
                Animals = GetAnimals(root).ToList()
            };

            return personalViewModel;
        }

        private IEnumerable<Animal> GetAnimals(JsonObject root)
        {
            var animals = root.GetNamedArray("Animals");

            for (uint i = 0; i < animals.Count; i++)
            {
                var animal = new Animal()
                {
                    Name = animals.GetObjectAt(i).GetNamedString("Name"),
                };

                animal.CreateBitmapImage(animals.GetObjectAt(i).GetNamedString("ImageUrl"));

                yield return animal;
            }
        }
    }
}