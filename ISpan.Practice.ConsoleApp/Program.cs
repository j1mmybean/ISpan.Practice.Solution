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
			List<string> list = new List<string> { "a", "b", "c", "d" };
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
				if (list[i] == "b")
				{
					list.RemoveAt(i);
				}
			}

			Console.WriteLine(int.Parse("5+4"));
		}

		public int MyProperty1 { get; private set; }


		private int _myProperty2;
		public int MyProperty2 
		{
			 get { return _myProperty2; }
			 set { _myProperty2 = value; } 
		}
	}
}
