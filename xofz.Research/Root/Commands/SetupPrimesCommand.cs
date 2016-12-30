namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Research.Framework;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupPrimesCommand : Command
    {
        public SetupPrimesCommand(
            PrimesNavUi navUi,
            PrimesUi ui,
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
            new PrimesNavPresenter(
                this.navUi,
                this.navShell,
                w)
                .Setup();
            new PrimesPresenter(
                this.ui,
                this.mainShell,
                w)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new PrimeManager());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "PrimesNavTimer");
        }

        private readonly PrimesNavUi navUi;
        private readonly PrimesUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
