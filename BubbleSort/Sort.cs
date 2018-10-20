using System;
using System.Linq;

namespace BubbleSort
{
    public static class Sort
    {
        /// <summary>
        /// Sorts the <paramref name="array"/> by row sum.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByRowSum(this int[][] array, bool descending)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            long[] sums= new long[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = array[i].Sum(t => (long)t);
            }

            for (int i = 0; i < sums.Length - 1; i++)
            {
                for (int j = i + 1; j < sums.Length; j++)
                {
                    if ((sums[i] > sums[j]) ^ descending)
                    {
                        Swap(ref sums[i], ref sums[j]);
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> by max row element.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByMaxRowElement(this int[][] array, bool descending)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int[] maximum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                maximum[i] = array[i].Max();
            }

            for (int i = 0; i < maximum.Length - 1; i++)
            {
                for (int j = i + 1; j < maximum.Length; j++)
                {
                    if ((maximum[i] > maximum[j]) ^ descending)
                    {
                        Swap(ref maximum[i], ref maximum[j]);
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> by min row element.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByMinRowElement(this int[][] array, bool descending)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int[] minimum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                minimum[i] = array[i].Min();
            }

            for (int i = 0; i < minimum.Length - 1; i++)
            {
                for (int j = i + 1; j < minimum.Length; j++)
                {
                    if ((minimum[i] > minimum[j]) ^ descending)
                    {
                        Swap(ref minimum[i], ref minimum[j]);
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T item = item1;
            item1 = item2;
            item2 = item;
        }
    }
}
