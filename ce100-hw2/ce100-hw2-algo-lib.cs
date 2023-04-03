using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public static class HeapSortClass
    {
        /// <summary>
        /// In this code you see the Heap Sort Algorithm. Generally speaking, a sorting algorithm that follows the binary tree method consists of two stages. In the first stage, 
        /// the function we call heapfify finds the minimum element in the unordered array and puts it at the beginning of the string.
        /// 
        /// After that, HeapSort this min element changes with the last element and a continuous loop is obtained.
        /// When we look at it normally, we can also call it the deletion method to pass the last element.
        /// In this way, the unordered string is sorted with the heapfify and heapsort pair.
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="outputArray"></param>
        /// <returns></returns>
        /// 
        public static int[] HeapSort(int[] inputArray, int[] outputArray, bool enableDebug = false)
        {
            outputArray = new int[inputArray.Length];
            inputArray.CopyTo(outputArray, 0);
            int size = outputArray.Length;
            int middle = size / 2;

            for (int i = middle - 1; i >= 0; i--)
                Heapify(outputArray, size, i);


            for (int i = size - 1; i >= 0; i--)
            {

                int change = outputArray[0];
                outputArray[0] = outputArray[i];
                outputArray[i] = change;

                if (enableDebug)
                {
                    System.Diagnostics.Debug.WriteLine("Swapping elements: {0} and {1}", outputArray[0], outputArray[i]);
                }

                Heapify(outputArray, i, 0);
            }

            return outputArray;
        }
        /// <summary>
        /// It finds the smallest element in an unordered array, thanks to the binary tree, and puts it at the 0th of the array, that is, at the top of the order.
        /// The parent and childs variables play an important role in the binary tree algorithm.After they are compared among themselves, 
        /// they are compared with the parent and constantly go up.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        /// <param name="parent"></param>
        private static void Heapify(int[] inputArray, int size, int parent, bool enableDebug = false)
        {
            int minimum = parent;
            int left = 2 * parent + 1; //left child
            int right = 2 * parent + 2; //right child

            if (left < size && inputArray[left] > inputArray[minimum])
                minimum = left;

            if (right < size && inputArray[right] > inputArray[minimum])
                minimum = right;


            if (minimum != parent)
            {

                int change = inputArray[parent];
                inputArray[parent] = inputArray[minimum];
                inputArray[minimum] = change;

                if (enableDebug)
                {
                    System.Diagnostics.Debug.WriteLine("Swapping elements: {0} and {1}", inputArray[parent], inputArray[minimum]);
                }

                Heapify(inputArray, size, minimum);
            }
        }
    }
}

namespace MatrixChainDP
{
    public class MatrixChainDP
    {
        /// <summary>
        /// Matrix Chain Order DP is an algorithm for calculating the minimum number of
        /// multiplications of matrix chains. This algorithm calculates the minimum 
        /// number of products by optimizing the multiplication order of the matrices 
        /// using dynamic programming. The algorithm runs for a variable time as the number
        /// of matrices in the chain increases and the dimensions change. Given an array
        /// according to the dimensions of a chain of matrices, the algorithm calculates the
        /// minimum number of products by optimizing the product order of the matrices using
        /// dynamic programming. In this way, the computation time does not increase as the 
        /// number of matrices in the chain and their size increase.
        /// </summary>
        /// <param name="matrixSizes"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int mcmdp(int[] matrixDimensionArray, int size, bool enableDebug = false)
        {
            int[,] costMatrix = new int[size, size];

            // Initial state
            for (int i = 1; i < size; i++)
            {
                costMatrix[i, i] = 0;
            }

            // Calculate subchains based on chain length
            for (int chainLength = 2; chainLength < size; chainLength++)
            {
                for (int i = 1; i < size - chainLength + 1; i++)
                {
                    int j = i + chainLength - 1;
                    costMatrix[i, j] = int.MaxValue;

                    // Find the best split point
                    for (int k = i; k <= j - 1; k++)
                    {
                        int cost = costMatrix[i, k] + costMatrix[k + 1, j] + matrixDimensionArray[i - 1] * matrixDimensionArray[k] * matrixDimensionArray[j];
                        if (cost < costMatrix[i, j])
                        {
                            costMatrix[i, j] = cost;
                        }
                    }
                    if (enableDebug)
                    {
                        Console.WriteLine($"costMatrix[{i},{j}] = {costMatrix[i, j]}");
                    }
                }
            }

            return costMatrix[1, size - 1];
        }
    }
}

