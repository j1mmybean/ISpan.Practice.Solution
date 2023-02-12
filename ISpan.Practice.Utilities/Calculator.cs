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
		public double Result { get; private set; }
		public void Calculate()
		{
			List<double> numbers = new List<double>();
			List<string> operators = new List<string>();

			int index = 0;
			for (int i = 0; i < Formula.Length; i++)
			{
				List<char> ops = new List<char> { '+', '-', '*', '/' };
				if (ops.Contains(Formula[i]))
				{
					numbers.Add(double.Parse(Formula.Substring(index, i - index)));
					operators.Add(Formula[i].ToString());
					index = i + 1;
				}
			}
			numbers.Add(double.Parse(Formula.Substring(index, Formula.Length - index)));

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
			List<double> numberList = new List<double>();
			for (int i = 0; i < numbers.Count; i++)
			{
				if (!indices.Contains(i))
				{
					numberList.Add(numbers[i]);
				}
			}
			numbers = numberList;

			Result = numbers[0];
			for (int i = 0; i < operators.Count; i++)
			{
				if (operators[i] == "+")
				{
					Result += numbers[i + 1];
				}
				else if (operators[i] == "-")
				{
					Result -= numbers[i + 1];
				}
			}
		}

		public void Clear()
		{
			Result = 0;
			Formula = string.Empty;
		}

		public void InputNumber(string num)
		{
			Formula += num;
		}

		public void InputOperator(string op)
		{
			List<char> ops = new List<char> { '+', '-', '*', '/' };
			if (ops.Contains(Formula[Formula.Count()-1])) return;
			Formula += op;
		}
	}
}
