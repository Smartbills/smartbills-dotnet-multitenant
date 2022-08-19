using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Abtractions
{
    public interface IMultiTenantStrategy<T> 
    {
        public Task<T?> GetTenantIdAsync();
    }
}
