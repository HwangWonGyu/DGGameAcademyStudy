using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170328
{
	class MainProgram
	{
		public static void QuickSort(int[] arr, int start, int end)
		{
			if (start < end)
			{
				int i = start, j = end + 1;
				int pivot = arr[start];

				i++; // pivot을 항상 start로 잡아놔서 그 다음부터 비교하려고 ++을 해줌
				while (i < j)
				{
					while (arr[i] < pivot)
						i++;
					while (pivot < arr[j])
						j--;
					if (i < j)
						Swap(ref arr[i], ref arr[j]);
				}

				Swap(ref arr[start], ref arr[j]);
				foreach (int a in arr)
					Console.Write(a + " ");
				Console.WriteLine();
				QuickSort(arr, start, j - 1);
				QuickSort(arr, j + 1, end);
			}
		}

		public static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}

		static void Main(string[] args)
		{
			int[] arr = new int[11] { 26, 5, 37, 1, 61, 11, 59, 15, 48, 19, 9999};

			int start = 0;
			int end = arr.Length - 2; // 19
			int pivot = arr[start]; // 26

			QuickSort(arr, start, end);
		}
	}
}
