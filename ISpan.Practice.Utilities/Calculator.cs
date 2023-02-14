using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
    public class Calculator
    {
		public string Formula { get; private set; } = string.Empty;

		private List<string> GetOperators(string formula)
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
		private List<decimal> GetNumbers(string formula)
		{
			char[] ops = { '+', '-', '*', '/' };
			List<decimal> numbers = formula.Split(ops).Select(n => decimal.Parse(n)).ToList();

			//允許首位數字為負
			if (formula[0] == '-')
			{
				numbers[0] = -numbers[0];
			}

			return numbers;
		}
		private List<int> MultiplcationAndDivision(List<decimal> numbers, List<string> operators)
		{
			List<int> indices = new List<int>();
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "*")
				{
					numbers[i + 1] = numbers[i] * numbers[i + 1];
					indices.Add(i);
				}
				else if (operators[i] == "/")
				{
					numbers[i + 1] = numbers[i] / numbers[i + 1];
					indices.Add(i);
				}
			}

			operators = operators.Where(o => o == "+" || o == "-").ToList();
			List<decimal> numberList = new List<decimal>();
			for (int i = 0; i < numbers.Count; i++)
			{
				if (!indices.Contains(i))
				{
					numberList.Add(numbers[i]);
				}
			}
			numbers = numberList;

			return indices;
		}

		private string AdditionAndSubstraction(List<decimal> numbers, List<string> operators)
		{
			decimal result = numbers[0];
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "+")
				{
					result += numbers[i + 1];
				}
				else if (operators[i] == "-")
				{
					result -= numbers[i + 1];
				}
			}
			return result.ToString("#0.00");
		}
		public string Calculate()
		{
			List<char> ops = new List<char> { '+', '-', '*', '/' };
			string formula = ops.Contains(Formula[Formula.Length - 1])
							? Formula.Remove(Formula.Length - 1)
							: Formula;
			List<decimal> numbers = new List<decimal>();
			List<string> operators = new List<string>();
			if (formula[0] == '-')
			{
				numbers.Add(-1);
				operators.Add("*");
				formula = formula.Remove(0, 1);
			}

			int index = 0;
			for (int i = 0; i < formula.Length; i++)
			{
				if (ops.Contains(formula[i]))
				{
					numbers.Add(decimal.Parse(formula.Substring(index, i - index)));
					operators.Add(formula[i].ToString());
					index = i + 1;
				}
			}

			numbers.Add(decimal.Parse(formula.Substring(index, formula.Length - index)));

			//先乘除
			List<int> indices = new List<int>();
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "*")
				{
					numbers[i + 1] = numbers[i] * numbers[i + 1];
					indices.Add(i);
				}
				else if (operators[i] == "/")
				{
					numbers[i + 1] = numbers[i] / numbers[i + 1];
					indices.Add(i);
				}
			}

			//收集乘除後的剩下和產生的數字和運算子
			operators = operators.Where(o => o == "+" || o == "-").ToList();
			List<decimal> numberList = new List<decimal>();
			for (int i = 0; i < numbers.Count; i++)
			{
				if (!indices.Contains(i))
				{
					numberList.Add(numbers[i]);
				}
			}
			numbers = numberList;

			//後加減
			decimal result = numbers[0];
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "+")
				{
					result += numbers[i + 1];
				}
				else if (operators[i] == "-")
				{
					result -= numbers[i + 1];
				}
			}
			return result.ToString("#0.00");
		}
		public void Equal()
		{
			Formula = Calculate();
		}
		public void Clear()
		{
			Formula = string.Empty;
		}

		public void Delete()
		{
			Formula = Formula.Remove(Formula.Length - 1);
		}

		public void InputNumber(string num)
		{
			Formula += num;
		}

		public void InputOperator(string op)
		{
			List<char> ops = new List<char> { '+', '-', '*', '/' };
			if (string.IsNullOrEmpty(Formula) && op != "-") return;
			if (!string.IsNullOrEmpty(Formula) && ops.Contains(Formula[Formula.Count()-1])) return;
			Formula += op;
		}
	}
}
