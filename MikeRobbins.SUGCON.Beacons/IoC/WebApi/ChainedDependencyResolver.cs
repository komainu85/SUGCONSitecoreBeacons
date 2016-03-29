using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.WebApi
{
    public class ChainedDependencyResolver : ChainedDependencyScope, IDependencyResolver
    {
        public ChainedDependencyResolver(IDependencyResolver newResolver, IDependencyResolver currentResolver)
            : base(newResolver, currentResolver)
        {
            _newResolver = newResolver;
            _fallbackResolver = currentResolver;
        }

        public IDependencyScope BeginScope()
        {
            return new ChainedDependencyScope(_newResolver, _fallbackResolver);
        }

    }
}