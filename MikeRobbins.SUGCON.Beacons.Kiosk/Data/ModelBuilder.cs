using System.Collections.Generic;
using System.Linq;
using Windows.Data.Json;
using MikeRobbins.SUGCON.Beacons.Kiosk.Models;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Data
{
    public class ModelBuilder
    {
        public PersonViewModel CreatePersonViewModel(string jsonString)
        {
            var root = JsonValue.Parse(jsonString).GetObject();

            var personalViewModel = new PersonViewModel()
            {
                FirstName = root.GetNamedString("FirstName"),
                Surname = root.GetNamedString("Surname"),
                Animals = GetAnimals(root).ToList()
            };

            return personalViewModel;
        }

        private IEnumerable<Animal> GetAnimals(JsonObject root)
        {
            var animals = root.GetNamedArray("Animals");

            for (uint i = 0; i < animals.Count; i++)
            {
                yield return new Animal()
                {
                    Name = animals.GetObjectAt(i).GetNamedString("Name")
                };
            }
        }
    }
}