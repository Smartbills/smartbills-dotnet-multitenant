using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities.Configurations;
using System.ComponentModel;
using Smartbills.MultiTenant.Extensions;
namespace Smartbills.MultiTenant.Services
{

    public interface IRouteStrategy<T> : IMultiTenantStrategy<T> { }
    public class RouteStrategy<T> : IRouteStrategy<T>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MultiTenantConfiguration _configuration;
        public RouteStrategy(IHttpContextAccessor httpContextAccessor, IOptions<MultiTenantConfiguration> configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration.Value;
        }

        public Task<T?> GetTenantIdAsync()
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            var valueExists = routeData.Values.TryGetValue(_configuration.RouteKey, out object tenantIdObject);
            var tenantId = tenantIdObject as string;
            if (!valueExists)
            {
                return Task.FromResult<T?>(default(T?));
            }
            return Task.FromResult(tenantId.To<T?>());
        }
    }
}