using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppCore
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this IList<T> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }

            int randomIndex = UnityEngine.Random.Range(0, count);

            return list[randomIndex];
        }

        public static T GetAndRemove<T>(this IList<T> list, int index)
        {
            var itemReturned = list[index];

            list.RemoveAt(index);

            return itemReturned;
        }

        public static T GetRandomAndRemove<T>(this IList<T> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }

            int randomIndex = UnityEngine.Random.Range(0, count);

            return GetAndRemove(list, randomIndex);
        }

        public static T GetFirstAndRemove<T>(this IList<T> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }

            return GetAndRemove(list, 0);
        }

        public static T GetLastAndRemove<T>(this IList<T> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }

            int lastIndex = count - 1;

            return GetAndRemove(list, lastIndex);
        }

        public static void Shuffle<T>(this IList<T> list) 
        {
            List<T> tmpContainer = new List<T>();

            tmpContainer.AddRange(list);

            list.Clear();

            while (tmpContainer.Count != 0)
                list.Add(tmpContainer.GetRandomAndRemove());
        }
    }
}
