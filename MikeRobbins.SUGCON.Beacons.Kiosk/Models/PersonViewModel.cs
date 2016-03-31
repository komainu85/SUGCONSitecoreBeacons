﻿using System.Collections.Generic;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Models
{
    public class PersonViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
