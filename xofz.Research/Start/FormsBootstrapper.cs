namespace xofz.Research.Start
{
    using System.Windows.Forms;
    using Framework;
    using Presentation;
    using UI.Forms;
    using xofz.Presentation;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper(Navigator navigator)
        {
            this.navigator = navigator;
        }

        public Form Shell => this.shell;

        public void Bootstrap()
        {
            this.shell = new FormMainUi();
            var lp = new LoginPresenter(
                new FormLoginUi(this.shell),
                new xofz.Framework.Timer(),
                new AccessController(new[] {"2554", "8384"}));
            lp.Setup(this.navigator);

            var mp = new MainPresenter(
                this.shell, 
                null, 
                this.navigator);
            mp.Setup();
        }

        private FormMainUi shell;
        private readonly Navigator navigator;
    }
}
