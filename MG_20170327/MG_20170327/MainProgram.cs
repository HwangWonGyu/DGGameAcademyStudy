using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170327
{
	class MainProgram
	{
		public static void ArrayBinarySearchIterative(int[] arr, int search, int start, int end, int divide)
		{
			bool isSearched = false;
			while (start != end)
			{
				if (arr[divide] == search)
				{
					isSearched = true;
					break;
				}
				else if (arr[divide] > search)
				{
					end = (start + end) / 2;
					divide = (start + end) / 2;
					Console.WriteLine("start = {0}, end = {1}, divide = {2}", start, end, divide);
				}
				else if (arr[divide] < search)
				{
					start = divide + 1;
					divide = (start + end) / 2;
					Console.WriteLine("start = {0}, end = {1}, divide = {2}", start, end, divide);
				}
			}
			if (isSearched == true)
				Console.WriteLine("찾았습니다.");
			else
				Console.WriteLine("못찾았습니다.");
		}

		public static void ArrayBinarySearchRecursive(int[] arr, int search, int start, int end, int divide)
		{
			if (start == end)
			{
				if (start < arr.Length && arr[start] == search)
				{
					Console.WriteLine("찾았습니다.");
					return;
				}
				else
				{
					Console.WriteLine("못찾았습니다.");
					return;
				}
			}

			if (arr[divide] == search)
			{
				Console.WriteLine("찾았습니다.");
				return;
			}
			else if (arr[divide] > search)
			{
				end = (start + end) / 2;
				divide = (start + end) / 2;
				Console.WriteLine("start = {0}, end = {1}, divide = {2}", start, end, divide);
				ArrayBinarySearchRecursive(arr, search, start, end, divide);
			}
			else if (arr[divide] < search)
			{
				start = divide + 1;
				divide = (start + end) / 2;
				Console.WriteLine("start = {0}, end = {1}, divide = {2}", start, end, divide);
				ArrayBinarySearchRecursive(arr, search, start, end, divide);
			}
		}

		static void Main(string[] args)
		{
			//int[] arr = new int[15];
			//for (int i = 0; i < 15; i++)
			//	arr[i] = i * 2; // {0, 2, 4, ... ,26, 28}

			//int start = 0;
			//int end = arr.Length; // 15
			//int divide = (start + end) / 2; // (0 + 15) / 2 = 7

			//Console.Write("배열에서 찾아낼 정수를 입력하세요. : ");
			//int search = Convert.ToInt32(Console.ReadLine());

			//Console.WriteLine("start = {0}, end = {1}, divide = {2}", start, end, divide);

			////iterative
			//ArrayBinarySearchIterative(arr, search, start, end, divide);

			////recursive
			//ArrayBinarySearchRecursive(arr, search, start, end, divide);



			BinarySearchTree bst = new BinarySearchTree();

			bst.Insert(15);
			bst.Insert(13);
			bst.Insert(14);
			bst.Insert(9);
			bst.Insert(19);
			bst.Insert(21);
			bst.Insert(17);
			bst.Insert(11);
			bst.Insert(8);
			bst.Insert(16);
			bst.Insert(23);
			bst.Insert(20);

			bst.Search(21); // 찾았습니다.
			bst.Search(15); // 찾았습니다.
			bst.Search(14); // 찾았습니다.
			bst.Search(11); // 찾았습니다.

			bst.Search(18); // 못찾았습니다.
			bst.Insert(18);
			bst.Search(18); // 찾았습니다.
			bst.Insert(18); // 이미 있는 값입니다.
		}
	}
}
