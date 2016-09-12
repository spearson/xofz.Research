namespace xofz.Research.Presentation
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

            this.ui.LoginKeyTapped += this.ui_LoginKeyTapped;
            this.navigator.RegisterPresenter(this);
        }

        public override void Start()
        {
        }

        private void ui_LoginKeyTapped()
        {
            this.navigator.Present<LoginPresenter>();
        }

        private int setupIf1;
        private readonly MainUi ui;
        private readonly Navigator navigator;
    }
}
