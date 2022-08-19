using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Abtractions
{
    public interface ITenantInfoService<T, TTenantInfo> where TTenantInfo : ITenantInfo<T>
    {
        Task<TTenantInfo> GetTenantInfoAsync(T id);
    }
}
