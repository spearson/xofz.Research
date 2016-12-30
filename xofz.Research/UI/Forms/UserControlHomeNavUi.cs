﻿namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlHomeNavUi : UserControlUi, HomeNavUi
    {
        public UserControlHomeNavUi()
        {
            this.InitializeComponent();
        }

        public event Action HomeKeyTapped;

        public event Action PrimesKeyTapped;

        public event Action FactorialKeyTapped;

        public event Action RotationKeyTapped;

        public event Action BigPowKeyTapped;

        public event Action ControlHubKeyTapped;

        public event Action LogInKeyTapped;

        public event Action ShutdownKeyTapped;

        bool HomeNavUi.ControlHubKeyVisible
        {
            get { return this.controlHubKey.Visible; }

            set { this.controlHubKey.Visible = value; }
        }

        private void homeKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.HomeKeyTapped?.Invoke()).Start();
        }

        private void primesKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.PrimesKeyTapped?.Invoke()).Start();
        }

        private void factorialKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.FactorialKeyTapped?.Invoke()).Start();
        }

        private void rotationKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RotationKeyTapped?.Invoke()).Start();
        }

        private void bigPowKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.BigPowKeyTapped?.Invoke()).Start();
        }

        private void controlHubKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.ControlHubKeyTapped?.Invoke()).Start();
        }

        private void loginKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.LogInKeyTapped?.Invoke()).Start();
        }

        private void shutdownKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.ShutdownKeyTapped?.Invoke()).Start();
        }
    }
}
