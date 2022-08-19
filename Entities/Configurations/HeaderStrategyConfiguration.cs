using Smartbills.MultiTenant.Constants;

namespace Smartbills.MultiTenant.Entities.Configurations
{
    public class HeaderStrategyConfiguration
    {
        public string Key { get; set; } = MultiTenantConstants.HEADER_KEY;
        public int Order { get; set; } = 2;
    }
}