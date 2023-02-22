using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	public static class OperationExtensions
	{

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
