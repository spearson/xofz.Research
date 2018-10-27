namespace xofz.Research.Root
{
    using System;
    using System.Windows.Forms;
    using xofz.Framework.Logging;
    using xofz.Framework.Lotters;
    using xofz.Presentation;
    using xofz.Research.Presentation;
    using xofz.Research.Root.Commands;
    using xofz.Research.UI.Forms;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.UI;
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
            Messenger fm = new FormsMessenger();
            fm.Subscriber = s;
            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                    fm));
            AppDomain.CurrentDomain.UnhandledException += this.logUnhandledException;
            var w = e.Get<SetupMethodWebCommand>().Web;
            e
                .Execute(new SetupMainCommand(
                    s,
                    w))
                .Execute(new SetupLogCommand(
                    new UserControlLogUi(),
                    s,
                    new FormLogEditorUi(s),
                    new FormLogStatisticsUi(
                        s),
                    w,
                    @"Log.log",
                    null,
                    AccessLevel.None,
                    AccessLevel.None,
                    true,
                    () =>
                    {
                        var now = DateTime.Now;
                        return "Log backup " + now.ToString(
                                   "yyyy.mm.DD HH-mm-ss.fff");
                    }))
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
                        new LinkedListLotter()),
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

        private void logUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var web = this.executor.Get<SetupMethodWebCommand>().Web;

            var ex = e.ExceptionObject as Exception;
            if (ex == null)
            {
                web.Run<LogEditor>(editor => editor.AddEntry(
                        "Error",
                        new[]
                        {
                            "An unhandled exception occurred, but the exception "
                            + "did not derive from System.Exception.",
                            "Here is the exception's type: "
                            + e.ExceptionObject.GetType()
                        }),
                    "Exceptions");
                return;
            }

            web.Run<LogEditor>(
                editor => LogHelpers.AddEntry(editor, ex),
                "Exceptions");
        }

        private FormMainUi shell;
        private readonly CommandExecutor executor;
    }
}
