using Smartbills.MultiTenant.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities.Configurations
{
    public class MultiTenantConfiguration
    {
        public string HeaderKey { get; set; } = MultiTenantConstants.HEADER_KEY;
        public string ClaimKey { get; set; } = MultiTenantConstants.CLAIM_KEY;
        public string RouteKey { get; set; } = MultiTenantConstants.ROUTE_KEY;
    }
}
