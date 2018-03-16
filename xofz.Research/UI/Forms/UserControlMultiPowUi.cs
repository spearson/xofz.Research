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
            new Thread(() => this.ComputeKeyTapped?.Invoke()).Start();
        }

        private void bigPowKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.BigPowKeyTapped?.Invoke()).Start();
        }

        private void displayKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.DisplayKeyTapped?.Invoke()).Start();
        }

        private void saveKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.SaveKeyTapped?.Invoke()).Start();
        }
    }
}
