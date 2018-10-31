using System;
using System.Linq;
using BubbleSort;
using NUnit.Framework;

namespace Sort.Tests
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void BubbleSortByRowSum()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 8, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 30 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 8, 2 };
            expected[1] = new int[] { 11, 2, 30 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            numbers.BubbleSortByRowSum(false);

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortByRowSum_Descending()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 8, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 30 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 10, 82, 34, 14, 45 };
            expected[1] = new int[] { 11, 2, 30 };
            expected[2] = new int[] { 8, 2 };

            numbers.BubbleSortByRowSum(true);

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortByMaxRowElement_Descending()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 98, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 130 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 11, 2, 130 };
            expected[1] = new int[] { 98, 2 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            numbers.BubbleSortByMaxRowElement(true);

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortByMinRowElement()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 98, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, -22, 130 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 11, -22, 130 };
            expected[1] = new int[] { 98, 2 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            numbers.BubbleSortByMinRowElement(false);

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSort_ArgumentNullException()
        {
            int[][] numbers = new int[3][];

            Assert.Throws<ArgumentNullException>(() => numbers.BubbleSortByRowSum(false));
        }

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

            numbers.BubbleSort(new MinAscComparer());

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

            numbers.BubbleSort(new SumDscComparer());

            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void BubbleSortByMaxDscWithComparer()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 98, 2 };
            numbers[1] = new int[] { 10, 82, 34, 14, 45 };
            numbers[2] = new int[] { 11, 2, 130 };

            int[][] expected = new int[3][];
            expected[0] = new int[] { 11, 2, 130 };
            expected[1] = new int[] { 98, 2 };
            expected[2] = new int[] { 10, 82, 34, 14, 45 };

            numbers.BubbleSort(new MaxDsccComparer());

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

            numbers.BubbleSort((x, y) => x.Min().CompareTo(y.Min()));

            Assert.AreEqual(expected, numbers);
        }
    }
}