namespace xofz.Research.UI.Forms
{
    using System;
    using System.Numerics;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlBigPowUi : UserControlUi, BigPowUi
    {
        public UserControlBigPowUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action ComputeKeyTapped;

        public event Action DisplayKeyTapped;

        public event Action SaveKeyTapped;

        BigInteger BigPowUi.NumberInput
        {
            get { return BigInteger.Parse(this.numberInputTextBox.Text); }

            set { this.numberInputTextBox.Text = value.ToString(); }
        }

        BigInteger BigPowUi.ExponentInput
        {
            get { return BigInteger.Parse(this.exponentInputTextBox.Text); }

            set { this.exponentInputTextBox.Text = value.ToString(); }
        }

        string BigPowUi.Power
        {
            get { return this.powerTextBox.Text; }

            set { this.powerTextBox.Text = value; }
        }

        string BigPowUi.DurationInfo
        {
            get { return this.durationLabel.Text; }

            set
            {
                this.durationLabel.Text = value;
                this.Refresh();
            }
        }

        bool BigPowUi.DurationInfoVisible
        {
            get { return this.durationLabel.Visible; }

            set { this.durationLabel.Visible = value; }
        }

        bool BigPowUi.DisplayKeyVisible
        {
            get { return this.displayKey.Visible; }

            set { this.displayKey.Visible = value; }
        }

        bool BigPowUi.Computing
        {
            get { return this.computeKey.Text == @"Computing..."; }

            set
            {
                this.computeKey.Text = value ? @"Computing..." : @"Compute";
                this.computeKey.Enabled = !value;
            }
        }

        bool BigPowUi.SaveKeyVisible
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
