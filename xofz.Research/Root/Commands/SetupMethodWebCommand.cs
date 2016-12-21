namespace xofz.Research.Root.Commands
{
    using System;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
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
