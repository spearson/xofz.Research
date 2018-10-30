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

            var w = this.web;
            w.Run<EventSubscriberV2>(subV2 =>
            {
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.HomeKeyTapped),
                    this.ui_HomeKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.PrimesKeyTapped),
                    this.ui_PrimesKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.FactorialKeyTapped),
                    this.ui_FactorialKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.BigPowKeyTapped),
                    this.ui_BigPowKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.ControlHubKeyTapped),
                    this.ui_ControlHubKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.LogInKeyTapped),
                    this.ui_LogInKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.ShutdownKeyTapped),
                    this.ui_ShutdownKeyTapped);
            });

            w.Run<AccessController, EventSubscriber>((ac, sub) =>
            {
                sub.Subscribe<AccessLevel>(
                    ac,
                    nameof(ac.AccessLevelChanged),
                    this.accessLevelChanged);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
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
            this.web.Run<Navigator>(n => n.PresentFluidly<LoginPresenter>());
        }

        private void ui_ShutdownKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<ShutdownPresenter>());
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var level2 = newAccessLevel >= AccessLevel.Level2;
            UiHelpers.Write(
                this.ui,
                () => this.ui.ControlHubKeyVisible = level2);
        }

        private int setupIf1;
        private readonly RotationNavUi ui;
        private readonly MethodWeb web;
    }
}
