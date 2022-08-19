using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Constants
{
    public class MultiTenantConstants
    {
        public const string HEADER_KEY = "x-tenant-id";
        public const string CLAIM_KEY = "tenant_id";
        public const string ROUTE_KEY = "tenant_id";
    }
}
