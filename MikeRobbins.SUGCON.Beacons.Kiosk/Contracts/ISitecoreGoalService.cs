using System.Threading.Tasks;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Contracts
{
    public interface ISitecoreGoalService
    {
        Task RegisterGoalAsync(Goal goal, string userUniqueIdentifier, string goalText);
    }
}