using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities;

namespace Smartbills.MultiTenant.Services
{

    public interface ITenantResolverService<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        Task<ITenantContext<T, TTenantInfo>?> ResolveAsync();
    }
    public class TenantResolverService<T, TTenantInfo> : ITenantResolverService<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        private readonly IEnumerable<IMultiTenantStrategy<T>> _strategies;
        private readonly ITenantInfoService<T, TTenantInfo> _tenantInfoService;
        public TenantResolverService(IEnumerable<IMultiTenantStrategy<T>> strategies, ITenantInfoService<T, TTenantInfo> tenantInfoService)
        {
            _strategies = strategies;
            _tenantInfoService = tenantInfoService;
        }

        public async Task<ITenantContext<T, TTenantInfo>?> ResolveAsync()
        {
            ITenantContext<T,TTenantInfo>? result = null;

            foreach (var strategy in _strategies)
            {
                var identifier = await strategy.GetTenantIdAsync();


                if (identifier != null)
                {
                    Type type = strategy.GetType();
                    var tenantInfo = await _tenantInfoService.GetTenantInfoAsync(identifier);
                    result = new TenantContext<T, TTenantInfo>(tenantInfo, strategy);
                    break;

                }
                if (result != null)
                    break;
            }
            return result;
        }
    }
}
