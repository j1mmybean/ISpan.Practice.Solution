using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	public static class OperationExtensions
	{
		public static List<decimal> Power(this List<decimal> numbers, ref List<string> operators)
		{
			List<decimal> numbersLeft = new List<decimal>();
			List<string> operatorsLeft = new List<string>();
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "^")
				{
					numbers[i + 1] = (decimal)Math.Pow((double)numbers[i], (double)numbers[i + 1]);
				}
				else
				{
					numbersLeft.Add(numbers[i]);
					operatorsLeft.Add(operators[i]);
				}
			}
			numbersLeft.Add(numbers[numbers.Count - 1]);
			operators = operatorsLeft;

			return numbersLeft;
		}

		/// <summary>
		/// 輸入數字List與運算子List，對數字List進行運算子List中的乘除運算
		/// </summary>
		/// <param name="numbers">輸入要進行運算的數字</param>
		/// <param name="operators">輸入運算要使用的運算子，並在使用後將其從參數中刪除</param>
		/// <returns>輸出運算後的數字結果，和未使用過的運算子。</returns>
		public static List<decimal> MultiplcationAndDivision(this List<decimal> numbers, ref List<string> operators)
		{
			List<decimal> numbersLeft = new List<decimal>();
			List<string> operatorsLeft = new List<string>();
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "*")
				{
					numbers[i + 1] = numbers[i] * numbers[i + 1];
				}
				else if (operators[i] == "/")
				{
					numbers[i + 1] = numbers[i] / numbers[i + 1];
				}
				else
				{
					numbersLeft.Add(numbers[i]);
					operatorsLeft.Add(operators[i]);
				}
			}
			numbersLeft.Add(numbers[numbers.Count - 1]);
			operators = operatorsLeft;

			return numbersLeft;
		}

		public static decimal AdditionAndSubstraction(this List<decimal> numbers, List<string> operators)
		{
			decimal result = numbers[0];
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "+")
				{
					result += numbers[i + 1];
				}
				else //(operators[i] == "-")
				{
					result -= numbers[i + 1];
				}
			}
			return result;
		}

	}
}
