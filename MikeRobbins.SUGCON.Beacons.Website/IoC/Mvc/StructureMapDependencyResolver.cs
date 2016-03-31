using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.Mvc
{
    public class StructureMapDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this._container = container;
        }
        

        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;

            try
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return _container.TryGetInstance(serviceType);
                }
                else
                {
                    return _container.GetInstance(serviceType);
                }
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }


    }
}