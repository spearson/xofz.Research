namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class FormMainUi : FormUi, MainUi
    {
        public FormMainUi()
        {
            InitializeComponent();
            var h = this.Handle;
        }

        public event Action ShutdownRequested;

        public ShellUi NavUi => this.navUi;

        private void this_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            new Thread(() => this.ShutdownRequested?.Invoke()).Start();
        }
    }
}
