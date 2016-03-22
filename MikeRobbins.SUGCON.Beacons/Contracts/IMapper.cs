using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Contracts
{
    public interface IMapper
    {
        Person MapPerson(Contact contact);
    }
}
