using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities.Configurations;
using Smartbills.MultiTenant.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Services
{

    public interface IHeaderStrategy<T> : IMultiTenantStrategy<T> { }
    public class HeaderStrategy<T> : IHeaderStrategy<T>
    {
        private readonly MultiTenantConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public HeaderStrategy(IHttpContextAccessor httpContextAccessor, IOptions<MultiTenantConfiguration> configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration.Value;
        }

        public Task<T?> GetTenantIdAsync()
        {
            var headerExists = _httpContextAccessor.HttpContext?.Request.Headers.TryGetValue(_configuration.HeaderKey, out var values);
            if (headerExists == null || headerExists.Value == false)
            {
                return Task.FromResult<T?>(default(T?));
            }

            var tenantId = values.FirstOrDefault();
            return Task.FromResult(tenantId.To<T?>());
        }
    }
}
