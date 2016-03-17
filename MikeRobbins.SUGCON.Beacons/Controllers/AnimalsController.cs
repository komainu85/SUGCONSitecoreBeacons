using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace MikeRobbins.SUGCON.Beacons.Website.Controllers
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