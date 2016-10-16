namespace xofz.Research.Start
{
    using Presentation;
    using UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI;

    public class SetupHomeCommand : Command
    {
        public SetupHomeCommand(
            HomeNavUi navUi,
            HomeUi ui,
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
            new HomeNavPresenter(
                this.navUi,
                this.navShell,
                n,
                this.accessController,
                new xofz.Framework.Timer())
                .Setup();

            new HomePresenter(
                this.ui, 
                this.mainShell)
                .Setup(n);
        }

        private readonly HomeNavUi navUi;
        private readonly HomeUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
    }
}
