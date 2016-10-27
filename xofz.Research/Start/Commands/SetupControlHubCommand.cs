namespace xofz.Research.Start.Commands
{
    using Presentation;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI;

    public class SetupControlHubCommand : Command
    {
        public SetupControlHubCommand(
            ControlHubNavUi navUi,
            ControlHubUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            Navigator navigator,
            AccessController accessController)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.accessController = accessController;
        }

        public override void Execute()
        {
            var n = this.navigator;
            new ControlHubNavPresenter(
                this.navUi,
                this.navShell,
                n,
                this.accessController,
                new xofz.Framework.Timer())
                .Setup();
            new ControlHubPresenter(
                this.ui,
                this.mainShell,
                n,
                new EventRaiser())
                .Setup();
        }

        private readonly ControlHubNavUi navUi;
        private readonly ControlHubUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
    }
}
