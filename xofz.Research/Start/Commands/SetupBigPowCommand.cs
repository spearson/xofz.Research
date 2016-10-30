namespace xofz.Research.Start.Commands
{
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.Research.Framework;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Start;
    using xofz.UI;

    public class SetupBigPowCommand : Command
    {
        public SetupBigPowCommand(
            BigPowNavUi navUi,
            BigPowUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            Navigator navigator,
            AccessController accessController,
            Messenger messenger)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.accessController = accessController;
            this.messenger = messenger;
        }

        public override void Execute()
        {
            var n = this.navigator;
            var ac = this.accessController;
            new BigPowNavPresenter(
                this.navUi,
                this.navShell,
                n,
                ac,
                new xofz.Framework.Timer())
                .Setup();
            new BigPowPresenter(
                this.ui,
                this.mainShell,
                new BigPow(),
                ac,
                new xofz.Framework.Timer(),
                new BigPowSaver(),
                this.messenger,
                n)
                .Setup();
        }

        private readonly BigPowNavUi navUi;
        private readonly BigPowUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly Messenger messenger;
    }
}
