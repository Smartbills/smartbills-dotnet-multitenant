using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Entities.Events
{
    public class MultiTenantEvents
    {

        public event EventHandler<TenantResolvedContext> TenantResolved;

        public Func<TenantResolvedContext, Task> OnTenantResolved { get; set; } = context => Task.CompletedTask;
        //protected virtual void OnThresholdReached()
        //{
        //    EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}
    }
}
