using System.Threading.Tasks;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Contracts
{
    public interface ISitecorePersonService
    {
        Task<Person> GetUserDetailsAsync(string userUniqueIdentifier);
    }
}