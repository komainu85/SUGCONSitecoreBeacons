using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.Mvc
{
    public class ChainedDependencyResolver : IDependencyResolver
    {
        private readonly IDependencyResolver _wrappedResolver;

        public ChainedDependencyResolver(IDependencyResolver wrappedResolver)
        {
            _wrappedResolver = wrappedResolver;
        }
        
        public object GetService(Type serviceType)
        {
            try
            {
                return _wrappedResolver.GetService(serviceType);
            }
            catch
            {
                return Sitecore.Mvc.Helpers.TypeHelper.CreateObject<IController>(serviceType, new object[0]);
            }

        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _wrappedResolver.GetServices(serviceType);
        }
    }
}