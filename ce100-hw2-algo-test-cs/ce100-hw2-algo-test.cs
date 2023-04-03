global using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeapSort;

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