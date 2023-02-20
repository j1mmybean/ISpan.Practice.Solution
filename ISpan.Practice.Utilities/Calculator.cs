using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	/// <summary>
	/// 一個含有加減乘除功能之計算機
	/// todo可輸入負數
	/// todo可開方
	/// </summary>
    public class Calculator
    {
		public string Formula { get; private set; } = string.Empty;

		public string Calculate()
		{
			List<string> operators = Formula.GetOperators();
			List<decimal> numbers = Formula.GetNumbers();

			numbers = numbers.MultiplcationAndDivision(operators, out operators);
			decimal result = numbers.AdditionAndSubstraction(operators);

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

			if (string.IsNullOrEmpty(Formula) || ops.Contains(Formula[Formula.Count() - 1]))
			{
				if (op == "-") Formula += "(-)";
				else return;
			}
			else Formula += op;
		}
	}
}
