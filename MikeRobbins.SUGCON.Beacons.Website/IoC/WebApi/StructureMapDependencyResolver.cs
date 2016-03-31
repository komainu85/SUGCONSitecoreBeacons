using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC.WebApi
{
    public class StructureMapDependencyResolver : StructureMapDependencyResolverScope, IDependencyResolver, IHttpControllerActivator
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;

            _container.Inject(typeof(IHttpControllerActivator), this);
        }

        public IDependencyScope BeginScope()
        {
            return new StructureMapDependencyResolverScope(_container.GetNestedContainer());
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return _container.GetNestedContainer().GetInstance(controllerType) as IHttpController;
        }
    }
}