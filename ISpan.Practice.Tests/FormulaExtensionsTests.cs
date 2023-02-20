using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class FormulaExtensionsTests
	{
		[TestCase("-12+33-444*56/7")] // Attribute特徵項
		public void GetNumbers_傳回decimal數字List(string formula)
		{
			string source = formula;
			var expected = new List<decimal> { -12, 33, 444, 56, 7 };

			var actual = source.GetNumbers();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetOperators_傳回加減乘除字串List()
		{
			string source = "-12+33-444*56/7";
			var expected = new List<string> { "+", "-", "*", "/" };

			var actual = source.GetOperators();
			Assert.AreEqual(expected, actual);
		}
	}
}