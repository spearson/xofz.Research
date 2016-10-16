namespace xofz.Research.Start
{
    using System;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI;

    public class SetupShutdownCommand : Command
    {
        public SetupShutdownCommand(
            Ui ui,
            Action cleanup,
            Navigator navigator)
        {
            this.ui = ui;
            this.cleanup = cleanup;
            this.navigator = navigator;
        }
        public override void Execute()
        {
            new ShutdownPresenter(
                this.ui,
                this.cleanup)
                .Setup(this.navigator);
        }

        private readonly Ui ui;
        private readonly Action cleanup;
        private readonly Navigator navigator;
    }
}
