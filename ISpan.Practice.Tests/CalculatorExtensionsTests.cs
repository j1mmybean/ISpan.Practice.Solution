using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class CalculatorExtensionsTests
	{
		[TestCase("-12")]
		[TestCase("-12+33-444*56/7")] // Attribute特徵項
		public void GetNumbers_傳回decimal數字List(string formula)
		{
			string source = formula;
			var expected = new List<decimal> { -12, 33, 444, 56, 7 };

			var actual = source.GetNumbers();
			Assert.AreEqual(expected, actual);
		}

		[TestCase("-12")] 
		[TestCase("-12+33-444*56/7")] 
		public void GetOperators_傳回加減乘除字串List(string formula)
		{
			string source = formula;
			var expected = new List<string> { "+", "-", "*", "/" };

			var actual = source.GetOperators();
			Assert.AreEqual(expected, actual);
		}

		[Test] 
		public void MultiplcationAndDivision_傳回加減乘除字串List()
		{
			var numbersSource = new List<decimal> { -12, 33, 444, 56, 7 };
			var operatorsSource = new List<string> { "+", "-", "*", "/" };

			var expected = (new List<decimal> { -12, 33, 444 * 56 / 7 }, new List<string> { "+", "-" });

			var actual = (numbersSource.MultiplcationAndDivision(operatorsSource, out operatorsSource), operatorsSource);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AdditionAndSubstraction_輸入數字List和運算子List_傳回計算結果()
		{
			var numbersSource = new List<decimal> { 12, 33, 444 * 56 / 7 };
			var operatorsSource = new List<string> { "+", "-" };

			var expected = numbersSource.AdditionAndSubstraction(operatorsSource);

			var actual = 12 + 33 - 444 * 56 / 7;
			Assert.AreEqual(expected, actual);
		}
	}
}