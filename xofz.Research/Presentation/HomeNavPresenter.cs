﻿namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class HomeNavPresenter : Presenter
    {
        public HomeNavPresenter(
            HomeNavUi ui, 
            ShellUi shell,
            Navigator navigator) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.navigator = navigator;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.PrimesKeyTapped += this.ui_PrimesKeyTapped;
            this.ui.FactorialKeyTapped += this.ui_FactorialKeyTapped;
            this.ui.RotationKeyTapped += this.ui_RotationKeyTapped;
            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            this.navigator.RegisterPresenter(this);
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
        private readonly HomeNavUi ui;
        private readonly Navigator navigator;
    }
}
