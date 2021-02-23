using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Library.Extensions
{
    public static class RandomExt
    {
        public static KeyValuePair<T1, T2> GetRandom<T1, T2>(this Random random, Dictionary<T1, T2> dictionary)
        {
            return dictionary.ElementAt(random.Next(0, dictionary.Count()));
        }

        public static T GetRandom<T>(this Random random, List<T> list)
        {
            return list[random.Next(0, list.Count())];
        }

        public static T GetRandomEnum<T>(this Random random)
        {
            return (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[random.Next(0, Enum.GetNames(typeof(T)).Count())]);
        }

        public static T GetRandomEnum<T>(this Random random, List<T> ignoreList)
        {
            List<string> names = new List<string>();

            if (ignoreList == null)
            {
                names = Enum.GetNames(typeof(T)).ToList();
            }
            else
            {
                foreach (T value in Enum.GetValues(typeof(T)))
                    if (ignoreList.Contains(value) == false)
                        names.Add(value.ToString());
            }

            return (T)Enum.Parse(typeof(T), names[random.Next(0, names.Count())]);
        }
    }
}
