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

        bool PrimesUi.Generating
        {
            get { return this.generateKey.Text == @"Generating..."; }

            set { this.generateKey.Text = value ? @"Generating..." : "Generate"; }
        }

        int PrimesUi.NumberToGenerate
        {
            get { return int.Parse(this.numberToGenerateTextBox.Text); }

            set { this.numberToGenerateTextBox.Text = value.ToString(); }
        }

        long PrimesUi.CurrentPrime
        {
            get { return long.Parse(this.currentPrimeLabel.Text); }

            set { this.currentPrimeLabel.Text = value.ToString(); }
        }

        int PrimesUi.CurrentPrimeIndex
        {
            get { return int.Parse(this.currentPrimeIndexLabel.Text); }

            set { this.currentPrimeIndexLabel.Text = value.ToString(); }
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.GenerateKeyTapped?.Invoke()).Start();
        }
    }
}
