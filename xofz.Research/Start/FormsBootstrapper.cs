namespace xofz.Research.Start
{
    using System;
    using System.Windows.Forms;
    using Framework;
    using Presentation;
    using UI.Forms;
    using xofz.Framework;
    using xofz.Framework.Computation;
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
                this.navigator);
            mp.Setup();

            var hnp = new HomeNavPresenter(
                new UserControlHomeNavUi(), 
                this.shell.NavUi,
                this.navigator);
            hnp.Setup();

            var hp = new HomePresenter(
                new UserControlHomeUi(), 
                this.shell);
            hp.Setup(this.navigator);

            var rnp = new RotationNavPresenter(
                new UserControlRotationNavUi(), 
                this.shell.NavUi,
                this.navigator);
            rnp.Setup();

            var rp = new RotationPresenter(
                new UserControlRotationUi(
                    list => new OrderedMaterializedEnumerable<TextBox>(list),
                    ll => new LinkedListMaterializedEnumerable<int>(ll)),
                this.shell,
                new Random(),
                new EnumerableRotator());
            rp.Setup(this.navigator);

            var pnp = new PrimesNavPresenter(
                new UserControlPrimesNavUi(), 
                this.shell.NavUi,
                this.navigator);
            pnp.Setup();

            var pp = new PrimesPresenter(
                new UserControlPrimesUi(),
                this.shell,
                ll => ll == null ? new PrimeGenerator() : new PrimeGenerator(ll),
                new PrimeManager(),
                new FormsMessenger { Subscriber = this.shell });
            pp.Setup(this.navigator);

            var fnp = new FactorialNavPresenter(
                new UserControlFactorialNavUi(), 
                this.shell.NavUi,
                this.navigator);
            fnp.Setup();

            var fp = new FactorialPresenter(
                new UserControlFactorialUi(), 
                this.shell,
                new FactorialComputer());
            fp.Setup(this.navigator);

            var sp = new ShutdownPresenter(
                this.shell,
                () => { });
            this.navigator.RegisterPresenter(sp);

            this.navigator.Present<HomePresenter>();
            this.navigator.PresentFluidly<HomeNavPresenter>();
        }

        private FormMainUi shell;
        private readonly Navigator navigator;
    }
}
