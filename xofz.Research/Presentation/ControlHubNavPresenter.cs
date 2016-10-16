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
            this.ui.RotationKeyTapped += this.ui_RotationKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;
            this.navigator.RegisterPresenter(this);
        }

        private void timer_Elapsed()
        {
            if (this.accessController.CurrentAccessLevel < AccessLevel.Level2)
            {
                this.navigator.Present<HomePresenter>();
                this.navigator.PresentFluidly<HomeNavPresenter>();
            }
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

        private void ui_RotationKeyTapped()
        {
            this.navigator.Present<RotationPresenter>();
            this.navigator.PresentFluidly<RotationNavPresenter>();
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
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
    }
}
