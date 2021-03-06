﻿using System.Linq;
using BubbleSort;
using NUnit.Framework;

namespace Sort.Tests
{
    [TestFixture]
    public class Sort2Tests
    {
        [Test]
        public void BubbleSortByMinAscWithComparer()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 8, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 30 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 8, 2 };
            expected[1] = new int[] { 11, 2, 30 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            Sort2.BubbleSort(numbers, new MinAscComparer());

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortBySumDscWithComparer()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 8, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 30 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 10, 82, 34, 14, 45 };
            expected[1] = new int[] { 11, 2, 30 };
            expected[2] = new int[] { 8, 2 };

            Sort2.BubbleSort(numbers, new SumDscComparer());

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortDelegateByMinAsc()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 8, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 30 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 8, 2 };
            expected[1] = new int[] { 11, 2, 30 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            Sort2.BubbleSort(numbers, (x, y) => x.Min().CompareTo(y.Min()));

            Assert.AreEqual(expected, numbers);
        }
    }
}