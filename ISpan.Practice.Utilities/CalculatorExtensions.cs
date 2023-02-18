using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	public static class CalculatorExtensions
	{
		public static List<string> GetOperators(this string formula)
		{
			List<char> ops = new List<char> { '+', '-', '*', '/' };
			List<string> operators = new List<string>();

			//i大於0，因為允許首個數字為負；i小於formula.Length-1，因為若算式最後一位為運算子，則其不加入運算
			for (int i = 1; i < formula.Length - 1; i++)
			{
				if (ops.Contains(formula[i]))
				{
					operators.Add(formula[i].ToString());
				}
			}
			return operators;
		}
		public static List<decimal> GetNumbers(this string formula)
		{
			char[] ops = { '+', '-', '*', '/' };

			List<decimal> numbers = formula.Split(ops, StringSplitOptions.RemoveEmptyEntries).Select(n => decimal.Parse(n)).ToList();

			//允許首位數字為負
			if (formula[0] == '-')
			{
				numbers[0] = -numbers[0];
			}

			return numbers;
		}
		public static List<decimal> MultiplcationAndDivision(this List<decimal> numbers, List<string> operators, out List<string> operatorsLeft)
		{
			List<decimal> numbersLeft = new List<decimal>();
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
				else numbersLeft.Add(numbers[i]);
			}
			numbersLeft.Add(numbers[numbers.Count - 1]);

			operatorsLeft = operators.Where(o => o == "+" || o == "-").ToList();
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
