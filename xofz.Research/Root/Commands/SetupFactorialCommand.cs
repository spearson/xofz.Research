namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
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
            this.registerDependencies();

            var n = this.navigator;
            var w = this.web;
            new FactorialNavPresenter(
                    this.navUi,
                    this.navShell,
                    n,
                    w)
                .Setup();
            new FactorialPresenter(
                    this.ui,
                    this.mainShell,
                    w)
                .Setup(n);
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "FactorialTimer");
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "FactorialNavTimer");
            w.RegisterDependency(
                new FactorialComputer());
            w.RegisterDependency(
                new FactorialSaver());
        }

        private readonly FactorialNavUi navUi;
        private readonly FactorialUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
