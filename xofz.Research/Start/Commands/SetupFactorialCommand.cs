namespace xofz.Research.Start.Commands
{
    using Framework;
    using Presentation;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI;

    public class SetupFactorialCommand : Command
    {
        public SetupFactorialCommand(
            FactorialNavUi navUi,
            FactorialUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            Navigator navigator,
            AccessController accessController,
            Messenger messenger,
            LogEditor logEditor)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.accessController = accessController;
            this.messenger = messenger;
            this.logEditor = logEditor;
        }

        public override void Execute()
        {
            var n = this.navigator;
            var ac = this.accessController;
            new FactorialNavPresenter(
                this.navUi,
                this.navShell,
                n,
                ac,
                new xofz.Framework.Timer())
                .Setup();
            new FactorialPresenter(
                this.ui,
                this.mainShell,
                new FactorialComputer(),
                ac,
                new xofz.Framework.Timer(),
                new FactorialSaver(),
                this.messenger,
                this.logEditor)
                .Setup(n);
        }

        private readonly FactorialNavUi navUi;
        private readonly FactorialUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly Messenger messenger;
        private readonly LogEditor logEditor;
    }
}
