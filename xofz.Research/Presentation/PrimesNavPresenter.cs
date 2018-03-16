namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class PrimesNavPresenter : Presenter
    {
        public PrimesNavPresenter(
            PrimesNavUi ui, 
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
            this.ui.FactorialKeyTapped += this.ui_FactorialKeyTapped;
            this.ui.RotationKeyTapped += this.ui_RotationKeyTapped;
            this.ui.BigPowKeyTapped += this.ui_BigPowKeyTapped;
            this.ui.ControlHubKeyTapped += this.ui_ControlHubKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            UiHelpers.Write(
                this.ui,
                () => this.ui.ControlHubKeyVisible = false);

            var w = this.web;
            w.Run<AccessController>(ac =>
                ac.AccessLevelChanged += this.accessLevelChanged);
            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var level2 = newAccessLevel >= AccessLevel.Level2;
            UiHelpers.Write(
                this.ui,
                () => this.ui.ControlHubKeyVisible = level2);
        }

        private void ui_HomeKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<HomePresenter>();
                n.PresentFluidly<HomeNavPresenter>();
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

        private void ui_ControlHubKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<ControlHubPresenter>();
                n.PresentFluidly<ControlHubNavPresenter>();
            });
        }

        private void ui_LogInKeyTapped()
        {
            this.web.Run<Navigator>(
                n => n.PresentFluidly<LoginPresenter>());
        }

        private void ui_ShutdownKeyTapped()
        {
            this.web.Run<Navigator>(
                n => n.Present<ShutdownPresenter>());
        }

        private int setupIf1;
        private readonly PrimesNavUi ui;
        private readonly MethodWeb web;
    }
}
