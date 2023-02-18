using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class CalculatorExtensionsTests
	{
		[Test]
		public void GetOperators_傳回加減乘除字串List()
		{
			string source = "-12+33-444*56/7";
			var expected = new List<string> { "+", "-", "*", "/" };

			var actual = source.GetOperators();
			Assert.AreEqual(expected, actual);
		}

		[TestCase("-12+33-444*56/7")] // Attribute特徵項

		public void GetNumbers_傳回decimal數字List(string formula)
		{
			string source = formula;
			var expected = new List<decimal> { -12, 33, 444, 56, 7 };

			var actual = source.GetNumbers();
			Assert.AreEqual(expected, actual);
		}
		//public void MultiplcationAndDivision_傳回加減乘除字串List()
		//{
		//	string source = "-12+33-444*56/7";
		//	var expected = new List<decimal> { 12, 33, 444, 56, 7 };

		//	var actual = source.GetNumbers();
		//	Assert.AreEqual(expected, actual);
		//}
		//public void AdditionAndSubstraction_輸入數字List和運算子List_傳回計算結果()
		//{
		//	var numbers = new List<decimal> { 12, 33, 444, 56, 7 };
		//	var operators = new List<string> { 12, 33, 444, 56, 7 };

		//	var expected = new List<decimal> { 12, 33, 444, 56, 7 };

		//	var actual = source.GetNumbers();
		//	Assert.AreEqual(expected, actual);
		//}
	}
}