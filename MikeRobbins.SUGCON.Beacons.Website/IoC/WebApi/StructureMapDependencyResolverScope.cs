using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.WebApi
{
    public class StructureMapDependencyResolverScope : IDependencyScope
    {
        private IContainer _container;

        public StructureMapDependencyResolverScope(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (_container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed.");

            return _container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed.");

            return _container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            _container = null;
        }
    }
}