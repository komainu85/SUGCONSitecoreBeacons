using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;

namespace MikeRobbins.SUGCON.Beacons.Controllers
{
    public class AnimalsController: SitecoreController
    {
        public ViewResult OurAnimals()
        {
            var datasource = RenderingContext.Current.Rendering.Item;
         
            return View("/Views/Components/AnimalsCTA.cshtml", datasource.Children);
        }

    }
}