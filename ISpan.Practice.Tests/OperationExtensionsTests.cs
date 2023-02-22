using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class OperationExtensionsTests
	{
		[Test]
		public void MultiplcationAndDivision_傳回加減乘除字串List和先乘除後的結果()
		{
			var numbersSource = new List<decimal> { -12, 33, 444, 56, 7 };
			var operatorsSource = new List<string> { "+", "-", "*", "/" };

			var expected = (new List<decimal> { -12, 33, 444 * 56 / 7 }, new List<string> { "+", "-" });

			var actual = (numbersSource.MultiplcationAndDivision(ref operatorsSource), operatorsSource);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AdditionAndSubstraction_輸入數字List和運算子List_傳回計算結果()
		{
			var numbersSource = new List<decimal> { -12, 33, 444 * 56 / 7 };
			var operatorsSource = new List<string> { "+", "-" };

			var expected = numbersSource.AdditionAndSubstraction(operatorsSource);

			var actual = -12 + 33 - 444 * 56 / 7;
			Assert.AreEqual(expected, actual);
		}
	}
}