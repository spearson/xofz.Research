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

    public class SetupBigPowCommand : Command
    {
        public SetupBigPowCommand(
            BigPowNavUi navUi,
            BigPowUi ui,
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
            new BigPowNavPresenter(
                    this.navUi,
                    this.navShell,
                    w)
                .Setup();
            new BigPowPresenter(
                    this.ui,
                    this.mainShell,
                    w)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new BigPow());
            w.RegisterDependency(
                new BigPowSaver());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "BigPowTimer");
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "BigPowNavTimer");
        }

        private readonly BigPowNavUi navUi;
        private readonly BigPowUi ui;
        private readonly ShellUi navShell;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
