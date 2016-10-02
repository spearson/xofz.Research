namespace xofz.Research.Presentation
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

            this.ui.LogInKeyTapped += this.ui_LogInKeyTapped;
            this.ui.ShutdownKeyTapped += this.ui_ShutdownKeyTapped;
            this.navigator.RegisterPresenter(this);
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
