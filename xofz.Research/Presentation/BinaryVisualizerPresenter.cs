namespace xofz.Research.Presentation
{
    using System.Linq;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Theory;
    using xofz.Presentation;
    using xofz.Research.UI;
    using xofz.UI;

    public sealed class BinaryVisualizerPresenter : Presenter
    {
        public BinaryVisualizerPresenter(
            BinaryVisualizerUi ui, 
            ShellUi shell,
            BinaryTranslator translator,
            LogEditor logEditor) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.translator = translator;
            this.logEditor = logEditor;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.TranslateKeyTapped += this.ui_TranslateKeyTapped;
            UiHelpers.Write(this.ui, () => this.ui.Input = 1000000);
            navigator.RegisterPresenter(this);
        }

        private void ui_TranslateKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Translating = true;
                this.ui.Binary = null;
            });
            this.ui.WriteFinished.WaitOne();

            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            var bits = this.translator.GetBits(input);
            var binary = new string(
                bits.Select(b => b ? '1' : '0').ToArray());
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Binary = binary;
                this.ui.Translating = false;
            });
            this.ui.WriteFinished.WaitOne();

            this.logEditor.AddEntry(
                "Information",
                new[] { "The binary form of " + input + " was displayed." });
        }

        private int setupIf1;
        private readonly BinaryVisualizerUi ui;
        private readonly BinaryTranslator translator;
        private readonly LogEditor logEditor;
    }
}
