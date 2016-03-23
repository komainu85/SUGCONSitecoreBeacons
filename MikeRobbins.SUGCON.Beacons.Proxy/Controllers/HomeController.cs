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
        public ActionResult Index(string redirectUrl)
        {
            redirectUrl = Server.HtmlEncode(redirectUrl);

            var redirectModel = GetRedirectModel(redirectUrl);

            return View(redirectModel);
        }

        private static RedirectModel GetRedirectModel(string redirectUrl)
        {
            var redirectModel = new RedirectModel
            {
                Url = redirectUrl,
                Summary = "Find our more about our "
            };

            switch (redirectUrl)
            {
                case "Tiger":
                    redirectModel.Title = "Tiger";
                    redirectModel.Summary += "Tigers";
                    break;
                case "Fox":
                    redirectModel.Title = "Fox";
                    redirectModel.Summary += "Fox";
                    break;
                case "Giant Panda":
                    redirectModel.Title = "Giant Panda";
                    redirectModel.Summary += "Giant Pandas";
                    break;
                case "Snow Leopard":
                    redirectModel.Title = "Snow Leopard";
                    redirectModel.Summary += "Snow Leopards";
                    break;
                case "Eagle Owl":
                    redirectModel.Title = "Eagle Owl";
                    redirectModel.Summary += "Eagle Owls";
                    break;
            }
            return redirectModel;
        }
    }
}