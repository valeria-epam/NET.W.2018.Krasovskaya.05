using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort
{
    public class Sort2
    {
        /// <summary>
        /// Sorts the <paramref name="array"/> using the <paramref name="compare"/> delegate to compare elements.
        /// </summary>
        public static void BubbleSort(int[][] array, Func<int[], int[], int> compare)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> using the <paramref name="comparer"/> to compare elements.
        /// </summary>
        public static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            BubbleSort(array, comparer.Compare);
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T item = item1;
            item1 = item2;
            item2 = item;
        }
    }
}
