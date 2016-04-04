using System.Collections.Generic;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Entities
{
    public class Person
    {
        public string UniqueIdentifier { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
