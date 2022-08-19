using Smartbills.MultiTenant.Abtractions;
using Smartbills.MultiTenant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Services
{
    public interface ITenantAccessorService<T, TTenantInfo> where TTenantInfo: ITenantInfo<T>{

        public ITenantContext<T,TTenantInfo>? TenantContext { get; set; } 
        public bool HasTenant { get;  }

    }
    public class TenantAccessorService<T, TTenantInfo> : ITenantAccessorService<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        public ITenantContext<T, TTenantInfo>? TenantContext { get; set; } = null;
        public bool HasTenant => TenantContext != null;
    }
}
