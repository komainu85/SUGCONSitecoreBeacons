using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MikeRobbins.SUGCON.Beacons.Proxy.Models
{
    public class RedirectModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }
    }
}