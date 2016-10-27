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

    public class SetupPrimesCommand : Command
    {
        public SetupPrimesCommand(
            PrimesNavUi navUi,
            PrimesUi ui,
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
            new PrimesNavPresenter(
                this.navUi,
                this.navShell,
                n,
                this.accessController,
                new xofz.Framework.Timer())
                .Setup();

            new PrimesPresenter(
                this.ui,
                this.mainShell,
                ll => ll == null ? new PrimeGenerator() : new PrimeGenerator(ll),
                new PrimeManager(),
                this.messenger)
                .Setup(n);
        }

        private readonly PrimesNavUi navUi;
        private readonly PrimesUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
        private readonly Messenger messenger;
    }
}
