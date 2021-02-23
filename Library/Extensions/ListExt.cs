using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Library.Extensions
{
    public static class ListExt
    {
        public static bool EqualsAll<T>(this List<T> list1, List<T> list2)
        {
            if (list1 == null || list2 == null)
                return (list1 == null && list2 == null);

            if (list1.Count != list2.Count)
                return false;

            return list1.SequenceEqual(list2);
        }

        public static T Random<T>(this List<T> list)
        {
            var random = new System.Random(Guid.NewGuid().GetHashCode());
            return list[random.Next(0, list.Count())];
        }
    }
}
