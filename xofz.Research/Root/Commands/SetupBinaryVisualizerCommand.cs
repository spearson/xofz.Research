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
            LogEditor logEditor,
            Navigator navigator)
        {
            this.ui = ui;
            this.shell = shell;
            this.logEditor = logEditor;
            this.navigator = navigator;
        }

        public override void Execute()
        {
            new BinaryVisualizerPresenter(
                this.ui,
                this.shell,
                new BinaryTranslator(),
                this.logEditor)
                .Setup(
                    this.navigator);
        }

        private readonly BinaryVisualizerUi ui;
        private readonly ShellUi shell;
        private readonly LogEditor logEditor;
        private readonly Navigator navigator;
    }
}
