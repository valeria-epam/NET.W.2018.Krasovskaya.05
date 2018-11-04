using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class DelegateComparer : IComparer<int[]>
    {
        private readonly Func<int[], int[], int> _compare;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateComparer"/> class.
        /// </summary>
        public DelegateComparer(Func<int[], int[], int> compare)
        {
            _compare = compare ?? throw new ArgumentNullException(nameof(compare));
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        public int Compare(int[] x, int[] y) => _compare(x, y);
    }
}