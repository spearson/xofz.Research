namespace xofz.Research.Start
{
    using System.Windows.Forms;
    using Commands;
    using Presentation;
    using UI.Forms;
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.Start.Commands;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper(Navigator navigator, CommandExecutor executor)
        {
            this.navigator = navigator;
            this.executor = executor;
        }

        public virtual Form Shell => this.shell;

        public virtual void Bootstrap()
        {
            this.setShell(new FormMainUi());
            var n = this.navigator;
            var s = this.shell;
            var fm = new FormsMessenger { Subscriber = this.shell };
            var ac = new AccessController(new[] { "1111", "2222" });
            var e = this.executor;
            e
                .Execute(new SetupMainCommand(
                    s,
                    n))
                .Execute(new SetupLogCommand(
                    new UserControlLogUi(),
                    s,
                    ac,
                    n,
                    new FormLogEditorUi()))
                .Execute(new SetupHomeCommand(
                    new UserControlHomeNavUi(),
                    new UserControlHomeUi(),
                    s.NavUi,
                    s,
                    n,
                    ac))
                .Execute(new SetupPrimesCommand(
                    new UserControlPrimesNavUi(),
                    new UserControlPrimesUi(),
                    s.NavUi,
                    s,
                    n,
                    ac,
                    fm));

            var le = e.Get<SetupLogCommand>().Editor;
            e.Execute(new SetupFactorialCommand(
                new UserControlFactorialNavUi(),
                new UserControlFactorialUi(),
                s.NavUi,
                s,
                n,
                ac,
                fm,
                le))
                .Execute(new SetupRotationCommand(
                    new UserControlRotationNavUi(),
                    new UserControlRotationUi(
                        list => new OrderedMaterializedEnumerable<TextBox>(list),
                        ll => new LinkedListMaterializedEnumerable<int>(ll)),
                    s.NavUi,
                    s,
                    n,
                    ac))
                .Execute(new SetupBigPowCommand(
                    new UserControlBigPowNavUi(),
                    new UserControlBigPowUi(),
                    s.NavUi,
                    s,
                    n,
                    ac,
                    fm,
                    le))
                .Execute(new SetupMultiPowCommand(
                    new UserControlMultiPowUi(),
                    s,
                    n,
                    fm,
                    ac,
                    le))
                .Execute(new SetupControlHubCommand(
                    new UserControlControlHubNavUi(),
                    new UserControlControlHubUi(),
                    s.NavUi,
                    s,
                    n,
                    ac))
                .Execute(new SetupLoginCommand(
                    new FormLoginUi(s),
                    ac,
                    n))
                .Execute(new SetupShutdownCommand(
                    s,
                    n,
                    () => { }));

            this.navigator.Present<HomePresenter>();
            this.navigator.PresentFluidly<HomeNavPresenter>();
        }

        private void setShell(FormMainUi shell)
        {
            this.shell = shell;
        }

        private FormMainUi shell;
        private readonly Navigator navigator;
        private readonly CommandExecutor executor;
    }
}
