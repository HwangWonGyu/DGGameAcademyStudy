using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170303
{
    class Program
    {
		public static void Swap(ref int a, ref int b)
		{
			int temp = b;
			b = a;
			a = temp;
		}

		public static void selectionSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for( int j = i; j < arr.Length; j++)
				{
					if(arr[i] > arr[j])
					{
						int tmp = arr[i];
						arr[i] = arr[j];
						arr[j] = tmp;
					}
				}
			}
		}

		public static void partSelectionSort(int[] arr, int start, int end)
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

		static void Main(string[] args)
		{
			int[] score = new int[20] { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66, 74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };

			// 가장 잘게 나뉘어지는 index들을 저장
			int[] ms = new int[score.Length / 2 - 1];

			int tmp1 = 0;
			int tmp2 = score.Length;
			int add = score.Length;
			for (int i = 0; i < score.Length / 2 - 1; i++)
			{
				ms[i] = (tmp1 + tmp2) / 2;
				if (tmp2 == score.Length)
				{
					tmp2 = (tmp2 - tmp1) / 2;
					if (tmp2 == 2 || tmp2 == 3)
						break;
					tmp1 = 0;
					add = add / 2;
				}
				else
				{
					tmp1 += add;
					tmp2 += add;
				}
			}
			selectionSort(ms);
			int real_count = 0;
			for (int i = 0; i < ms.Length; i++)
			{
				if (ms[i] != 0)
					real_count++;
			}
			int[] real_ms = new int[real_count];
			for (int i = 0, j = 0; i < ms.Length && j < real_count; i++)
			{
				if (ms[i] != 0)
					real_ms[j++] = ms[i];
			}
			selectionSort(real_ms);

			// 정렬
			int ms_index = 0;
			int cur = real_ms[ms_index];
			for (int i = 0; i < cur; i++)
			{
				if (i + 1 != cur)
				{
					if (ms_index == 0)
					{
						partSelectionSort(score, 0, real_ms[ms_index]);
						partSelectionSort(score, real_ms[ms_index], real_ms[ms_index + 1]);
					}
					else // ms_index != 0
					{
						if (ms_index == real_ms.Length - 1)
							partSelectionSort(score, real_ms[ms_index], score.Length);
						else if (ms_index < real_ms.Length - 1 && ms_index > 0)
							partSelectionSort(score, real_ms[ms_index], real_ms[ms_index + 1]);
					}
				}
				else // i + 1 == cur
				{
					if (cur == real_ms[real_ms.Length - 1])
						break;
					cur = real_ms[++ms_index];
				}
			}

			//foreach (int test in score)
			//	Console.WriteLine(test);

			// merge
			int score_index = 0, what = 2;
			for (int i = 0; i < score.Length; i = i + what)
			{
				int[] temp1 = new int[real_ms[i]];
				int[] temp2 = new int[real_ms[i + what/2] - real_ms[i]];
				int[] temp3 = new int[real_ms[i + what] - real_ms[i]];
				int count = 0;
				for (int k = 0; count < real_ms[i]; count++)
				{
					temp1[k++] = score[count];
				}
				count = real_ms[i];

				for(int k = 0; count < real_ms[i+1]; count++)
				{
					temp2[k++] = score[count];
				}

				Merge(temp1, temp2, temp3);
				for (int j = 0; j < temp3.Length; j++)
					score[score_index++] = temp3[j];
			}
			foreach (int test in score)
				Console.WriteLine(test);

			/*
			int[] arr1 = new int[] { 3, 4, 7, 10, 15, 19, 23, 25, 40, 42 }; // 10개 안적어줘도 자기가 알아서 할당해줌
			int[] arr2 = new int[] { 1, 2, 5, 20, 28, 30, 31, 32, 33, 43 };
			int[] result = new int[arr1.Length + arr2.Length];
			*/

			/* method 사용(selection sort)

			selectionSort(score);

			foreach(int a in score)
				Console.WriteLine(a);
			*/

			/*
			 * method 사용(merge)
			Merge(arr1, arr2, result);
			foreach (int a in result)
				Console.WriteLine(a);
			*/

			/*
			int x = 3, y = 4;
			Console.WriteLine("{0} {1}", x, y);
			Swap(ref x, ref y);
			Console.WriteLine("{0} {1}", x, y);
			*/

			/*
			for (int i = 0; i < 9; i++)
			{
				if (i > 4) {
					for (int j = 0; j < 9-i; j++)
					{
						Console.Write("*");
					}
					Console.WriteLine();
				}
				else
				{
					for (int j = 0; j < i+1; j++)
						Console.Write("*");
					Console.WriteLine();
				}
			}
            */

			/*
			for(int i = 0; i < 10; i++) {
				if (i < 5) {
					for (int j = 0; j < 10; j++) {
						if (j < 5) {
							if (j <= i)
								Console.Write("*");
							else
								Console.Write(" ");
						}
						else {
							if (j <= 9 - i)
								Console.Write("*");
							else
								Console.Write(" ");
						}
					}
					Console.WriteLine();
				}
				else {
					for (int j = 0; j < 10; j++) {
						if (j < 5) {
							if (j >= 9 - i)
								Console.Write("*");
							else
								Console.Write(" ");
						}
						else {
							if (j >= i)
								Console.Write("*");
							else
								Console.Write(" ");
						}
					}
					Console.WriteLine();
				}
				*/

			/*
			 * fibo
			int a0 = 0, a1 = 1, temp1 = a0, temp2 = a1, temp3 = 0;

			for(int i = 0; i < 18; i++)
			{
				temp3 = temp1 + temp2;
				temp1 = temp2;
				temp2 = temp3;
			}
			Console.WriteLine(temp3);
			*/

			/*
			int[] num = new int[50];
			
			for(int index = 0, i = 0; index < 50; i++)
			{
				if (i % 2 == 1)
					num[index++] = i;
			}

			foreach (int i in num)
				Console.WriteLine(i);
			*/

			//int[] score = new int[20] { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66, 74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };

			/*
			 * bubble sort
			int temp = 0;

			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 19-i; j++)
				{
					if(score[j] > score[j + 1])
					{
						temp = score[j];
						score[j] = score[j + 1];
						score[j + 1] = temp;
					}
				}
			}

			foreach (int start in score)
				Console.WriteLine(start);
			*/

			/*
			 * max, min
			int max = score[0];
			for(int i = 0; i < 20; i++)
			{
				if (max < score[i])
					max = score[i];
			}
			Console.WriteLine(max);

			int min = score[0];
			for (int i = 0; i < 20; i++)
			{
				if (min > score[i])
					min = score[i];
			}
			Console.WriteLine(min);
			*/

			/*
			 * selection sort
			int min = 0, temp = 0, min_index = 0;
			for(int i = 0; i < 19; i++)
			{
				min = score[i];
				for (int j = i + 1; j < 20; j++)
				{
					if (min > score[j])
					{
						min = score[j];
						min_index = j;
					}
				}

				if (min_index != 0)
				{
					temp = min;
					score[min_index] = score[i];
					score[i] = temp;
					min_index = 0;
				}
			}

			foreach (int start in score)
				Console.WriteLine(start);
			*/

			/*
			 * merge
			int[] arr1 = new int[] { 3, 4, 7, 10, 15, 19, 23, 25, 40, 42 }; // 10개 안적어줘도 자기가 알아서 할당해줌
			int[] arr2 = new int[] { 1, 2, 5, 20, 28, 30, 31, 32, 33, 43 };
			int[] result = new int[arr1.Length + arr2.Length];

			int i = 0, j = 0, k = 0;
			for ( ; i < arr1.Length && j < arr2.Length; k++)
			{
				if(arr1[i] < arr2[j])
					result[k] = arr1[i++];
				else
					result[k] = arr2[j++];
			}

			if (i == arr1.Length)
			{
				for ( ; j < arr2.Length; j++, k++)
					result[k] = arr2[j];
			}
			else if(j == arr2.Length)
			{
				for (; i < arr1.Length; i++, k++)
					result[k] = arr1[i];
			}

			foreach (int a in result)
				Console.WriteLine(a);
			*/


		}
	}
}
