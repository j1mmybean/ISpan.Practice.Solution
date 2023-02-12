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
		public void CalculateResult()
		{
			List<string> _numbers = new List<string>();
			List<string> _operators = new List<string>();

			int index = 0;
			for (int i = 0; i < Formula.Length; i++)
			{
				List<char> ops = new List<char> { '+', '-', '*', '/' };
				if (ops.Contains(Formula[i]))
				{
					_numbers.Add(Formula.Substring(index, i - index));
					_operators.Add(Formula[i].ToString());
					index = i + 1;
				}
			}
			_numbers.Add(Formula.Substring(index, Formula.Length - index));

			List<double> NumbersTemp = _numbers.Select(n => double.Parse(n)).ToList();
			List<string> OperatorsTemp = new List<string>(_operators);
			List<int> indices = new List<int>();

			for (int i = 0; i < OperatorsTemp.Count; i++)
			{
				if (OperatorsTemp[i] == "*")
				{
					NumbersTemp[i + 1] = NumbersTemp[i] * NumbersTemp[i + 1];
					indices.Add(i);
				}
				else if (OperatorsTemp[i] == "/")
				{
					NumbersTemp[i + 1] = NumbersTemp[i] / NumbersTemp[i + 1];
					indices.Add(i);
				}
			}

			OperatorsTemp = OperatorsTemp.Where(o => o == "+" || o == "-").ToList();
			List<double> numberList = new List<double>();
			for (int i = 0; i < NumbersTemp.Count; i++)
			{
				if (!indices.Contains(i))
				{
					numberList.Add(NumbersTemp[i]);
				}
			}
			NumbersTemp = numberList;

			Result = NumbersTemp[0];
			for (int i = 0; i < OperatorsTemp.Count; i++)
			{
				if (OperatorsTemp[i] == "+")
				{
					Result += NumbersTemp[i + 1];
				}
				else if (OperatorsTemp[i] == "-")
				{
					Result -= NumbersTemp[i + 1];
				}
			}
		}

		public void Clear()
		{
			Result = 0;
			Formula = string.Empty;
		}

		public void InputNumber(string number)
		{
			Formula += number;
		}

		public void Operation(string _operator)
		{
			List<char> ops = new List<char> { '+', '-', '*', '/' };
			if (ops.Contains(Formula[Formula.Count()-1])) return;
			Formula += _operator;
		}
	}
}