namespace MatrixChainMemoizedRecursive
{
    public class MatrixChainMemoizedRecursive
    {
        public static int[,] memo; // cache matrix

        /// <summary>
        /// Matrix Chain Memoized Recursive is an algorithm for calculating the minimum
        /// number of multiplications of matrix chains. This algorithm speeds up computations
        /// using dynamic programming and cache. Given an array based on the matrix chain 
        /// dimensions, the algorithm optimizes the multiplication order of the matrices and 
        /// calculates the minimum number of multiplications. The algorithm starts to slow down
        /// as the number of matrices in the chain increases and the sizes change, but it doesn't
        /// repeat the calculations using a cache, thus significantly reducing the computation time.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>

        // Calculates the minimum number of multiplications for the matrix chain
        public static int mcmrem(int[] p, int i, int j, bool enableDebug = false)
        {
            // If debug flag is enabled, print debug information
            if (enableDebug)
            {
                Console.WriteLine("MatrixChainOrderMemoized called with i=" + i + ", j=" + j);
            }

            // If the chain consists of only one matrix, no multiplication will be performed.
            if (i == j)
            {
                return 0;
            }

            // Get the result from the cache matrix if there are already calculated results
            if (memo[i, j] != 0)
            {
                if (enableDebug)
                {
                    Console.WriteLine("Memoized result used for i=" + i + ", j=" + j);
                }
                return memo[i, j];
            }

            // We are looking for the minimum number to minimize the number of multiplications of the matrices
            int min = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                // We calculate the number of multiplications of matrices
                int count = mcmrem(p, i, k) + mcmrem(p, k + 1, j) + p[i - 1] * p[k] * p[j];

                // We update the minimum number
                if (count < min)
                {
                    min = count;
                }
            }

            // We cache the minimum number
            memo[i, j] = min;

            // If debug flag is enabled, print debug information
            if (enableDebug)
            {
                Console.WriteLine("Minimum number " + min + " cached for i=" + i + ", j=" + j);
            }

            // We return the minimum number
            return min;
        }
    }
}

namespace LCS
{
    public static class LCSClass
    {
        /// <summary>
        /// Here you see the Longest common subsequence function. It finds the longest common letter sequence in two strings.
        /// If "abc" and "abf" are two, the longest common string is "ab". Let's move on to the content.
        ///It also compares the elements in two strings in a common matrix.
        ///As the common elements come, the numbers in the string increase, 
        ///so the algorithm can easily understand this in the index section and find the longest common string.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int lcs(string[] X, string[] Y, bool enableDebug = false)
        {


            int XSize = X.Length;
            int YSize = Y.Length;

            int[,] matrix = new int[XSize + 1, YSize + 1];

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j < XSize; j++)
                {
                    matrix[i, j] = 0;
                }

            }
            for (int j = 0; j <= 1; j++)
            {
                for (int i = 0; i <= YSize; i++)
                {
                    matrix[i, j] = 0;
                }

            }

            for (int i = 1; i <= XSize; i++)
            {

                for (int j = 1; j <= YSize; j++)
                {

                    if (X[i - 1] == Y[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        if (matrix[i - 1, j] >= matrix[i, j - 1])
                        {
                            int var = matrix[i - 1, j];
                            matrix[i, j] = var;
                        }
                        else if (matrix[i - 1, j] < matrix[i, j - 1])
                        {
                            int var = matrix[i, j - 1];
                            matrix[i, j] = var;
                        }
                    }

                    if (enableDebug)
                    {
                        System.Diagnostics.Debug.WriteLine("i={0}, j={1}, matrix[i,j]={2}", i, j, matrix[i, j]);
                    }

                }
            }


            int result = index(matrix);
            return result;

        }

