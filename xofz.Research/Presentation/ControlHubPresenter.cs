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
            Navigator navigator,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.navigator = navigator;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.StopPrimesKeyTapped += this.ui_StopPrimesKeyTapped;
            this.navigator.RegisterPresenter(this);
        }

        private void ui_StopPrimesKeyTapped()
        {
            var primesUi = this.navigator.GetUi<PrimesPresenter, PrimesUi>();
            this.web.Run<EventRaiser>(
                er => er.Raise(primesUi, "StopKeyTapped"));
        }

        private int setupIf1;
        private readonly ControlHubUi ui;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
