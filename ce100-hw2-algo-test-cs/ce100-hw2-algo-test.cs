global using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeapSort;
using LCS;

namespace HeapSort
{
    /// <summary>
    /// In this scenario we are trying to sort an almost sorted int string. In this way, we can see the best method.
    /// </summary>

    [TestClass]
    public class BestHeapSortTestClass
    {
        [TestMethod]
        public void HeapSortTest()
        {


            int[] data = new int[1000];
            int[] data2 = new int[1000];
            Random random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(0, 1000);
            }

            Array.Sort(data);

            Random random2 = new Random();
            for (int i = 5000; i < data2.Length - 4000; i++)
            {
                data[i] = random.Next(0, 10000);
            }

            for (int i = 0; i < data2.Length - 5000; i++)
            {
                data[i] = random.Next(0, 10000);
            }


            int[] result = HeapSortClass.HeapSort(data, data2 ,true);


            int[] expected = (int[])data.Clone();
            Array.Sort(expected);

            CollectionAssert.AreEqual(expected, result);

        }
    }

    /// <summary>
    /// In this scenario we are trying to sort a mixed int string.
    /// In this way, we can see the average method.
    /// </summary>

    [TestClass]
    public class AverageHeapSortTestClass
    {
        [TestMethod]
        public void HeapSortTest()
        {

            int[] data = new int[1000];
            int[] data2 = new int[1000];
            Random random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(0, 1000);
            }

            int[] result = HeapSortClass.HeapSort(data, data2 ,true);

            int[] expected = (int[])data.Clone();
            Array.Sort(expected);

            CollectionAssert.AreEqual(expected, result);

        }
    }

    /// <summary>
    /// In this scenario we are trying to sort a reverse sorted int string.
    /// In this way, we can see the worst method.
    /// </summary>

    [TestClass]
    public class WorstHeapSortTestClass
    {
        [TestMethod]
        public void HeapSortTest()
        {

            int[] data = new int[1000];
            int[] data2 = new int[1000];
            Random random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(1000);
            }

            Array.Sort(data);
            Array.Reverse(data);


            int[] result = HeapSortClass.HeapSort(data, data2 ,true);
            Array.Sort(result);


            int[] expected = (int[])data.Clone();
            Array.Sort(expected);

            CollectionAssert.AreEqual(expected, result);

        }
    }

}

namespace LCS
{
    /// <summary>
    /// In this scenario we find the longest common substring of the same two string arrays, so we see the best method.
    /// </summary>

    [TestClass]
    public class BestLCSTestClass
    {
        [TestMethod]
        public void LCSTest()
        {

            string[] X = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };

            string[] Y = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };


            int expected = 100;

            int result = LCSClass.lcs(X, Y ,true);

            Assert.AreEqual(expected, result);

        }
    }

    /// <summary>
    /// In this scenario we find the longest common substring of two mixed string arrays, so we see the average method.
    /// </summary>

    [TestClass]
    public class AverageLCSTestClass
    {
        [TestMethod]
        public void LCSTest()
        {

            string[] X = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };

            string[] Y = { "p", "v", "t", "f", "c", "z", "n", "o", "k", "s", "y", "j", "x", "a", "b", "w", "m", "h", "u", "e", "l", "q", "i", "r", "g", "e",
            "l", "c", "u", "n", "h", "t", "b", "x", "v", "w", "i", "p", "k", "q", "m", "y", "j", "a", "f", "z", "d", "o", "s", "r", "v", "s",
            "z", "u", "j", "n", "d", "w", "o", "a", "e", "l", "q", "r", "t", "y", "c", "k", "m", "f", "h", "i", "x", "b", "p", "y", "q", "b",
            "r", "c", "f", "e", "x", "k", "z", "u", "v", "n", "w", "s", "m", "a", "p", "o", "p", "r", "s", "t", "u", "v" };



            int expected = 38;

            int result = LCSClass.lcs(X, Y ,true);

            Assert.AreEqual(expected, result);

        }
    }

    /// <summary>
    /// In this scenario, we find the longest common substring of two strings with different letters, so we see the worst method.
    /// </summary>

    [TestClass]
    public class WorstLCSTestClass
    {
        [TestMethod]
        public void LCSTest()
        {

            string[] X = { "b", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "b", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "b", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "b", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };

            string[] Y = {"a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a"};

            int expected = 0;

            int result = LCSClass.lcs(X, Y, true);

            Assert.AreEqual(expected, result);

        }
    }
}

namespace KnapSack
{
    /// <summary>
    /// In this scenario, we see a test in the knapSack function where the capacity is less than the weights, thus the best method.
    /// </summary>

    [TestClass]
    public class BestKnapSackTestClass
    {
        [TestMethod]
        public void KnapSacktTest()
        {

            int[] value = { 400, 300, 100, 100, 200, 500, 350, 800, 250, 1000 };
            int[] weight = { 10, 20, 30, 25, 15, 50, 45, 70, 60, 90 };
            int capacity = 50;
            int itemsCount = weight.Length;

            int result = KnapSackClass.KnapSack(capacity, weight, value, itemsCount, true);

            int expected = 900;

            Assert.AreEqual(expected, result);
        }
    }

    /// <summary>
    /// In this scenario we see a test where the capacity is mixed in the knapSack function, so we see the average method.
    /// </summary>

    [TestClass]
    public class AverageKnapSackTestClass
    {
        [TestMethod]
        public void KnapSacktTest()
        {

            int[] value = { 400, 300, 100, 100, 200, 500, 350, 800, 250, 1000 };
            int[] weight = { 10, 20, 30, 25, 15, 50, 45, 70, 60, 90 };
            int capacity = 300;
            int itemsCount = weight.Length;

            int result = KnapSackClass.KnapSack(capacity, weight, value, itemsCount, true);

            int expected = 3550;

            Assert.AreEqual(expected, result);
        }
    }

    /// <summary>
    /// In this scenario, we see a test where the capacity is more than the total weights in the knapSack function, so we see the worst method.
    /// </summary>

    [TestClass]
    public class WorstKnapSackTestClass
    {
        [TestMethod]
        public void KnapSacktTest()
        {

            int[] value = { 400, 300, 100, 100, 200, 500, 350, 800, 250, 1000 };
            int[] weight = { 10, 20, 30, 25, 15, 50, 45, 70, 60, 90 };
            int capacity = 400;
            int itemsCount = weight.Length;

            int result = KnapSackClass.KnapSack(capacity, weight, value, itemsCount ,true);

            int expected = 3900;

            Assert.AreEqual(expected, result);
        }
    }
}