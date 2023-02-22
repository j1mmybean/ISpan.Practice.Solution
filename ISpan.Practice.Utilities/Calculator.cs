using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.Utilities
{
	/// <summary>
	/// 一個含有加減乘除開方括號允許輸入負數功能之計算機
	/// todo 8(1+1) = 16
	/// todo DividedByZeroException
	/// </summary>
    public class Calculator
    {
		public string Formula { get; private set; } = string.Empty;

		public string Calculate(string formula = default)
		{
			if (string.IsNullOrEmpty(formula)) formula = Formula;

			//括號內先做
			while (formula.Contains('('))
			{
				string subFormula = formula.GetSubFormula();
				string subResult = Calculate(subFormula);
				formula = formula.Replace("(" + subFormula + ")", subResult);
			}

			//蒐集算式中的運算子和數字
			List<string> operators = formula.GetOperators();
			List<decimal> numbers = formula.GetNumbers();

			numbers = numbers.Power(ref operators);
			numbers = numbers.MultiplcationAndDivision(ref operators);
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
			char[] ops = { '+', '-', '*', '/', '^'};

			if (string.IsNullOrEmpty(Formula) || ops.Contains(Formula[Formula.Count() - 1]))
			{
				if (op == "-") Formula += "(-";
				else return;
			}
			else Formula += op;
		}

		public void InputBrackets(string bracket)
		{
			Formula += bracket;
		}
	}
}
