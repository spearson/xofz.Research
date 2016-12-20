namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupMultiPowCommand : Command
    {
        public SetupMultiPowCommand(
            MultiPowUi ui,
            ShellUi mainShell,
            Navigator navigator,
            MethodWeb web)
        {
            this.ui = ui;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.web = web;
        }

        public override void Execute()
        {
            new MultiPowPresenter(
                    this.ui,
                    this.mainShell,
                    this.navigator,
                    this.web)
                .Setup();
        }

        private readonly MultiPowUi ui;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
