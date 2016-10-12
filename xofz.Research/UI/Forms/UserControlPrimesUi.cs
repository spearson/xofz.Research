namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlPrimesUi : UserControlUi, PrimesUi
    {
        public UserControlPrimesUi()
        {
            InitializeComponent();

            var h = this.Handle;
        }

        public event Action GenerateKeyTapped;

        public event Action StopKeyTapped;

        public event Action RestartKeyTapped;

        public event Action SaveKeyTapped;
        
        public event Action LoadKeyTapped;

        string PrimesUi.LoadLocation
        {
            get { return this.locator.FileName; }

            set { this.locator.FileName = value; }
        }

        bool PrimesUi.Generating
        {
            get { return this.generateKey.Text == @"Generating..."; }

            set
            {
                this.generateKey.Text = value ? @"Generating..." : "Generate";
                this.generateKey.Enabled = !value;
            }
        }

        bool PrimesUi.Stopping
        {
            get { return this.stopKey.Text == @"Stopping..."; }

            set
            {
                this.stopKey.Text = value ? @"Stopping..." : "Stop";
                this.stopKey.Enabled = !value;
            }
        }

        bool PrimesUi.RestartKeyVisible
        {
            get { return this.restartKey.Visible; }

            set { this.restartKey.Visible = value; }
        }

        bool PrimesUi.StopKeyVisible
        {
            get { return this.stopKey.Visible; }

            set { this.stopKey.Visible = value; }
        }

        bool PrimesUi.LoadKeyVisible
        {
            get { return this.loadKey.Visible; }

            set { this.loadKey.Visible = value; }
        }

        int PrimesUi.NumberToGenerate
        {
            get { return int.Parse(this.numberToGenerateTextBox.Text); }

            set { this.numberToGenerateTextBox.Text = value.ToString(); }
        }

        long? PrimesUi.CurrentPrime
        {
            get
            {
                return long.Parse(this.currentPrimeLabel.Text);
            }

            set { this.currentPrimeLabel.Text = value.ToString(); }
        }

        int? PrimesUi.CurrentPrimeIndex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.currentPrimeIndexLabel.Text))
                {
                    return null;
                }

                return int.Parse(this.currentPrimeIndexLabel.Text);
            }

            set { this.currentPrimeIndexLabel.Text = value.ToString(); }
        }

        void PrimesUi.DisplayLoadLocator()
        {
            this.locator.ShowDialog();
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.GenerateKeyTapped?.Invoke()).Start();
        }

        private void restartKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RestartKeyTapped?.Invoke()).Start();
        }

        private void saveKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.SaveKeyTapped?.Invoke()).Start();
        }

        private void stopKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.StopKeyTapped?.Invoke()).Start();
        }

        private void loadKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.LoadKeyTapped?.Invoke()).Start();
        }
    }
}
