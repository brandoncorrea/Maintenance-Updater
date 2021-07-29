using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance_Updater.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        ///     Returns the index of the first item that satisfies the predicate
        /// </summary>
        public static int FindIndex<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int index = 0;
            foreach (var item in collection)
            {
                if (predicate(item)) return index;
                index++;
            }

            return -1;
        }
    }
}
