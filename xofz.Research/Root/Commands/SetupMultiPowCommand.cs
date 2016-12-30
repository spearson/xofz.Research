namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Research.Framework;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupMultiPowCommand : Command
    {
        public SetupMultiPowCommand(
            MultiPowUi ui,
            ShellUi mainShell,
            MethodWeb web)
        {
            this.ui = ui;
            this.mainShell = mainShell;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();

            new MultiPowPresenter(
                    this.ui,
                    this.mainShell,
                    this.web)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new MultiPow(
                    new BigPow()));
            w.RegisterDependency(
                new MultiPowSaver());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "MultiPowTimer");
        }

        private readonly MultiPowUi ui;
        private readonly ShellUi mainShell;
        private readonly MethodWeb web;
    }
}
