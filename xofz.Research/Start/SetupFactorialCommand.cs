namespace xofz.Research.Start
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
                this.messenger)
                .Setup(n);
        }

        private readonly FactorialNavUi navUi;
        private readonly FactorialUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly Messenger messenger;
    }
}
