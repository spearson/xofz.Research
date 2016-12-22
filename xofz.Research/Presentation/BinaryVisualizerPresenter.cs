namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
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

            this.ui.TranslateKeyTapped += this.ui_TranslateKeyTapped;
            UiHelpers.Write(this.ui, () => this.ui.Input = 1000000);
            
            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_TranslateKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Translating = true;
                this.ui.Binary = null;
            });
            this.ui.WriteFinished.WaitOne();

            var w = this.web;
            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            var bits = w.Run<BinaryTranslator, IEnumerable<bool>>(
                bt => bt.GetBits(input));
            var binary = new string(
                bits.Select(b => b ? '1' : '0').ToArray());
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Binary = binary;
                this.ui.Translating = false;
            });
            this.ui.WriteFinished.WaitOne();

            w.Run<LogEditor>(le => le.AddEntry(
                "Information",
                new[] { "The binary form of " + input + " was displayed." }));
        }

        private int setupIf1;
        private readonly BinaryVisualizerUi ui;
        private readonly MethodWeb web;
    }
}
