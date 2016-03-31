using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.WebApi
{
    public class ChainedDependencyScope : IDependencyScope
    {
        protected IDependencyResolver _fallbackResolver;
        protected IDependencyResolver _newResolver;

        public ChainedDependencyScope(IDependencyResolver newResolver, IDependencyResolver fallbackResolver)
        {
            _newResolver = newResolver;
            _fallbackResolver = fallbackResolver;
        }

        public object GetService(Type serviceType)
        {
            var result = _newResolver.GetService(serviceType);

            return result ?? _fallbackResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var result = _newResolver.GetServices(serviceType).ToList();

            return result.Any() ? result : _fallbackResolver.GetServices(serviceType);
        }

        public void Dispose()
        {
            try
            {
                _newResolver.Dispose();
            }
            catch
            {
            }

            try
            {
                _fallbackResolver.Dispose();
            }
            catch
            {
            }
        }
    }
}