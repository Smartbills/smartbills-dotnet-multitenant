using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Abtractions
{
    public interface ITenantContext<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        TTenantInfo TenantInfo { get; set; }
        IMultiTenantStrategy<T> Strategy { get; set; }
        public bool IsValidTenant { get; }
    }
}
