using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbills.MultiTenant.Extensions
{
    public static class GenericUtils
    {
        public static T? To<T>(this IConvertible obj)
        {
            try
            {
                Type t = typeof(T?);
                Type u = Nullable.GetUnderlyingType(t);

                if (u != null)
                {
                    return (obj == null) ? default(T?) : (T?)Convert.ChangeType(obj, u);
                }
                else
                {
                    return (T?)Convert.ChangeType(obj, t);
                }
            }
            catch {
                return default(T?);
            }
        }
    }
}
