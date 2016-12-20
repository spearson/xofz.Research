namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupBigPowCommand : Command
    {
        public SetupBigPowCommand(
            BigPowNavUi navUi,
            BigPowUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            Navigator navigator,
            MethodWeb web)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.web = web;
        }

        public override void Execute()
        {
            var n = this.navigator;
            var w = this.web;
            new BigPowNavPresenter(
                    this.navUi,
                    this.navShell,
                    n,
                    w)
                .Setup();
            new BigPowPresenter(
                    this.ui,
                    this.mainShell,
                    n,
                    w)
                .Setup();
        }

        private readonly BigPowNavUi navUi;
        private readonly BigPowUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
