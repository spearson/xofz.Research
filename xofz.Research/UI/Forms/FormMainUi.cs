namespace xofz.Research.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class FormMainUi : FormUi, MainUi
    {
        public FormMainUi()
        {
            InitializeComponent();
            var h = this.Handle;
        }

        public event Action LoginKeyTapped;

        private void loginKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.LoginKeyTapped?.Invoke()).Start();
        }
    }
}
