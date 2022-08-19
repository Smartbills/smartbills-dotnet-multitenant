using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartbills.MultiTenant.Extensions;
namespace Smartbills.MultiTenant.Services
{
    public interface IClaimStrategy<T> : IMultiTenantStrategy<T> { }
    public class ClaimStrategy<T> : IClaimStrategy<T> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MultiTenantConfiguration _configuration;
        public ClaimStrategy(IHttpContextAccessor httpContextAccessor, IOptions<MultiTenantConfiguration> configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration.Value;
        }

        public Task<T?> GetTenantIdAsync()
        {
            var tenantClaim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == _configuration.ClaimKey);

            if (tenantClaim == null)
            {
                return Task.FromResult<T?>(default(T?));
            }
            return Task.FromResult(tenantClaim.Value.To<T?>());
        }
    }
}
