using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MikeRobbins.SUGCON.Beacons.Website
{
    public class Global : Sitecore.Web.Application
    {

        protected void Application_Start(object sender, EventArgs e)
        {
          StructureMapResolver.Initialize();
        }
    }
}