        /// <summary>
        /// The function scans the matrix table from the LCS function and compares the values, 
        /// then adds them to an index string, so we can find both which letters are in the longest common string and how many.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>

        public static int index(int[,] matrix, bool enableDebug = false)
        {


            int SizeX = matrix.GetLength(0);
            int SizeY = matrix.GetLength(1);

            int[] index = new int[SizeX];


            int j = SizeY - 1;
            int p = -1;


            for (int i = SizeX - 1; i > 0; i--)
            {

                if (matrix[i, j] > matrix[i - 1, j] && matrix[i, j] > matrix[i, j - 1])
                {
                    p++;
                    index[p] = i;

                    if (j == 1)
                    {
                        //
                    }
                    else
                    {
                        j -= 1;
                    }

                }
                else if (matrix[i, j] == matrix[i, j - 1])
                {
                    i++;

                    if (j == 1)
                    {
                        break;
                    }
                    else
                    {
                        j -= 1;
                    }

                }
                else if (matrix[i, j] == matrix[i - 1, j])
                {
                    //
                }

                if (enableDebug)
                {
                    System.Diagnostics.Debug.WriteLine("i={0}, j={1} ", i, j);
                }
            }

            int IndexSize = index.Length - 1;

            int[] newindex = index.Where(i => i != 0).ToArray();

            int key = newindex.Length;

            return key;
        }
    }
}

namespace KnapSack
{
    public static class KnapSackClass
    {
        /// <summary>
        /// The KnapSack function aims to place the products of the given quantity and value in the bag with the predetermined capacity at the highest value. 
        /// Matrix table method like LCS is used in the function and value table is created with comparisons. On the table, 
        /// we can see the maximum values that the Bag can take and etc.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="weight"></param>
        /// <param name="value"></param>
        /// <param name="itemsCount"></param>
        /// <returns></returns>

        public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount, bool enableDebug = false)
        {
            int[,] matrix = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        matrix[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        matrix[i, w] = Math.Max(value[i - 1] + matrix[i - 1, w - weight[i - 1]], matrix[i - 1, w]);
                    else
                        matrix[i, w] = matrix[i - 1, w];

                    if (enableDebug)
                    {
                        System.Diagnostics.Debug.WriteLine("matrix[{0}, {1}] = {2}", i, w, matrix[i, w]);
                    }
                }
            }

            return matrix[itemsCount, capacity];

        }

        /// <summary>
        /// As with LCS, the KnapSack index function reads the general matrix table and we can see which products are selected from the index array if we want.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="weight"></param>
        /// <param name="value"></param>
        /// <param name="itemsCount"></param>

        public static void index(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] matrix = new int[itemsCount + 1, capacity + 1];

            int SizeX = matrix.GetLength(0);
            int SizeY = matrix.GetLength(1);

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        matrix[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        matrix[i, w] = Math.Max(value[i - 1] + matrix[i - 1, w - weight[i - 1]], matrix[i - 1, w]);
                    else
                        matrix[i, w] = matrix[i - 1, w];
                }
            }

            int[] index = new int[itemsCount];

            int j = SizeY - 1;
            int p = -1;

            for (int i = SizeX - 1; i > 0; i--)
            {

                if (matrix[i, j] > matrix[i - 1, j] && matrix[i, j] > matrix[i, j - 1])
                {

                    p++;

                    index[p] = i;

                    if (j == 1)
                    {
                        //
                    }
                    else
                    {
                        j -= weight[i - 1];

                    }

                }
                else
                {
                    //
                }


            }


            int IndexSize = index.Length - 1;

            int[] newindex = index.Where(i => i != 0).ToArray();

        }

    }
}
