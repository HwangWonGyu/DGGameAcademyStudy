using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
	class Program
	{
		public static float Discount20Percent(int price)
		{
			if (price <= 0)
				return 0;
			else
				return (price * 80.0f) / 100;
		}

		public static int Median(int i, int j, int k)
		{
			int[] temp = new int[3] { i, j, k };

			SelectionSort(temp);

			return temp[1];
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

		public static int MultipleThreeOrFive()
		{
			int sum = 0;
			for (int i = 0; i < 10000; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
					sum += i;
			}

			return sum;
		}

		public static float LessThanAverageRatio(int[] arr)
		{
			int sum = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				sum += arr[i];
			}
			float average = (float)sum / arr.Length;
			Console.WriteLine(average);
			int count = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				if (average > arr[i])
					count++;
			}
			float ratio = ((float)count * 100) / arr.Length;
			return ratio;
		}

		public static float CheatingAverageByMaxScore(int[] arr)
		{
			int max = arr[0];
			for (int i = 0; i < arr.Length; i++)
			{
				if (max < arr[i])
					max = arr[i];
			}
			float sumOfAverage = 0, cheatingAverage;
			for (int i = 0; i < arr.Length; i++)
			{
				sumOfAverage += ((float)arr[i] / max) * 100;
			}
			cheatingAverage = sumOfAverage / arr.Length;

			return cheatingAverage;
		}

		public static int WordCounter(char[] str)
		{
			int count = 1;
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ')
					count++;
			}

			return count;
		}

		public static char Grade(int score)
		{
			if (score >= 90 && score <= 100)
				return 'A';
			else if (score >= 80 && score < 90)
				return 'B';
			else if (score >= 70 && score < 80)
				return 'C';
			else if (score >= 60 && score < 70)
				return 'D';
			else
				return 'F';
		}

		public static char DayName(int x, int y)
		{
			switch (x)
			{
				case 1:
					break;
				case 2:
					y += 31;
					break;
				case 3:
					y += 31 + 28;
					break;
				case 4:
					y += 31 + 28 + 31;
					break;
				case 5:
					y += 31 + 28 + 31 + 30;
					break;
				case 6:
					y += 31 + 28 + 31 + 30 + 31;
					break;
				case 7:
					y += 31 + 28 + 31 + 30 + 31 + 30;
					break;
				case 8:
					y += 31 + 28 + 31 + 30 + 31 + 30 + 31;
					break;
				case 9:
					y += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
					break;
				case 10:
					y += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30;
					break;
				case 11:
					y += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31;
					break;
				case 12:
					y += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30;
					break;
			}

			if (y % 7 == 1)
				return '월';
			else if (y % 7 == 2)
				return '화';
			else if (y % 7 == 3)
				return '수';
			else if (y % 7 == 4)
				return '목';
			else if (y % 7 == 5)
				return '금';
			else if (y % 7 == 6)
				return '토';
			else
				return '일';
		}

		public static void PrintTenIntegerInOneRow(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (i % 10 == 9)
					Console.WriteLine(arr[i]);
				else
					Console.Write("{0} ", arr[i]);
			}
		}

		public static void GuGuDan(int n)
		{
			for (int i = 1; i < 10; i++)
				Console.WriteLine("{0} * {1} = {2}", n, i, n * i);
		}

		public static void QuotientToBrothersRemainderToFather(int candy, int n)
		{
			int candyOfBrother = candy / n;
			int candyOfFather = candy % n;

			Console.WriteLine("{0}, {1}", candyOfBrother, candyOfFather);
		}

		public static float NeverLessThanFourtyAverage(int[] arr)
		{
			for(int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 40)
					arr[i] = 40;
			}
			int sum = 0;
			for (int i = 0; i < arr.Length; i++)
				sum += arr[i];

			float average = (float)sum / arr.Length;
			return average;
		}

		public static int[] SugarVinylBag(int sugarKg)
		{
			int[] ThreeFiveSugar = new int[2];
			int fiveKg = sugarKg / 5; // 필요한 5kg 봉지
			int remainder = sugarKg % 5; // 3kg 봉지가 얼마나 필요한지 구하기 위한 변수

			if (sugarKg <= 0)
			{
				Console.WriteLine("설탕이 없습니다.");
				ThreeFiveSugar[0] = -1;
				ThreeFiveSugar[1] = -1;
				return ThreeFiveSugar;
			}

			if (remainder % 3 == 0)
			// 5로 나눠서 나머지가 3인 경우 + 0인 경우
			{
				int threeKg = remainder / 3;
				ThreeFiveSugar[0] = threeKg;
				ThreeFiveSugar[1] = fiveKg;
				return ThreeFiveSugar;
			}
			else if(sugarKg % 15 != 0 && sugarKg % 3 == 0)
			// 5의 배수는 아니면서 3의 배수인 경우(즉, 15의 배수는 제외)
			{
				if (remainder == 2 && sugarKg > 7)
				// 5로 나눠서 나머지가 2인 경우 +
				// 이 경우에서 3kg 봉지를 쓸 수 없는 7보다 큰 경우
				{
					ThreeFiveSugar[0] = 4;
					ThreeFiveSugar[1] = fiveKg - 2;
					return ThreeFiveSugar;
				}
				else
				{
					ThreeFiveSugar[0] = sugarKg / 3;
					ThreeFiveSugar[1] = 0;
					return ThreeFiveSugar;
				}
			}
			else if(remainder == 1 && sugarKg > 1)
			// 5로 나눠서 나머지가 1인 경우 +
			// 이 경우에서 3kg 봉지를 쓸 수 없는 1보다 큰 경우
			{
				ThreeFiveSugar[0] = 2;
				ThreeFiveSugar[1] = fiveKg - 1;
				return ThreeFiveSugar;
			}
			else if(remainder == 2 && sugarKg > 7)
			// 5로 나눠서 나머지가 2인 경우 +
			// 이 경우에서 3kg 봉지를 쓸 수 없는 7보다 큰 경우
			{
				ThreeFiveSugar[0] = 4;
				ThreeFiveSugar[1] = fiveKg - 2;
				return ThreeFiveSugar;
			}
			else if (remainder == 4 && sugarKg > 4)
			// 5로 나눠서 나머지가 4인 경우 +
			// 이 경우에서 3kg 봉지를 쓸 수 없는 4보다 큰 경우
			{
				ThreeFiveSugar[0] = 3;
				ThreeFiveSugar[1] = fiveKg - 1;
				return ThreeFiveSugar;
			}
			else
			{
				Console.WriteLine("설탕의 양이 3kg 봉지와 5kg 봉지로 정확히 나누어 떨어지지 않으므로 배달불가");
				ThreeFiveSugar[0] = -1;
				ThreeFiveSugar[1] = -1;
				return ThreeFiveSugar;
			}
		}

		public static int[] BookPageNumberCount(int n)
		{
			int[] numberCount = new int[10];
			string temp = "1";
			for(int i = 2; i <= n; i++)
				temp += Convert.ToString(i);

			for(int i = 0; i < temp.Length; i++)
			{
				if (temp[i] == '0')
					numberCount[0]++;
				else if (temp[i] == '1')
					numberCount[1]++;
				else if (temp[i] == '2')
					numberCount[2]++;
				else if (temp[i] == '3')
					numberCount[3]++;
				else if (temp[i] == '4')
					numberCount[4]++;
				else if (temp[i] == '5')
					numberCount[5]++;
				else if (temp[i] == '6')
					numberCount[6]++;
				else if (temp[i] == '7')
					numberCount[7]++;
				else if (temp[i] == '8')
					numberCount[8]++;
				else if (temp[i] == '9')
					numberCount[9]++;
			}

			return numberCount;
		}

		static void Main(string[] args)
		{
			int[] score = new int[20]
			  { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66, 74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };
			int[] arr = new int[3] { 40, 80, 60 };
			String str = "The Curious Case of Benjamin Button";
			int[] score2 = new int[5] { 35, 21, 70, 40, 65 };
			int[] tempSugar = new int[2];
			int[] numberCount = new int[10];

			//Console.WriteLine(Discount20Percent(16900));
			//Console.WriteLine(MultipleThreeOrFive());
			//Console.WriteLine(LessThanAverageRatio(score));
			//Console.WriteLine(CheatingAverageByMaxScore(arr));
			//Console.WriteLine(WordCounter(str.ToCharArray()));
			/*
			Console.WriteLine(Grade(71));
			Console.WriteLine(Grade(30));
			Console.WriteLine(Grade(95));
			 */
			/*
			Console.WriteLine(DayName(1, 6));
			Console.WriteLine(DayName(3, 1));
			Console.WriteLine(DayName(6, 19));
			 */
			//PrintTenIntegerInOneRow(score);
			//GuGuDan(3);
			//QuotientToBrothersRemainderToFather(99, 8);
			//Console.WriteLine(NeverLessThanFourtyAverage(score2));

			/*	
			for (int i = 0; i != -1;)
			{
				string temp = Console.ReadLine();
				i = int.Parse(temp);
				tempSugar = SugarVinylBag(i);
				Console.WriteLine("3kg:{0}, 5kg:{1}", tempSugar[0], tempSugar[1]);
			}
			*/

			/*
			numberCount = BookPageNumberCount(1);
			foreach (int a in numberCount)
				Console.WriteLine(a);
			*/
		}
	}
}
