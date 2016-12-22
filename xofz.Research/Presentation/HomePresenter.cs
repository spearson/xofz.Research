namespace xofz.Research.Presentation
{
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

            this.ui.LogKeyTapped += this.ui_LogKeyTapped;
            this.ui.BinaryVisualizerKeyTapped += this.ui_BinaryVisualizerKeyTapped;
            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_LogKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<LogPresenter>());
        }

        private void ui_BinaryVisualizerKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<BinaryVisualizerPresenter>());
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
