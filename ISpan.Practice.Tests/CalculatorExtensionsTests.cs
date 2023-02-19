using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class CalculatorExtensionsTests
	{
		[TestCase("-12+33-444*56/7")] // Attribute�S�x��
		public void GetNumbers_�Ǧ^decimal�ƦrList(string formula)
		{
			string source = formula;
			var expected = new List<decimal> { -12, 33, 444, 56, 7 };

			var actual = source.GetNumbers();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetOperators_�Ǧ^�[����r��List()
		{
			string source = "-12+33-444*56/7";
			var expected = new List<string> { "+", "-", "*", "/" };

			var actual = source.GetOperators();
			Assert.AreEqual(expected, actual);
		}

		public void MultiplcationAndDivision_�Ǧ^�[����r��List()
		{
			var numbersSource = new List<decimal> { -12, 33, 444, 56, 7 };
			var operatorsSource = new List<string> { "+", "-", "*", "/" };

			var expected = (new List<decimal> { 12, 33, 444 * 56 / 7 }, new List<string> { "+", "-" });

			var actual = (numbersSource.MultiplcationAndDivision(operatorsSource, out operatorsSource), operatorsSource);
			Assert.AreEqual(expected, actual);
		}
		public void AdditionAndSubstraction_��J�ƦrList�M�B��lList_�Ǧ^�p�⵲�G()
		{
			var numbersSource = new List<decimal> { 12, 33, 444 * 56 / 7 };
			var operatorsSource = new List<string> { "+", "-" };

			var expected = numbersSource.AdditionAndSubstraction(operatorsSource);

			var actual = 12 + 33 - 444 * 56 / 7;
			Assert.AreEqual(expected, actual);
		}
	}
}