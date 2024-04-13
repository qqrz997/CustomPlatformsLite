using System.Collections.Generic;

namespace EnvironmentHelper.Extensions
{
    internal static class ListExtensions
    {
        public static List<T> TryAdd<T>(this List<T> list, T item)
        {
            if (item == null)
            {
                return list;
            }
            else
            {
                list.Add(item);
                return list;
            }
        } 
    }
}
