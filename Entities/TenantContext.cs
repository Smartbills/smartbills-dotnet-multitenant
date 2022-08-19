using Smartbills.MultiTenant.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities
{
    public class TenantContext<T, TTenantInfo> : ITenantContext<T,TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        public TTenantInfo TenantInfo { get; set; }
        public IMultiTenantStrategy<T> Strategy { get; set; }

        public bool IsValidTenant => TenantInfo != null;

        public TenantContext(TTenantInfo tenantInfo, IMultiTenantStrategy<T> strategy)
        {
            TenantInfo = tenantInfo;
            Strategy = strategy;
        }
    }
}
