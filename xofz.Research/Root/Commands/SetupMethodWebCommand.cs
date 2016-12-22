namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
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
            var w = this.web;
            w.RegisterDependency(
                this.messenger);
            w.RegisterDependency(
                new AccessController(
                    new[] { "1111", "2222" }));
            w.RegisterDependency(
                new Navigator());
        }

        private void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        private MethodWeb web;
        private readonly Messenger messenger;
    }
}
