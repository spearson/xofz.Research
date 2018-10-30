namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlMultiPowUi : UserControlUi, MultiPowUi
    {
        public UserControlMultiPowUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action ComputeKeyTapped;

        public event Action DisplayKeyTapped;

        public event Action SaveKeyTapped;

        public event Action BigPowKeyTapped;

        string MultiPowUi.PowersInput
        {
            get => this.powersInputTextBox.Text;

            set => this.powersInputTextBox.Text = value;
        }

        string MultiPowUi.MultiPower
        {
            get => this.multiPowerTextBox.Text;

            set => this.multiPowerTextBox.Text = value;
        }

        string MultiPowUi.DurationInfo
        {
            get => this.durationLabel.Text;

            set
            {
                this.durationLabel.Text = value;
                this.Refresh();
            }
        }

        bool MultiPowUi.DurationInfoVisible
        {
            get => this.durationLabel.Visible;

            set => this.durationLabel.Visible = value;
        }

        bool MultiPowUi.DisplayKeyVisible
        {
            get => this.displayKey.Visible;

            set => this.displayKey.Visible = value;
        }

        bool MultiPowUi.Computing
        {
            get => this.computeKey.Text == @"Computing...";

            set
            {
                this.computeKey.Text = value ? @"Computing..." : @"Compute";
                this.computeKey.Enabled = !value;
            }
        }

        bool MultiPowUi.SaveKeyVisible
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

        private void bigPowKey_Click(object sender, EventArgs e)
        {
            var bpkt = this.BigPowKeyTapped;
            if (bpkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => bpkt.Invoke());
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

        private void saveKey_Click(object sender, EventArgs e)
        {
            var skt = this.SaveKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => skt.Invoke());
        }
    }
}
