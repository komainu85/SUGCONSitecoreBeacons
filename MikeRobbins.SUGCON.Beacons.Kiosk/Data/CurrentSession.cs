using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Data
{
    public static class CurrentSession
    {
        public static Person LoadCurrentPerson()
        {
            return ((App)Application.Current).CurrentPerson;
        }

        public static void StorePerson(Person person)
        {
            ((App)Application.Current).CurrentPerson = person;
        }

        public static void StoreAuthCookie(HttpCookie authCookie)
        {
            ((App)Application.Current).AuthCookie = authCookie;
        }

        public static HttpCookie LoadAuthCookie()
        {
            return ((App)Application.Current).AuthCookie;
        }
    }
}
