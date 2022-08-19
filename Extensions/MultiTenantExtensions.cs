using Microsoft.Extensions.DependencyInjection;
using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities.Configurations;
using Smartbills.MultiTenant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Extensions
{
    public static class MultiTenantExtensions
    {
        public static MultiTenantBuilder<T, TTenantInfo> AddMultiTenancy<T, TTenantInfo>(this IServiceCollection services, Action<MultiTenantConfiguration>? configuration = null) where TTenantInfo : ITenantInfo<T>
        {
            MultiTenantBuilder<T, TTenantInfo> builder = new(services, configuration);
            return builder;
        }

    }

    public  class MultiTenantBuilder<T, TTenantInfo> where TTenantInfo: ITenantInfo<T>
    {
        private readonly IServiceCollection _services = new ServiceCollection();
        public MultiTenantBuilder(IServiceCollection services, Action<MultiTenantConfiguration>? configuration = null)
        {
            _services = services;
            _services.Configure(configuration ?? (config => new MultiTenantConfiguration()));
            _services.AddTransient<ITenantResolverService<T, TTenantInfo>, TenantResolverService<T, TTenantInfo>>();
            _services.AddScoped<ITenantAccessorService<T,TTenantInfo>, TenantAccessorService<T, TTenantInfo>>();
        }

        public MultiTenantBuilder<T, TTenantInfo> WithStrategy<TStrategy>() where TStrategy:class, IMultiTenantStrategy<T>
        {
            _services.AddTransient<IMultiTenantStrategy<T>, TStrategy>();
            return this;
        }

        public MultiTenantBuilder<T,TTenantInfo> WithRouteStrategy()
        {
            _services.AddTransient<IMultiTenantStrategy<T>, RouteStrategy<T>>();
            return this;
        }

        public MultiTenantBuilder<T,TTenantInfo> WithClaimStrategy()
        {
            _services.AddTransient<IMultiTenantStrategy<T>, ClaimStrategy<T>>();
            return this;
        }
        public MultiTenantBuilder<T,TTenantInfo> WithHeaderStrategy()
        {
            _services.AddTransient<IMultiTenantStrategy<T>, HeaderStrategy<T>>();
            return this;
        }

        public MultiTenantBuilder<T,TTenantInfo> WithTenantInfoService<TService>() where TService : class, ITenantInfoService<T, TTenantInfo>
        {
            _services.AddTransient<ITenantInfoService<T, TTenantInfo>, TService>();
            return this;
        }
    }

}
