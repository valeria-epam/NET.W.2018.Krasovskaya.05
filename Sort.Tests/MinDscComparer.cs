﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.Tests
{
    public class MinDsccComparer : IComparer<int[]>
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

            return y.Min().CompareTo(x.Min());
        }
    }
}
