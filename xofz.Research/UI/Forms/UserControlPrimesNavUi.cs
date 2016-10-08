namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlPrimesNavUi : UserControlUi, PrimesNavUi
    {
        public UserControlPrimesNavUi()
        {
            InitializeComponent();

            var h = this.Handle;
        }

        public event Action RotationKeyTapped;

        public event Action LogInKeyTapped;

        public event Action ShutdownKeyTapped;

        private void rotationKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RotationKeyTapped?.Invoke()).Start();
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
