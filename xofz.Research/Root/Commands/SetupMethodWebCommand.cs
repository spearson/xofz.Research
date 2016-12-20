namespace xofz.Research.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Research.Framework;
    using xofz.Root;
    using xofz.UI;

    public class SetupMethodWebCommand : Command
    {
        public SetupMethodWebCommand(
            LogEditor logEditor,
            Messenger messenger,
            AccessController accessController)
        {
            this.logEditor = logEditor;
            this.messenger = messenger;
            this.accessController = accessController;
        }

        public virtual MethodWeb Web => this.web;

        public override void Execute()
        {
            this.setWeb(new MethodWeb());
            var w = this.web;
            w.RegisterDependency(this.logEditor);
            w.RegisterDependency(this.messenger);
            w.RegisterDependency(this.accessController);
            this.registerFactorialDependencies();
            this.registerPrimesDependencies();
            this.registerBigPowDependencies();
            this.registerMultiPowDependencies();
        }

        private void registerFactorialDependencies()
        { 
            var w = this.web;
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "FactorialTimer");
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "FactorialNavTimer");
            w.RegisterDependency(
                new FactorialComputer());
            w.RegisterDependency(
                new FactorialSaver());
        }

        private void registerPrimesDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new PrimeManager());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "PrimesNavTimer");
        }

        private void registerBigPowDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new BigPow());
            w.RegisterDependency(
                new BigPowSaver());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "BigPowTimer");
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "BigPowNavTimer");
        }

        private void registerMultiPowDependencies()
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

        private void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        private MethodWeb web;
        private readonly LogEditor logEditor;
        private readonly Messenger messenger;
        private readonly AccessController accessController;
    }
}
