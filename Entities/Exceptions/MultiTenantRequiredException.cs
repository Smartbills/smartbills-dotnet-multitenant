using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities.Exceptions
{
    public class MultiTenantRequiredException : Exception
    {
        public MultiTenantRequiredException() : base("No valid tenant id was not found in the request")
        {

        }
    }
}
