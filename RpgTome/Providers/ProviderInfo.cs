using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Features.Indexed;

namespace RpgTome.Providers
{
    public class ProviderInfo
    {
        public static IProviderInfo<T> For<T>(IComponentContext componentContext)
        {
            var keyNames = componentContext.ComponentRegistry.Registrations
                .SelectMany(c=> c.Services)
                .OfType<KeyedService>()
                .Where(s => s.ServiceType == typeof(T))
                .Select(s => (string)s.ServiceKey)
                .ToList();

            return new ProviderInfoImpl<T>(keyNames, componentContext.Resolve<IIndex<string, Lazy<T>>>());
        }

        class ProviderInfoImpl<T> : IProviderInfo<T>
        {
            private readonly IIndex<string, Lazy<T>> mFactory;

            public ProviderInfoImpl(IEnumerable<string> keyNames, IIndex<string, Lazy<T>> factory)
            {
                this.mFactory = factory;
                Keys = keyNames;
            }

            public IEnumerable<string> Keys { get; private set; }

            public T GetProviderByName(string key)
            {
                return mFactory[key].Value;
            }
        }
    }
}