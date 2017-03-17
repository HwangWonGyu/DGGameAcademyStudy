using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170314
{
	class Program
	{
		public static void Swap(ref char a, ref char b)
		{
			char temp = b;
			b = a;
			a = temp;
		}

		public static void Reverse(char[] arr)
		{
			for (int i = 1; i < arr.Length / 2; i++)
				Swap(ref arr[i - 1], ref arr[arr.Length - i]);
		}

		class CharStack
		{
			char[] charArr;
			int top = -1;

			public CharStack(int size)
			{
				charArr = new char[size];
			}

			public void Push(char c)
			{
				if (top >= charArr.Length)
					Console.WriteLine("Full Stack");
				else
				{
					charArr[++top] = c;
				}
			}

			public char Pop()
			{
				if (top == -1)
				{
					Console.WriteLine("Empty Stack");
					return 'e';
				}
				else
				{
					return charArr[top--];
				}
			}

			public void printArr()
			{
				for (int i = 0; i < top + 1; i++)
					Console.WriteLine(charArr[i]);
			}

			public void calculateArr()
			{

			}

		}

		class IntStack
		{
			int[] intArr;
			int top = -1;

			public IntStack(int size)
			{
				intArr = new int[size];
			}

			public void Push(int n)
			{
				if (top >= intArr.Length)
					Console.WriteLine("Full Stack");
				else
				{
					intArr[++top] = n;
				}
			}

			public int Pop()
			{
				if (top == -1)
				{
					Console.WriteLine("Empty Stack");
					return int.MinValue;
				}
				else
				{
					return intArr[top--];
				}
			}

			public void printArr()
			{
				for (int i = 0; i < top + 1; i++)
					Console.WriteLine(intArr[i]);
			}
		}

		static void Main(string[] args)
		{
			CharStack charStack = new CharStack(30);

			string temp;

			while (true)
			{
				temp = Console.ReadLine();

				if (temp.Length > 30)
					Console.WriteLine("입력한 수식이 스택 최대허용범위를 초과했습니다.");
				else
					break;
			}

			char[] charArr = temp.ToCharArray();

			for (int i = 0; i < temp.Length; i++)
				charStack.Push(charArr[i]);

			// charStack.printArr();
			// 3*2+7-1/5+6

			for (int i = charArr.Length - 2; i > 0; i = i - 2)
			{
				if (charArr[i] == '*')
				{
					
				}
				else if(charArr[i] == '/')
				{

				}
			}

			/*
			IntStack intStack = new IntStack(10);
			
			intStack.Push(1);
			intStack.Push(2);
			intStack.Push(5);
			intStack.Push(7);
			intStack.Pop();
			intStack.Push(3);
			intStack.Pop();
			intStack.Pop();
			intStack.Push(-2);

			intStack.printArr();
			*/
		}
	}
}
