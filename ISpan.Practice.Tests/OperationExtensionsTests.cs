using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class OperationExtensionsTests
	{
		[Test]
		public void MultiplcationAndDivision_�Ǧ^�[����r��List�M�������᪺���G()
		{
			var numbersSource = new List<decimal> { -12, 33, 444, 56, 7 };
			var operatorsSource = new List<string> { "+", "-", "*", "/" };

			var expected = (new List<decimal> { -12, 33, 444 * 56 / 7 }, new List<string> { "+", "-" });

			var actual = (numbersSource.MultiplcationAndDivision(ref operatorsSource), operatorsSource);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AdditionAndSubstraction_��J�ƦrList�M�B��lList_�Ǧ^�p�⵲�G()
		{
			var numbersSource = new List<decimal> { -12, 33, 444 * 56 / 7 };
			var operatorsSource = new List<string> { "+", "-" };

			var expected = numbersSource.AdditionAndSubstraction(operatorsSource);

			var actual = -12 + 33 - 444 * 56 / 7;
			Assert.AreEqual(expected, actual);
		}
	}
}