using System.Threading.Tasks;
using Windows.Web.Http;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Contracts
{
    public interface ISitecoreAuthenticationService
    {
        Task<HttpCookie> AuthenticateAsync();
    }
}