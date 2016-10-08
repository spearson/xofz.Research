namespace xofz.Research.Presentation
{
    using System.Collections.Generic;
    using System.Threading;
    using Framework.Computation;
    using UI;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class PrimesPresenter : Presenter
    {
        public PrimesPresenter(
            PrimesUi ui, 
            ShellUi shell,
            PrimeGenerator generator) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.primeEnumerator = generator.Generate().GetEnumerator();
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.GenerateKeyTapped += this.ui_GenerateKeyTapped;
            navigator.RegisterPresenter(this);
        }

        private void ui_GenerateKeyTapped()
        {
            UiHelpers.Write(this.ui, () => this.ui.Generating = true);
            var numberToGenerate = UiHelpers.Read(this.ui, () => this.ui.NumberToGenerate);
            var pe = this.primeEnumerator;

            for (var i = 0; i < numberToGenerate; ++i)
            {
                pe.MoveNext();
                UiHelpers.Write(this.ui, () => this.ui.CurrentPrime = pe.Current);
                this.setCurrentPrimeIndex(this.currentPrimeIndex + 1);
            }

            UiHelpers.Write(this.ui, () => this.ui.Generating = false);
        }

        private void setCurrentPrimeIndex(int currentPrimeIndex)
        {
            this.currentPrimeIndex = currentPrimeIndex;
            UiHelpers.Write(this.ui, () => this.ui.CurrentPrimeIndex = currentPrimeIndex);
        }

        private int setupIf1;
        private int currentPrimeIndex;
        private readonly PrimesUi ui;
        private readonly IEnumerator<long> primeEnumerator;
    }
}
