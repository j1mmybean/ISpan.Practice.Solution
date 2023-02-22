using ISpan.Practice.Utilities;

namespace ISpan.Practice.Tests
{
	public class FormulaExtensionsTests
	{

		[TestCase("-12+(33-444)*(56/7+8)")] // Attribute�S�x��
		public void GetSubFormula_�Ǧ^Formula���Ĥ@��subFormula�r��(string formula)
		{
			string source = formula;
			var expected = "33-444";

			var actual = source.GetSubFormula();
			Assert.AreEqual(expected, actual);
		}

		[TestCase("-12+-33--444*56/7")]
		public void GetNumbers_�Ǧ^decimal�ƦrList(string formula)
		{
			string source = formula;
			var expected = new List<decimal> { -12, -33, -444, 56, 7 };

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
	}
}