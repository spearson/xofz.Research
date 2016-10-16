namespace xofz.Research.Start
{
    using System;
    using Presentation;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI;

    public class SetupRotationCommand : Command
    {
        public SetupRotationCommand(
            RotationNavUi navUi,
            RotationUi ui,
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
            new RotationNavPresenter(
                this.navUi,
                this.navShell,
                n,
                this.accessController,
                new xofz.Framework.Timer())
                .Setup();

            new RotationPresenter(
                this.ui,
                this.mainShell,
                new Random(),
                new EnumerableRotator())
                .Setup(n);
        }

        private readonly RotationNavUi navUi;
        private readonly RotationUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly AccessController accessController;
    }
}
