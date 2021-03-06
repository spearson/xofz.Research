﻿namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlPrimesUi : UserControlUi, PrimesUi
    {
        public UserControlPrimesUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action GenerateKeyTapped;

        public event Action StopKeyTapped;

        public event Action RestartKeyTapped;

        public event Action SaveKeyTapped;
        
        public event Action LoadKeyTapped;

        string PrimesUi.LoadLocation
        {
            get => this.locator.FileName;

            set => this.locator.FileName = value;
        }

        bool PrimesUi.Generating
        {
            get => this.generateKey.Text == @"Generating...";

            set
            {
                this.generateKey.Text = value ? @"Generating..." : "Generate";
                this.generateKey.Enabled = !value;
            }
        }

        bool PrimesUi.Stopping
        {
            get => this.stopKey.Text == @"Stopping...";

            set
            {
                this.stopKey.Text = value ? @"Stopping..." : "Stop";
                this.stopKey.Enabled = !value;
            }
        }

        bool PrimesUi.RestartKeyVisible
        {
            get => this.restartKey.Visible;

            set => this.restartKey.Visible = value;
        }

        bool PrimesUi.StopKeyVisible
        {
            get => this.stopKey.Visible;

            set => this.stopKey.Visible = value;
        }

        bool PrimesUi.LoadKeyVisible
        {
            get => this.loadKey.Visible;

            set => this.loadKey.Visible = value;
        }

        bool PrimesUi.SaveKeyVisible
        {
            get => this.saveKey.Visible;

            set => this.saveKey.Visible = value;
        }

        int PrimesUi.NumberToGenerate
        {
            get => int.Parse(this.numberToGenerateTextBox.Text);

            set => this.numberToGenerateTextBox.Text = value.ToString();
        }

        long? PrimesUi.CurrentPrime
        {
            get => long.Parse(this.currentPrimeLabel.Text);

            set => this.currentPrimeLabel.Text = value.ToString();
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

            set => this.currentPrimeIndexLabel.Text = value.ToString();
        }

        void PrimesUi.DisplayLoadLocator()
        {
            this.locator.ShowDialog();
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            var gkt = this.GenerateKeyTapped;
            if (gkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => gkt.Invoke());
        }

        private void restartKey_Click(object sender, EventArgs e)
        {
            var rkt = this.RestartKeyTapped;
            if (rkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => rkt.Invoke());
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

        private void stopKey_Click(object sender, EventArgs e)
        {
            var skt = this.StopKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => skt.Invoke());
        }

        private void loadKey_Click(object sender, EventArgs e)
        {
            var lkt = this.LoadKeyTapped;
            if (lkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => lkt.Invoke());
        }
    }
}
