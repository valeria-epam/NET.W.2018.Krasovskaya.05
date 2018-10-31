using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class DelegateComparer : IComparer<int[]>
    {
        private readonly Func<int[], int[], int> _compare;

        public DelegateComparer(Func<int[], int[], int> compare)
        {
            _compare = compare ?? throw new ArgumentNullException(nameof(compare));
        }

        public int Compare(int[] x, int[] y) => _compare(x, y);
    }
}