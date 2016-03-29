using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC
{
    public class SitecoreDependencyResolver : IDependencyResolver
    {

        private IDependencyResolver wrappedResolver;

        public SitecoreDependencyResolver(IDependencyResolver wrappedResolver)
        {
            this.wrappedResolver = wrappedResolver;
        }
        
        public object GetService(Type serviceType)
        {
            try
            {
                return this.wrappedResolver.GetService(serviceType);
            }
            catch
            {
                return Sitecore.Mvc.Helpers.TypeHelper.CreateObject<IController>(serviceType, new object[0]);
            }

        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.wrappedResolver.GetServices(serviceType);
        }

    }
}