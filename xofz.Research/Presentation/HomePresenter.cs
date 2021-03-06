﻿namespace xofz.Research.Presentation
{
    using System;
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui, 
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
                    nameof(this.ui.LogKeyTapped),
                    this.ui_LogKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.BinaryVisualizerKeyTapped),
                    this.ui_BinaryVisualizerKeyTapped);
            });

            w.Run<VersionReader>(vr =>
            {
                var version = vr.Read();
                var core98Version = vr.ReadCoreVersion();
                UiHelpers.Write(
                    this.ui,
                    () =>
                    {
                        this.ui.Version = version;
                        this.ui.Core98Version = core98Version;
                    });
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_LogKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<LogPresenter>();
                var hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                UiHelpers.Write(
                    hnUi,
                    () => hnUi.HomeKeyVisible = true);
            });
        }

        private void ui_BinaryVisualizerKeyTapped()
        {
            this.web.Run<Navigator>(n =>
            {
                n.Present<BinaryVisualizerPresenter>();
                var hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                UiHelpers.Write(
                    hnUi,
                    () => hnUi.HomeKeyVisible = true);
            });
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
