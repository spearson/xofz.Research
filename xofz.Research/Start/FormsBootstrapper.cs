namespace xofz.Research.Start
{
    using System;
    using System.Windows.Forms;
    using Framework;
    using Presentation;
    using UI.Forms;
    using xofz.Framework.Materialization;
    using xofz.Framework.Transformation;
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

            var hnp = new HomeNavPresenter(
                new UserControlHomeNavUi(), 
                this.shell.NavUi,
                this.navigator);
            hnp.Setup();

            var hp = new HomePresenter(
                new UserControlHomeUi(
                    list => new OrderedMaterializedEnumerable<TextBox>(list),
                    ll => new LinkedListMaterializedEnumerable<int>(ll)),
                this.shell,
                new Random(),
                new EnumerableRotator());
            hp.Setup(this.navigator);

            var sp = new ShutdownPresenter(
                this.shell, null, () => { });
            this.navigator.RegisterPresenter(sp);

            this.navigator.PresentFluidly<HomeNavPresenter>();
            this.navigator.Present<HomePresenter>();
        }

        private FormMainUi shell;
        private readonly Navigator navigator;
    }
}
