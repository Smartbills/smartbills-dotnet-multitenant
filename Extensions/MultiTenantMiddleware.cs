using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Extensions
{
    internal class MultiTenantMiddleware<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        private readonly RequestDelegate next;

        public MultiTenantMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var accessor = context.RequestServices.GetRequiredService<ITenantAccessorService<T, TTenantInfo>>();
            var resolver = context.RequestServices.GetRequiredService<ITenantResolverService<T, TTenantInfo>>();
            var tenantContext = await resolver.ResolveAsync();
            accessor.TenantContext = tenantContext;

            await next(context);
        }
    }

    public static class MultiTenantMiddlewareExtensions
    {
        /// <summary>
        /// Use Finbuckle.MultiTenant middleware in processing the request.
        /// </summary>
        /// <param name="builder">The IApplicationBuilder<c/> instance the extension method applies to.</param>
        /// <returns>The same IApplicationBuilder passed into the method.</returns>
        public static IApplicationBuilder UseMultiTenant<T, TTenantInfo>(this IApplicationBuilder builder) where TTenantInfo : ITenantInfo<T>
            => builder.UseMiddleware<MultiTenantMiddleware<T, TTenantInfo>>();
    }
}
