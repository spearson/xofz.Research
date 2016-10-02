namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlHomeNavUi : UserControlUi, HomeNavUi
    {
        public UserControlHomeNavUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action LogInKeyTapped;

        public event Action ShutdownKeyTapped;
       
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
