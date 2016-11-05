namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlHomeUi : UserControlUi, HomeUi
    {
        public UserControlHomeUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action LogKeyTapped;

        private void logKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.LogKeyTapped?.Invoke()).Start();
        }
    }
}
