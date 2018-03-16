namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupControlHubCommand : Command
    {
        public SetupControlHubCommand(
            ControlHubNavUi navUi,
            ControlHubUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            MethodWeb web)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.web = web;
        }

        public override void Execute()
        {
            var w = this.web;
            new ControlHubNavPresenter(
                this.navUi,
                this.navShell,
                w)
                .Setup();
            new ControlHubPresenter(
                this.ui,
                this.mainShell,
                w)
                .Setup();
        }

        private readonly ControlHubNavUi navUi;
        private readonly ControlHubUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
