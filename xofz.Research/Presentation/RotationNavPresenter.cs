namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class RotationNavPresenter : Presenter
    {
        public RotationNavPresenter(
            RotationNavUi ui, 
            ShellUi shell,
            Navigator navigator,
            AccessController accessController,
            xofz.Framework.Timer timer) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.navigator = navigator;
            this.accessController = accessController;
            this.timer = timer;
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
            this.ui.ControlHubKeyTapped += this.ui_ControlHubKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;

            this.navigator.RegisterPresenter(this);
        }

        public override void Start()
        {
            this.timer_Elapsed();
            base.Start();

            this.timer.Start(1000);
        }

        public override void Stop()
        {
            this.timer.Stop();
        }

        private void ui_HomeKeyTapped()
        {
            this.navigator.Present<HomePresenter>();
            this.navigator.PresentFluidly<HomeNavPresenter>();
        }

        private void ui_PrimesKeyTapped()
        {
            this.navigator.Present<PrimesPresenter>();
            this.navigator.PresentFluidly<PrimesNavPresenter>();
        }

        private void ui_FactorialKeyTapped()
        {
            this.navigator.Present<FactorialPresenter>();
            this.navigator.PresentFluidly<FactorialNavPresenter>();
        }

        private void ui_ControlHubKeyTapped()
        {
            this.navigator.Present<ControlHubPresenter>();
            this.navigator.PresentFluidly<ControlHubNavPresenter>();
        }

        private void ui_LogInKeyTapped()
        {
            this.navigator.PresentFluidly<LoginPresenter>();
        }

        private void ui_ShutdownKeyTapped()
        {
            this.navigator.Present<ShutdownPresenter>();
        }

        private void timer_Elapsed()
        {
            var level2 = this.accessController.CurrentAccessLevel > AccessLevel.Level1;
            UiHelpers.Write(this.ui, () => this.ui.ControlHubKeyVisible = level2);
        }

        private int setupIf1;
        private readonly RotationNavUi ui;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
    }
}
