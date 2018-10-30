namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class ControlHubPresenter : Presenter
    {
        public ControlHubPresenter(
            ControlHubUi ui, 
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
                    nameof(this.ui.StopPrimesKeyTapped),
                    this.ui_StopPrimesKeyTapped);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_StopPrimesKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator, EventRaiser>((n, er) =>
            {
                var primesUi = n.GetUi<PrimesPresenter, PrimesUi>();
                if (primesUi != null)
                {
                    er.Raise(
                        primesUi,
                        nameof(primesUi.StopKeyTapped));
                }
            });
        }

        private int setupIf1;
        private readonly ControlHubUi ui;
        private readonly MethodWeb web;
    }
}
