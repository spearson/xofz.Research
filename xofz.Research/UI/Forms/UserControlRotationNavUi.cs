﻿namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlRotationNavUi : UserControlUi, RotationNavUi
    {
        public UserControlRotationNavUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action HomeKeyTapped;

        public event Action PrimesKeyTapped;

        public event Action FactorialKeyTapped;

        public event Action BigPowKeyTapped;

        public event Action ControlHubKeyTapped;

        public event Action LogInKeyTapped;

        public event Action ShutdownKeyTapped;

        bool RotationNavUi.ControlHubKeyVisible
        {
            get => this.controlHubKey.Visible;

            set => this.controlHubKey.Visible = value;
        }

        private void homeKey_Click(object sender, EventArgs e)
        {
            var hkt = this.HomeKeyTapped;
            if (hkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => hkt.Invoke());
        }

        private void primesKey_Click(object sender, EventArgs e)
        {
            var pkt = this.PrimesKeyTapped;
            if (pkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => pkt.Invoke());
        }

        private void factorialKey_Click(object sender, EventArgs e)
        {
            var fkt = this.FactorialKeyTapped;
            if (fkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => fkt.Invoke());
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

        private void controlHubKey_Click(object sender, EventArgs e)
        {
            var chkt = this.ControlHubKeyTapped;
            if (chkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => chkt.Invoke());
        }

        private void loginKey_Click(object sender, EventArgs e)
        {
            var likt = this.LogInKeyTapped;
            if (likt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => likt.Invoke());
        }

        private void shutdownKey_Click(object sender, EventArgs e)
        {
            var skt = this.ShutdownKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => skt.Invoke());
        }
    }
}
