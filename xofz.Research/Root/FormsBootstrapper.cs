namespace xofz.Research.Root
{
    using System.Windows.Forms;
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.Root.Commands;
    using xofz.Research.UI.Forms;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper()
            : this(new CommandExecutor())
        {
        }

        public FormsBootstrapper(
            CommandExecutor executor)
        {
            this.executor = executor;
        }

        public virtual Form Shell => this.shell;

        public virtual void Bootstrap()
        {
            this.setShell(new FormMainUi());
            var s = this.shell;
            var fm = new FormsMessenger { Subscriber = s };
            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                    fm));
            var w = e.Get<SetupMethodWebCommand>().Web;
            e
                .Execute(new SetupMainCommand(
                    s,
                    w))
                .Execute(new SetupLogCommand(
                    new UserControlLogUi(
                        new LinkedListMaterializer()),
                    s,
                    new FormLogEditorUi(
                        s,
                        new LinkedListMaterializer()),
                    w))
                .Execute(new SetupHomeCommand(
                    new UserControlHomeNavUi(),
                    new UserControlHomeUi(),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupPrimesCommand(
                    new UserControlPrimesNavUi(),
                    new UserControlPrimesUi(),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupFactorialCommand(
                    new UserControlFactorialNavUi(),
                    new UserControlFactorialUi(),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupRotationCommand(
                    new UserControlRotationNavUi(),
                    new UserControlRotationUi(
                        new LinkedListMaterializer()),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupBigPowCommand(
                    new UserControlBigPowNavUi(),
                    new UserControlBigPowUi(),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupMultiPowCommand(
                    new UserControlMultiPowUi(),
                    s,
                    w))
                .Execute(new SetupBinaryVisualizerCommand(
                    new UserControlBinaryVisualizerUi(),
                    s,
                    w))
                .Execute(new SetupControlHubCommand(
                    new UserControlControlHubNavUi(),
                    new UserControlControlHubUi(),
                    s.NavUi,
                    s,
                    w))
                .Execute(new SetupLoginCommand(
                    new FormLoginUi(s),
                    w))
                .Execute(new SetupShutdownCommand(
                    s,
                    w));

            w.Run<Navigator>(n =>
            {
                n.Present<HomePresenter>();
                n.PresentFluidly<HomeNavPresenter>();
            });
        }

        private void setShell(FormMainUi shell)
        {
            this.shell = shell;
        }

        private FormMainUi shell;
        private readonly CommandExecutor executor;
    }
}
