namespace xofz.Research.UI.Forms
{
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class UserControlNavUi : UserControlUi, ShellUi
    {
        public UserControlNavUi()
        {
            this.InitializeComponent();
        }

        void ShellUi.SwitchUi(Ui newUi)
        {
            var control = newUi as Control;
            control.SafeReplace(this.navUiPanel);
        }
    }
}
