using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MikeRobbins.SUGCON.Beacons.Proxy.Models;

namespace MikeRobbins.SUGCON.Beacons.Proxy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string animalId, string redirectUrl)
        {
            var url = Server.UrlDecode(redirectUrl);

            if (!url.ToLower().StartsWith("http://sugcon/"))
            {
                return new HttpStatusCodeResult(404);
            }

            var redirectModel = GetRedirectModel(animalId, url);

            return View(redirectModel);
        }

        private static RedirectModel GetRedirectModel(string animalId, string redirectUrl)
        {
            var redirectModel = new RedirectModel
            {
                Url = redirectUrl,
                Summary = "Find our more about our "
            };

            switch (animalId.ToLower())
            {
                case "tiger":
                    redirectModel.Title = "Tiger";
                    redirectModel.Summary += "Tigers";
                    break;
                case "fox":
                    redirectModel.Title = "Fox";
                    redirectModel.Summary += "Fox";
                    break;
                case "giantpanda":
                    redirectModel.Title = "Giant Panda";
                    redirectModel.Summary += "Giant Pandas";
                    break;
                case "snowleopard":
                    redirectModel.Title = "Snow Leopard";
                    redirectModel.Summary += "Snow Leopards";
                    break;
                case "eagleowl":
                    redirectModel.Title = "Eagle Owl";
                    redirectModel.Summary += "Eagle Owls";
                    break;
            }
            return redirectModel;
        }
    }
}