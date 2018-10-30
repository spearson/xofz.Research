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

        public event Action MultiPowKeyTapped;

        BigInteger BigPowUi.NumberInput
        {
            get => BigInteger.Parse(this.numberInputTextBox.Text);

            set => this.numberInputTextBox.Text = value.ToString();
        }

        BigInteger BigPowUi.ExponentInput
        {
            get => BigInteger.Parse(this.exponentInputTextBox.Text);

            set => this.exponentInputTextBox.Text = value.ToString();
        }

        string BigPowUi.Power
        {
            get => this.powerTextBox.Text;

            set => this.powerTextBox.Text = value;
        }

        string BigPowUi.DurationInfo
        {
            get => this.durationLabel.Text;

            set
            {
                this.durationLabel.Text = value;
                this.Refresh();
            }
        }

        bool BigPowUi.DurationInfoVisible
        {
            get => this.durationLabel.Visible;

            set => this.durationLabel.Visible = value;
        }

        bool BigPowUi.DisplayKeyVisible
        {
            get => this.displayKey.Visible;

            set => this.displayKey.Visible = value;
        }

        bool BigPowUi.Computing
        {
            get => this.computeKey.Text == @"Computing...";

            set
            {
                this.computeKey.Text = value ? @"Computing..." : @"Compute";
                this.computeKey.Enabled = !value;
            }
        }

        bool BigPowUi.SaveKeyVisible
        {
            get => this.saveKey.Visible;

            set => this.saveKey.Visible = value;
        }

        private void computeKey_Click(object sender, EventArgs e)
        {
            var ckt = this.ComputeKeyTapped;
            if (ckt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => ckt.Invoke());
        }

        private void saveKey_Click(object sender, EventArgs e)
        {
            var skt = this.SaveKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => skt.Invoke());
        }

        private void displayKey_Click(object sender, EventArgs e)
        {
            var dkt = this.DisplayKeyTapped;
            if (dkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => dkt.Invoke());
        }

        private void multiPowKey_Click(object sender, EventArgs e)
        {
            var mpkt = this.MultiPowKeyTapped;
            if (mpkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => mpkt.Invoke());
        }
    }
}
