namespace xofz.Research.Start
{
    using System;
    using System.Windows.Forms;
    using Framework;
    using Presentation;
    using UI.Forms;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Framework.Materialization;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.Start;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper(Navigator navigator, CommandExecutor executor)
        {
            this.navigator = navigator;
            this.executor = executor;
        }

        public Form Shell => this.shell;

        public void Bootstrap()
        {
            this.shell = new FormMainUi();
            var ac = new AccessController(new[] { "1111", "2222" });
            var fm = new FormsMessenger { Subscriber = this.shell };
            this.executor
                .Execute(new SetupLoginCommand(
                    new FormLoginUi(this.shell),
                    ac,
                    this.navigator))
                .Execute(new SetupMainCommand(
                    this.shell,
                    this.navigator))
                .Execute(new SetupHomeCommand(
                    new UserControlHomeNavUi(),
                    new UserControlHomeUi(),
                    this.shell.NavUi,
                    this.shell,
                    this.navigator,
                    ac))
                .Execute(new SetupRotationCommand(
                    new UserControlRotationNavUi(),
                    new UserControlRotationUi(
                        list => new OrderedMaterializedEnumerable<TextBox>(list),
                        ll => new LinkedListMaterializedEnumerable<int>(ll)),
                    this.shell.NavUi,
                    this.shell,
                    this.navigator,
                    ac))
                .Execute(new SetupPrimesCommand(
                    new UserControlPrimesNavUi(),
                    new UserControlPrimesUi(),
                    this.shell.NavUi,
                    this.shell,
                    this.navigator,
                    ac,
                    fm))
                .Execute(new SetupFactorialCommand(
                    new UserControlFactorialNavUi(),
                    new UserControlFactorialUi(),
                    this.shell.NavUi,
                    this.shell,
                    this.navigator,
                    ac,
                    fm))
                .Execute(new SetupControlHubCommand(
                    new UserControlControlHubNavUi(),
                    new UserControlControlHubUi(),
                    this.shell.NavUi,
                    this.shell,
                    this.navigator,
                    ac))
                .Execute(new SetupShutdownCommand(
                    this.shell,
                    () => { },
                    this.navigator));
            

            this.navigator.Present<HomePresenter>();
            this.navigator.PresentFluidly<HomeNavPresenter>();
        }

        private FormMainUi shell;
        private readonly Navigator navigator;
        private readonly CommandExecutor executor;
    }
}
