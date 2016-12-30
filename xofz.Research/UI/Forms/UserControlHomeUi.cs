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
        }

        public event Action LogKeyTapped;

        public event Action BinaryVisualizerKeyTapped;

        private void logKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.LogKeyTapped?.Invoke()).Start();
        }

        private void binaryVisualizerKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.BinaryVisualizerKeyTapped?.Invoke()).Start();
        }
    }
}
