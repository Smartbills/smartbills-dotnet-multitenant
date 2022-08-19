using Smartbills.MultiTenant.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities.Configurations
{
    public class RouteStrategyConfiguration
    {
        public string Key { get; set; } = MultiTenantConstants.ROUTE_KEY;
        public int Order { get; set; } = 0;
    }
}
