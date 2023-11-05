using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Veh
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			method_0();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void method_0()
		{
			SuspendLayout();
			AutoScaleDimensions = new SizeF(9, 18);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Name = "Form1";
			Text = "Form1";
            Load += Form1_Load;
			ResumeLayout(false);
		}
	}
}
