namespace xofz.Research.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Research.UI;
    using xofz.UI;

    public sealed class BigPowNavPresenter : Presenter
    {
        public BigPowNavPresenter(
            BigPowNavUi ui, 
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
            w.Run<EventSubscriberV2>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.HomeKeyTapped),
                    this.ui_HomeKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.PrimesKeyTapped),
                    this.ui_PrimesKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.FactorialKeyTapped),
                    this.ui_FactorialKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.RotationKeyTapped),
                    this.ui_RotationKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.LogInKeyTapped),
                    this.ui_LogInKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.ShutdownKeyTapped),
                    this.ui_ShutdownKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.ControlHubKeyTapped),
                    this.ui_ControlHubKeyTapped);
                w.Run<AccessController>(ac =>
                {
                    Do<AccessLevel> alc = this.accessLevelChanged;
                    subscriber.Subscribe(
                        ac,
                        nameof(ac.AccessLevelChanged),
                        alc);
                });
            });

            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.ControlHubKeyVisible = false;
                });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var level2 = newAccessLevel >= AccessLevel.Level2;
            UiHelpers.Write(
                this.ui,
                () => this.ui.ControlHubKeyVisible = level2);
        }

        private void ui_ControlHubKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<ControlHubPresenter>();
                n.PresentFluidly<ControlHubNavPresenter>();
            });
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
        private readonly BigPowNavUi ui;
        private readonly MethodWeb web;
    }
}
