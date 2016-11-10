namespace xofz.Research.UI.Forms
{
    using System;
    using System.Numerics;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlBinaryVisualizerUi : UserControlUi, BinaryVisualizerUi
    {
        public UserControlBinaryVisualizerUi()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action TranslateKeyTapped;

        BigInteger BinaryVisualizerUi.Input
        {
            get { return BigInteger.Parse(this.inputTextBox.Text); }

            set { this.inputTextBox.Text = value.ToString(); }
        }

        string BinaryVisualizerUi.Binary
        {
            get { return this.binaryTextBox.Text; }

            set { this.binaryTextBox.Text = value; }
        }

        bool BinaryVisualizerUi.Translating
        {
            get { return this.translateKey.Text == @"Translating..."; }

            set
            {
                this.translateKey.Text = value ? @"Translating..." : @"Translate";
                this.translateKey.Enabled = !value;
            }
        }

        private void translateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.TranslateKeyTapped?.Invoke()).Start();
        }
    }
}
