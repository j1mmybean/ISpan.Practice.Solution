using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Practice.ConsoleApp
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine(100 ^ 0);

			int num = 100;
			Console.WriteLine(num++);
			 num = 100;
			Console.WriteLine(++num);

			Console.WriteLine((decimal)Math.Pow(16, (double)1/2));

		//	char[] ops = { '+', '-', '*', '/' };

		//	string formula = "-1+2-3*4/2";
		//	foreach (var op in ops)
		//	{
		//		formula = formula.Replace(op + "-", op + "n");
		//		formula = formula.Replace(op, ' ');
		//	}

		//	List<decimal> numbers = formula.Replace('n', '-').Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
		//									.Select(n => decimal.Parse(n)).ToList();

		//	for (int i = 0; i < numbers.Count; i++)
		//	{
		//		Console.WriteLine(numbers[i]);
		//	}



		//	List<string> list = new List<string> { "a", "b", "c", "d" };
		//	for (int i = 0; i < list.Count; i++)
		//	{
		//		Console.WriteLine(list[i]);
		//		if (list[i] == "b")
		//		{
		//			list.RemoveAt(i);
		//		}
		//	}

		//	Console.WriteLine(int.Parse("5+4"));
		//}

		//public int MyProperty1 { get; private set; }


		//private int _myProperty2;
		//public int MyProperty2 
		//{
		//	 get { return _myProperty2; }
		//	 set { _myProperty2 = value; } 
		}
	}
}
