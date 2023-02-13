using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISpan.Practice.Utilities;

namespace ISpan.Practice.Winform
{

	public partial class FormCalculator : Form
	{
		Calculator calculator = new Calculator();
		public FormCalculator()
		{
			InitializeComponent();

			#region Collection of buttonClick

			button0.Click += ButtonNumber_Click;
			button1.Click += ButtonNumber_Click;
			button2.Click += ButtonNumber_Click;
			button3.Click += ButtonNumber_Click;
			button4.Click += ButtonNumber_Click;
			button5.Click += ButtonNumber_Click;
			button6.Click += ButtonNumber_Click;
			button7.Click += ButtonNumber_Click;
			button8.Click += ButtonNumber_Click;
			button9.Click += ButtonNumber_Click;
			buttonClear.Click += ButtonClear_Click;
			buttonAddition.Click += ButtonOperation_Click;
			buttonSubtraction.Click += ButtonOperation_Click;
			buttonMultiplication.Click += ButtonOperation_Click;
			buttonDivision.Click += ButtonOperation_Click;
			buttonEqual.Click += ButtonEqual_Click;
			buttonDelete.Click += ButtonDelete_Click;
			#endregion
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			calculator.Delete();

			labelFormula.Text = calculator.Formula;
			labelResult.Text = "= " + calculator.Calculate();
		}

		private void ButtonNumber_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			calculator.InputNumber(button.Text);

			labelFormula.Text = calculator.Formula;
			labelResult.Text = "= " + calculator.Calculate();
		}

		private void ButtonOperation_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			calculator.InputOperator(button.Text);

			labelFormula.Text = calculator.Formula;
		}

		private void ButtonEqual_Click(object sender, EventArgs e)
		{
			labelFormula.Text = calculator.Formula + " = " + calculator.Calculate();
			labelResult.Text = "= " + calculator.Calculate();

			calculator.Equal();
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			calculator.Clear();
			labelFormula.Text = calculator.Formula;
			labelResult.Text = "0";
		}
	}
}
