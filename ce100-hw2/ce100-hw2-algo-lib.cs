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
        public static int[] HeapSort(int[] inputArray, int[] outputArray)
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

                System.Diagnostics.Debug.WriteLine("Swapping elements: {0} and {1}", outputArray[0], outputArray[i]);

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
        private static void Heapify(int[] inputArray, int size, int parent)
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

                System.Diagnostics.Debug.WriteLine("Swapping elements: {0} and {1}", inputArray[parent], inputArray[minimum]);

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
        public static int CalculateMinimumMultiplication(int[] matrixSizes, int size, bool enableDebug = true)
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
                        int cost = costMatrix[i, k] + costMatrix[k + 1, j] + matrixSizes[i - 1] * matrixSizes[k] * matrixSizes[j];
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
