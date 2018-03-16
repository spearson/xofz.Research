namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Research.Framework;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupFactorialCommand : Command
    {
        public SetupFactorialCommand(
            FactorialNavUi navUi,
            FactorialUi ui,
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
            new FactorialNavPresenter(
                    this.navUi,
                    this.navShell,
                    w)
                .Setup();
            new FactorialPresenter(
                    this.ui,
                    this.mainShell,
                    w)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new FactorialComputer());
            w.RegisterDependency(
                new FactorialSaver());
        }

        private readonly FactorialNavUi navUi;
        private readonly FactorialUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
