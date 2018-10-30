namespace xofz.Research.Presentation
{
    using System.Linq;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Presentation;
    using xofz.Research.UI;
    using xofz.UI;

    public sealed class BinaryVisualizerPresenter : Presenter
    {
        public BinaryVisualizerPresenter(
            BinaryVisualizerUi ui, 
            ShellUi shell,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<EventSubscriberV2>(subV2 =>
            {
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.TranslateKeyTapped),
                    this.ui_TranslateKeyTapped);
            });

            UiHelpers.Write(
                this.ui, 
                () => this.ui.Input = 1000000);
            
            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_TranslateKeyTapped()
        {
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Translating = true;
                this.ui.Binary = null;
            });

            var w = this.web;
            
            var bits = Enumerable.Empty<bool>();
            var input = UiHelpers.Read(
                this.ui,
                () => this.ui.Input);
            w.Run<BinaryTranslatorV2>(bt =>
            {
                bits = bt.GetBits(input);
            });
            var binary = new string(
                bits.Select(b => b ? '1' : '0').ToArray());
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Binary = binary;
                this.ui.Translating = false;
            });

            w.Run<LogEditor>(le => le.AddEntry(
                "Information",
                new[] { "The binary form of " + input + " was displayed." }));
        }

        private int setupIf1;
        private readonly BinaryVisualizerUi ui;
        private readonly MethodWeb web;
    }
}
