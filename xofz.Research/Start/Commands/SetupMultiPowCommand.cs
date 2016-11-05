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

    public class SetupMultiPowCommand : Command
    {
        public SetupMultiPowCommand(
            MultiPowUi ui,
            ShellUi mainShell,
            Navigator navigator,
            Messenger messenger,
            AccessController accessController,
            LogEditor logEditor)
        {
            this.ui = ui;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.messenger = messenger;
            this.accessController = accessController;
            this.logEditor = logEditor;
        }

        public override void Execute()
        {
            new MultiPowPresenter(
                this.ui,
                this.mainShell,
                new MultiPow(
                    new BigPow()),
                this.navigator,
                new xofz.Framework.Timer(),
                new MultiPowSaver(),
                this.messenger,
                this.accessController,
                this.logEditor)
                .Setup();
        }

        private readonly MultiPowUi ui;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly Messenger messenger;
        private readonly AccessController accessController;
        private readonly LogEditor logEditor;
    }
}
