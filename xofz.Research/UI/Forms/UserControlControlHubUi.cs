namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlControlHubUi : UserControlUi, ControlHubUi
    {
        public UserControlControlHubUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action StopPrimesKeyTapped;

        private void stopPrimesKey_Click(object sender, EventArgs e)
        {
            var spkt = this.StopPrimesKeyTapped;
            if (spkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => spkt.Invoke());
        }
    }
}
