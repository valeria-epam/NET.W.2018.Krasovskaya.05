using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.Tests
{
    public class SumDscComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return y.Sum(t => (long)t).CompareTo(x.Sum(t => (long)t));
        }
    }
}
