﻿namespace xofz.Research.Presentation
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
            this.ui.ControlHubKeyTapped += this.ui_ControlHubKeyTapped;
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

        private void timer_Elapsed()
        {
            var level2 = this.accessController.CurrentAccessLevel > AccessLevel.Level1;
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

        private void ui_LogInKeyTapped()
        {
            this.navigator.PresentFluidly<LoginPresenter>();
        }

        private void ui_ShutdownKeyTapped()
        {
            this.navigator.Present<ShutdownPresenter>();
        }

        private int setupIf1;
        private readonly BigPowNavUi ui;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
    }
}
