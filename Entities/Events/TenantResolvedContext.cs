using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities.Events
{
    public class TenantResolvedContext : EventArgs
    {
        //public ITenantInfo? TenantInfo { get; set; }
        public Type? StrategyType { get; set; }
    }
}
