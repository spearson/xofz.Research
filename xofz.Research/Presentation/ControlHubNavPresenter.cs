namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class ControlHubNavPresenter : Presenter
    {
        public ControlHubNavPresenter(
            ControlHubNavUi ui, 
            ShellUi shell,
            Navigator navigator,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.navigator = navigator;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.HomeKeyTapped += this.ui_HomeKeyTapped;
            this.ui.PrimesKeyTapped += this.ui_PrimesKeyTapped;
            this.ui.FactorialKeyTapped += this.ui_FactorialKeyTapped;
            this.ui.RotationKeyTapped += this.ui_RotationKeyTapped;
            this.ui.BigPowKeyTapped += this.ui_BigPowKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;

            this.web.Subscribe<xofz.Framework.Timer>(
                "Elapsed",
                this.timer_Elapsed,
                "ControlHubNavTimer");

            this.navigator.RegisterPresenter(this);
        }

        private void timer_Elapsed()
        {
            var cal = this.web.Run<AccessController, AccessLevel>(
                ac => ac.CurrentAccessLevel);
            if (cal < AccessLevel.Level2)
            {
                this.navigator.Present<HomePresenter>();
                this.navigator.PresentFluidly<HomeNavPresenter>();
            }
        }

        public override void Start()
        {
            this.timer_Elapsed();
            base.Start();

            this.web.Run<xofz.Framework.Timer>(
                t => t.Start(1000),
                "ControlHubNavTimer");
        }

        public override void Stop()
        {
            this.web.Run<xofz.Framework.Timer>(
                t => t.Stop(),
                "ControlHubNavTimer");
        }

        private void ui_HomeKeyTapped()
        {
            var n = this.navigator;
            n.Present<HomePresenter>();
            n.PresentFluidly<HomeNavPresenter>();
        }

        private void ui_PrimesKeyTapped()
        {
            var n = this.navigator;
            n.Present<PrimesPresenter>();
            n.PresentFluidly<PrimesNavPresenter>();
        }

        private void ui_FactorialKeyTapped()
        {
            var n = this.navigator;
            n.Present<FactorialPresenter>();
            n.PresentFluidly<FactorialNavPresenter>();
        }

        private void ui_RotationKeyTapped()
        {
            var n = this.navigator;
            n.Present<RotationPresenter>();
            n.PresentFluidly<RotationNavPresenter>();
        }

        private void ui_BigPowKeyTapped()
        {
            var n = this.navigator;
            n.Present<BigPowPresenter>();
            n.PresentFluidly<BigPowNavPresenter>();
        }

        private void ui_LogInKeyTapped()
        {
            this.navigator.PresentFluidly<LoginPresenter>();
        }

        private void ui_ShutdownKeyTapped()
        {
            this.navigator.Present<ShutdownPresenter>();
        }

        private int setupIf1;
        private readonly ControlHubNavUi ui;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
