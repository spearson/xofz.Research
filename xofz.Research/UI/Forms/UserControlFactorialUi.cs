namespace xofz.Research.UI.Forms
{
    using System;
    using System.Numerics;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlFactorialUi : UserControlUi, FactorialUi
    {
        public UserControlFactorialUi()
        {
            InitializeComponent();

            var h = this.Handle;
        }

        public event Action ComputeKeyTapped;

        BigInteger FactorialUi.Input
        {
            get { return BigInteger.Parse(this.inputTextBox.Text); }

            set { this.inputTextBox.Text = value.ToString(); }
        }

        string FactorialUi.Factorial
        {
            get { return this.factorialTextBox.Text; }

            set { this.factorialTextBox.Text = value; }
        }

        bool FactorialUi.Computing
        {
            get { return this.computeKey.Text == @"Computing..."; }

            set
            {
                this.computeKey.Text = value ? @"Computing..." : @"Compute";
                this.computeKey.Enabled = !value;
            }
        }

        private void computeKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.ComputeKeyTapped?.Invoke()).Start();
        }
    }
}
