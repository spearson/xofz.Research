namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Logging.Logs;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.UI;

    public class SetupMethodWebCommand : Command
    {
        public SetupMethodWebCommand(
            Messenger messenger)
        {
            this.messenger = messenger;
        }

        public virtual MethodWeb Web => this.web;

        public override void Execute()
        {
            this.setWeb(new MethodWeb());
            this.registerDependencies();
        }

        private void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new EventRaiser());
            w.RegisterDependency(
                this.messenger);
            w.RegisterDependency(
                new AccessController(
                    "1111",
                    "2222"));
            w.RegisterDependency(
                new Navigator(w));
            w.RegisterDependency(
                new TextFileLog("Exceptions.log"),
                "Exceptions");
            w.RegisterDependency(
                new EventSubscriberV2());
        }

        private MethodWeb web;
        private readonly Messenger messenger;
    }
}
