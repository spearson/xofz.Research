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
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
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

            var w = this.web;
            w.Run<AccessController>(ac => ac.AccessLevelChanged
                += this.accessLevelChanged);
            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
            base.Start();
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 0, 1);
        }

        private void ui_HomeKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<HomePresenter>();
                n.PresentFluidly<HomeNavPresenter>();
            });
        }

        private void ui_PrimesKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<PrimesPresenter>();
                n.PresentFluidly<PrimesNavPresenter>();
            });
        }

        private void ui_FactorialKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<FactorialPresenter>();
                n.PresentFluidly<FactorialNavPresenter>();
            });
        }

        private void ui_RotationKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<RotationPresenter>();
                n.PresentFluidly<RotationNavPresenter>();
            });
        }

        private void ui_BigPowKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<BigPowPresenter>();
                n.PresentFluidly<BigPowNavPresenter>();
            });
        }

        private void ui_LogInKeyTapped()
        {
            this.web.Run<Navigator>(n => n.PresentFluidly<LoginPresenter>());
        }

        private void ui_ShutdownKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<ShutdownPresenter>());
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            if (Interlocked.Read(ref this.startedIf1) == 0)
            {
                return;
            }

            var w = this.web;
            w.Run<Navigator>(n =>
            {
                if (newAccessLevel < AccessLevel.Level2)
                {
                    n.Present<HomePresenter>();
                    n.PresentFluidly<HomeNavPresenter>();
                }
            });
        }

        private int setupIf1;
        private long startedIf1;
        private readonly ControlHubNavUi ui;
        private readonly MethodWeb web;
    }
}
