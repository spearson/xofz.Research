namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Presentation;
    using xofz.UI;

    public class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui, 
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

            this.ui.LogKeyTapped += this.ui_LogKeyTapped;
            this.ui.BinaryVisualizerKeyTapped += this.ui_BinaryVisualizerKeyTapped;
            this.navigator.RegisterPresenter(this);
        }

        private void ui_LogKeyTapped()
        {
            this.navigator.Present<LogPresenter>();
        }

        private void ui_BinaryVisualizerKeyTapped()
        {
            this.navigator.Present<BinaryVisualizerPresenter>();
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly Navigator navigator;
    }
}
