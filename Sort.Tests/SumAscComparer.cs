using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.Tests
{
    public class SumAscComparer : IComparer<int[]>
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

            return x.Sum(t => (long)t).CompareTo(y.Sum(t => (long)t));
        }
    }
}
