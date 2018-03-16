namespace xofz.Research.Root.Commands
{
    using System;
    using xofz.Framework;
    using xofz.Framework.Transformation;
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
            this.registerDependencies();

            var w = this.web;
            new RotationNavPresenter(
                this.navUi,
                this.navShell,
                w)
                .Setup();
            new RotationPresenter(
                this.ui,
                this.mainShell,
                w)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new Random());
            w.RegisterDependency(
                new EnumerableRotator());
        }

        private readonly RotationNavUi navUi;
        private readonly RotationUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
