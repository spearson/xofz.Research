namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class FactorialNavPresenter : Presenter
    {
        public FactorialNavPresenter(
            FactorialNavUi ui, 
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
            this.ui.RotationKeyTapped += this.ui_RotationKeyTapped;
            this.ui.BigPowKeyTapped += this.ui_BigPowKeyTapped;
            this.ui.ControlHubKeyTapped += this.ui_ControlHubKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            this.web.Subscribe<xofz.Framework.Timer>(
                "Elapsed", 
                this.timer_Elapsed, 
                "FactorialNavTimer");

            this.navigator.RegisterPresenter(this);
        }

        public override void Start()
        {
            this.timer_Elapsed();
            base.Start();

            this.web.Run<xofz.Framework.Timer>(t => t.Start(1000), "FactorialNavTimer");
        }

        public override void Stop()
        {
            this.web.Run<xofz.Framework.Timer>(t => t.Stop(), "FactorialNavTimer");
        }

        private void timer_Elapsed()
        {
            var cal = this.web.Run<AccessController, AccessLevel>(
                ac => ac.CurrentAccessLevel);
            var level2 = cal > AccessLevel.Level1;
            UiHelpers.Write(
                this.ui,
                () => this.ui.ControlHubKeyVisible = level2);
        }

        private void ui_ControlHubKeyTapped()
        {
            var n = this.navigator;
            n.Present<ControlHubPresenter>();
            n.PresentFluidly<ControlHubNavPresenter>();
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
        private readonly FactorialNavUi ui;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
