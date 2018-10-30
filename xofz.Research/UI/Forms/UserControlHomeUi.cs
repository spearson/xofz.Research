namespace xofz.Research.UI.Forms
{
    using System;
    using System.Linq;
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

        public event Action BinaryVisualizerKeyTapped;

        private const string VersionFlavorText = @"v";

        string HomeUi.Version
        {
            get
            {
                var t = this.versionLabel.Text;
                if (t?.Contains(VersionFlavorText) ?? false)
                {
                    return t.Substring(VersionFlavorText.Length);
                }

                return @"0.0.0.0";
            }

            set => this.versionLabel.Text = VersionFlavorText + value;
        }

        private const string CoreVersionFlavorText = @"Powered by x(z) Core98 v";

        string HomeUi.Core98Version
        {
            get
            {
                var t = this.coreVersionLabel.Text;
                if (t?.Contains(CoreVersionFlavorText) ?? false)
                {
                    return t.Substring(CoreVersionFlavorText.Length);
                }

                return @"0.0.0.0";
            }

            set => this.coreVersionLabel.Text = CoreVersionFlavorText + value;
        }

        private void logKey_Click(object sender, EventArgs e)
        {
            var lkt = this.LogKeyTapped;
            if (lkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => lkt.Invoke());
        }

        private void binaryVisualizerKey_Click(object sender, EventArgs e)
        {
            var bvkt = this.BinaryVisualizerKeyTapped;
            if (bvkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => bvkt.Invoke());
        }
    }
}
