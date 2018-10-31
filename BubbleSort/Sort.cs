using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort
{
    public static class Sort
    {
        /// <summary>
        /// Sorts the <paramref name="array"/> by the row property returned by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of the row property.</typeparam>
        public static void BubbleSortByRowProperty<T>(this int[][] array, Func<int[], T> selector, Func<T, T, int> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            T[] props = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                props[i] = selector(array[i]);
            }

            for (int i = 0; i < props.Length - 1; i++)
            {
                for (int j = i + 1; j < props.Length; j++)
                {
                    if (comparer(props[i], props[j]) > 0)
                    {
                        Swap(ref props[i], ref props[j]);
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> by row sum.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByRowSum(this int[][] array, bool descending)
        {
            array.BubbleSortByRowProperty(row => row.Sum(x => (long)x), (x, y) => descending ? y.CompareTo(x) : x.CompareTo(y));
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> by max row element.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByMaxRowElement(this int[][] array, bool descending)
        {
            array.BubbleSortByRowProperty(row => row.Max(), (x, y) => descending ? y.CompareTo(x) : x.CompareTo(y));
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> by min row element.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="descending">If <see langword="true" /> the array will be sorted in the descending order.</param>
        public static void BubbleSortByMinRowElement(this int[][] array, bool descending)
        {
            array.BubbleSortByRowProperty(row => row.Min(), (x, y) => descending ? y.CompareTo(x) : x.CompareTo(y));
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> using the <paramref name="comparer"/> to compare elements.
        /// </summary>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the <paramref name="array"/> using the <paramref name="compare"/> delegate to compare elements.
        /// </summary>
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            array.BubbleSort(new DelegateComparer(compare));
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T item = item1;
            item1 = item2;
            item2 = item;
        }
    }
}
