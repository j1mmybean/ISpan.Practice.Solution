using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	public static class FormulaExtensions
	{
		static char[] ops = { '+', '-', '*', '/' };

		public static string GetSubFormula(this string formula)
		{
			string subFormula = string.Empty;
			int count = 0;
			int begin = formula.IndexOf('(');
			for (int i = begin + 1; i < formula.Length; i++)
			{
				if (formula[i] == ')')
				{
					if (count == 0)
					{
						subFormula = formula.Substring(begin + 1, i - begin - 1);
						break;
					}
					count--;
				}
				else if (formula[i] == '(') count++;
			}

			return subFormula;
		}
		public static List<string> GetOperators(this string formula)
		{
			List<string> operators = new List<string>();

			//i大於0，因為允許首個數字為負；i小於formula.Length-1，因為若算式最後一位為運算子，則其不加入運算
			for (int i = 1; i < formula.Length - 1; i++)
			{
				if (formula[i] == '-' && ops.Contains(formula[i - 1]))
				{
					continue;
				}
				else if (ops.Contains(formula[i]))
				{
					operators.Add(formula[i].ToString());
				}
			}
			return operators;
		}
		public static List<decimal> GetNumbers(this string formula)
		{
			//允許首位數字為負
			if (formula[0] == '-') formula = "n" + formula.Substring(1);

			foreach (var op in ops)
			{
				formula = formula.Replace(op + "-", op + "n");//n => negative
				formula = formula.Replace(op, ' ');
			}

			List<decimal> numbers = formula.Replace('n', '-').Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
											.Select(n => decimal.Parse(n)).ToList();

			return numbers;
		}

	}
}
