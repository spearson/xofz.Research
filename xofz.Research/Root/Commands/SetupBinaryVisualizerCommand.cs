namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Theory;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.UI;
    using xofz.Root;
    using xofz.UI;

    public class SetupBinaryVisualizerCommand : Command
    {
        public SetupBinaryVisualizerCommand(
            BinaryVisualizerUi ui,
            ShellUi shell,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new BinaryVisualizerPresenter(
                this.ui,
                this.shell,
                this.web)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new BinaryTranslator());
        }

        private readonly BinaryVisualizerUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
