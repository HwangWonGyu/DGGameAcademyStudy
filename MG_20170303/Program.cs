using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170303
{
	class Program
	{
		public static void Swap(ref int a, ref int b) // ref : reference
		{
			int temp = b;
			b = a;
			a = temp;
		}

		public static void SelectionSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = i; j < arr.Length; j++)
				{
					if (arr[i] > arr[j])
					{
						int tmp = arr[i];
						arr[i] = arr[j];
						arr[j] = tmp;
					}
				}
			}
		}

		public static void PartSelectionSort(int[] arr, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				for (int j = i; j < end; j++)
				{
					if (arr[i] > arr[j])
					{
						int tmp = arr[i];
						arr[i] = arr[j];
						arr[j] = tmp;
					}
				}
			}
		}

		public static void SelectionSort2(int[] arr)
		{
			int min = 0, temp = 0, min_index = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				min = arr[i];
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (min > arr[j])
					{
						min = arr[j];
						min_index = j;
					}
				}

				if (min_index != 0)
				{
					temp = min;
					arr[min_index] = arr[i];
					arr[i] = temp;
					min_index = 0;
				}
			}
		}

		public static void BubbleSort(int[] arr)
		{
			int temp = 0;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = 0; j < arr.Length - 1 - i; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}

		public static void Merge(int[] arr1, int[] arr2, int[] result)
		{
			int i = 0, j = 0, k = 0;
			for (; i < arr1.Length && j < arr2.Length; k++)
			{
				if (arr1[i] < arr2[j])
					result[k] = arr1[i++];
				else
					result[k] = arr2[j++];
			}

			if (i == arr1.Length)
			{
				for (; j < arr2.Length; j++, k++)
					result[k] = arr2[j];
			}
			else if (j == arr2.Length)
			{
				for (; i < arr1.Length; i++, k++)
					result[k] = arr1[i];
			}
		}

		public static void MergeOfMergeSort(int[] arr, int left, int right, int end, int[] result)
		{
			int i = left, j = right, k = left; // k = end 내가 틀린것

			for (; i < right && j < end;)
			{
				if (arr[i] < arr[j])
					result[k++] = arr[i++];
				else
					result[k++] = arr[j++];
			}

			if (i == right)
			{
				for (; j < end;)
					result[k++] = arr[j++];
			}
			else if (j == end)
			{
				for (; i < right;)
					result[k++] = arr[i++];
			}
		}

		public static void MergeSortIterative(int[] arr)
		{
			int[] result = new int[arr.Length];

			for (int i = 1; i < arr.Length; i = i * 2)
			{
				for (int j = 0; j < arr.Length; j = j + 2 * i)
				{
					// MergeOfMergeSort(arr, j, j + i, 2 * i, result); 내가 틀린것
					MergeOfMergeSort(arr, j, Math.Min(j + i, arr.Length), Math.Min(j + 2 * i, arr.Length), result);
				}
				for (int k = 0; k < arr.Length; k++)
					arr[k] = result[k];
			}
		}

		public static int FibbonacciRecursive(int n) // recursive, n >= 1 이어야 수열 계산이 가능
		{
			if (n <= 2)
				return 1;
			else if (n < 0)
			{
				Console.WriteLine("피보나치 수열 입니다. 양의 정수를 입력하세요.");
				return -1;
			}
			return FibbonacciRecursive(n - 1) + FibbonacciRecursive(n - 2);
		}

		public static int FibbonacciIterative(int n)
		{
			int a0 = 0, a1 = 1, temp1 = a0, temp2 = a1, temp3 = 0;

			for (int i = 1; i < n - 1; i++)
			{
				temp3 = temp1 + temp2;
				temp1 = temp2;
				temp2 = temp3;
			}

			return temp3;
		}

		public static int Plus(int a, int b)
		{
			return a + b;
		}

		// overloading
		public static long Plus(long a, long b)
		{
			return a + b;
		}

		// overloading
		public static float Plus(float a, float b)
		{
			return a + b;
		}

		// overloading
		public static double Plus(double a, double b)
		{
			return a + b;
		}

		public static void Reverse(int[] arr)
		{
			for (int i = 1; i < arr.Length / 2; i++)
				Swap(ref arr[i - 1], ref arr[arr.Length - i]);
		}

		/*
		 * ref keyword
		int x = 3, y = 4;
		Console.WriteLine("{0} {1}", x, y);
		Swap(ref x, ref y);
		Console.WriteLine("{0} {1}", x, y);
		*/

		static void Main(string[] args)
		{
			int[] score = new int[20]
			  { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66,
				74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };

			//MergeSort(score);
			//SelectionSort(score);

			int[] arr1 = new int[] { 3, 4, 7, 10, 15, 19, 23, 25, 40, 42 }; // 10개 안적어줘도 자기가 알아서 할당해줌
			int[] arr2 = new int[] { 1, 2, 5, 20, 28, 30, 31, 32, 33, 43 };
			int[] result = new int[arr1.Length + arr2.Length];

			//Merge(arr1, arr2, result);
			//Console.WriteLine(FibbonacciIterative(6));
			//Console.WriteLine(FibbonacciRecursive(10));

			//BubbleSort(score);


		}
	}
}
