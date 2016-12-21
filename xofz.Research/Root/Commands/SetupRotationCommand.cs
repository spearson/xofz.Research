namespace xofz.Research.Root.Commands
{
    using System;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupRotationCommand : Command
    {
        public SetupRotationCommand(
            RotationNavUi navUi,
            RotationUi ui,
            ShellUi navShell,
            ShellUi mainShell,
            Navigator navigator,
            MethodWeb web)
        {
            this.navUi = navUi;
            this.ui = ui;
            this.navShell = navShell;
            this.mainShell = mainShell;
            this.navigator = navigator;
            this.web = web;
        }

        public override void Execute()
        {
            var n = this.navigator;
            new RotationNavPresenter(
                this.navUi,
                this.navShell,
                n,
                this.web)
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
        private readonly MethodWeb web;
    }
}
