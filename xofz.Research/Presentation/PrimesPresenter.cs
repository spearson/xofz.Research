namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Framework;
    using UI;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class PrimesPresenter : Presenter
    {
        public PrimesPresenter(
            PrimesUi ui, 
            ShellUi shell,
            Func<PrimeGenerator> createGenerator,
            PrimeSaver saver,
            Messenger messenger) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.createGenerator = createGenerator;
            this.saver = saver;
            this.messenger = messenger;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.GenerateKeyTapped += this.ui_GenerateKeyTapped;
            this.ui.StopKeyTapped += this.ui_StopKeyTapped;
            this.ui.RestartKeyTapped += this.ui_RestartKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            navigator.RegisterPresenter(this);
            this.ui_RestartKeyTapped();
        }

        private void ui_GenerateKeyTapped()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.StopKeyVisible = true;
                this.ui.RestartKeyVisible = false;
                this.ui.Generating = true;
            });

            var numberToGenerate = UiHelpers.Read(this.ui, () => this.ui.NumberToGenerate);
            var e = this.enumerator;

            for (var i = 0; i < numberToGenerate; ++i)
            {
                if (Interlocked.Read(ref this.startedIf1) == 0)
                {
                    break;
                }

                e.MoveNext();
                UiHelpers.Write(this.ui, () => this.ui.CurrentPrime = e.Current);
                this.setCurrentPrimeIndex(this.currentPrimeIndex + 1);
            }

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.StopKeyVisible = false;
                this.ui.RestartKeyVisible = true;
                this.ui.Generating = false;
            });
        }

        private void ui_StopKeyTapped()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 0, 1);
        }

        private void ui_RestartKeyTapped()
        {
            this.setGenerator(this.createGenerator());
            this.enumerator = this.generator.Generate().GetEnumerator();
            this.setCurrentPrimeIndex(0);
            UiHelpers.Write(this.ui, () => this.ui.CurrentPrime = null);
        }

        private void setGenerator(PrimeGenerator generator)
        {
            this.generator = generator;
        }

        private void ui_SaveKeyTapped()
        {
            const string location = "Primes - Current Set.txt";
            this.saver.Save(this.generator.CurrentSet, location);
            UiHelpers.Write(this.messenger.Subscriber as Ui, () =>
            {
                this.messenger.Inform(
                    "Saved current set of primes to"
                    + Environment.NewLine
                    + location);
            });
        }

        private void setCurrentPrimeIndex(int currentPrimeIndex)
        {
            this.currentPrimeIndex = currentPrimeIndex;
            UiHelpers.Write(this.ui, () => this.ui.CurrentPrimeIndex = currentPrimeIndex);
        }

        private int setupIf1;
        private long startedIf1;
        private int currentPrimeIndex;
        private PrimeGenerator generator;
        private IEnumerator<long> enumerator;
        private readonly PrimesUi ui;
        private readonly Func<PrimeGenerator> createGenerator;
        private readonly PrimeSaver saver;
        private readonly Messenger messenger;
    }
}
