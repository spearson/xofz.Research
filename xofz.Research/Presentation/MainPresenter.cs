﻿namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class MainPresenter : Presenter
    {
        public MainPresenter(
            MainUi ui, 
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

            this.ui.ShutdownRequested += this.ui_ShutdownRequested;
            this.navigator.RegisterPresenter(this);
        }

        public override void Start()
        {
        }

        private void ui_ShutdownRequested()
        {
            this.navigator.Present<ShutdownPresenter>();
        }

        private int setupIf1;
        private readonly MainUi ui;
        private readonly Navigator navigator;
    }
}