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
            this.InitializeComponent();
        }

        public event Action ComputeKeyTapped;

        public event Action DisplayKeyTapped;

        public event Action SaveKeyTapped;

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

        string FactorialUi.DurationInfo
        {
            get { return this.durationLabel.Text; }

            set
            {
                this.durationLabel.Text = value;
                this.Refresh();
            }
        }

        bool FactorialUi.DurationInfoVisible
        {
            get { return this.durationLabel.Visible; }

            set { this.durationLabel.Visible = value; }
        }

        bool FactorialUi.DisplayKeyVisible
        {
            get { return this.displayKey.Visible; }

            set { this.displayKey.Visible = value; }
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

        bool FactorialUi.SaveKeyVisible
        {
            get { return this.saveKey.Visible; }

            set { this.saveKey.Visible = value; }
        }

        private void computeKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.ComputeKeyTapped?.Invoke()).Start();
        }

        private void saveKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.SaveKeyTapped?.Invoke()).Start();
        }

        private void displayKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.DisplayKeyTapped?.Invoke()).Start();
        }
    }
}
