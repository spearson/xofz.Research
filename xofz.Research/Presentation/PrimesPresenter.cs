namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Framework;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class PrimesPresenter : Presenter
    {
        public PrimesPresenter(
            PrimesUi ui, 
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
                    nameof(this.ui.GenerateKeyTapped),
                    this.ui_GenerateKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.StopKeyTapped),
                    this.ui_StopKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.RestartKeyTapped),
                    this.ui_RestartKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.LoadKeyTapped),
                    this.ui_LoadKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveKeyTapped),
                    this.ui_SaveKeyTapped);
                w.Run<EventRaiser>(er =>
                {
                    er.Raise(
                        this.ui,
                        nameof(this.ui.RestartKeyTapped));
                });
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_LoadKeyTapped()
        {
            var w = this.web;
            UiHelpers.WriteSync(
                this.ui,
                () => this.ui.DisplayLoadLocator());
            var location = UiHelpers.Read(this.ui, () => this.ui.LoadLocation);
            if (string.IsNullOrWhiteSpace(location))
            {
                return;
            }

            w.Run<PrimeManager>(pm =>
                this.setGenerator(
                    new PrimeGenerator(
                        pm.LoadSet(location))));
            var g = this.generator;
            var e = g.Generate().GetEnumerator();
            var pi = 0;
            foreach (var prime in g.CurrentSet)
            {

                e.MoveNext();
                ++pi;
            }

            var lastPrime = g.CurrentSet.LastOrDefault();
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.CurrentPrime = lastPrime;
            });

            this.setCurrentPrimeIndex(pi);
            this.setEnumerator(e);
        }

        private void ui_GenerateKeyTapped()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.LoadKeyVisible = false;
                this.ui.StopKeyVisible = true;
                this.ui.RestartKeyVisible = false;
                this.ui.Generating = true;
                this.ui.Stopping = false;
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

            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.LoadKeyVisible = true;
                this.ui.StopKeyVisible = false;
                this.ui.RestartKeyVisible = true;
                this.ui.Generating = false;
                this.ui.Stopping = false;
            });

        }

        private void ui_StopKeyTapped()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 0, 1);
            UiHelpers.Write(this.ui, () => this.ui.Stopping = true);
        }

        private void ui_RestartKeyTapped()
        {
            this.setGenerator(
                new PrimeGenerator());
            this.setEnumerator(
                this.generator.Generate()
                    .GetEnumerator());
            this.setCurrentPrimeIndex(0);
            UiHelpers.WriteSync(
                this.ui,
                () => this.ui.CurrentPrime = null);
        }

        private void setGenerator(PrimeGenerator generator)
        {
            this.generator = generator;
        }

        private void setEnumerator(IEnumerator<long> enumerator)
        {
            this.enumerator = enumerator;
        }

        private void ui_SaveKeyTapped()
        {
            const string location = "Primes - Current Set.txt";
            UiHelpers.WriteSync(
                this.ui, 
                () => this.ui.SaveKeyVisible = false);

            var w = this.web;
            w.Run<PrimeManager>(pm => pm.Save(
                this.generator.CurrentSet, location));
            w.Run<Messenger>(m =>
            {
                UiHelpers.WriteSync(m.Subscriber, () =>
                {
                    m.Inform(
                        "Saved current set of primes to"
                        + Environment.NewLine
                        + location);
                });
            });
            
            UiHelpers.Write(
                this.ui, 
                () => this.ui.SaveKeyVisible = true);
        }

        private void setCurrentPrimeIndex(int currentPrimeIndex)
        {
            this.currentPrimeIndex = currentPrimeIndex;
            UiHelpers.Write(
                this.ui, 
                () => this.ui.CurrentPrimeIndex = currentPrimeIndex);
        }

        private int setupIf1;
        private long startedIf1;
        private int currentPrimeIndex;
        private PrimeGenerator generator;
        private IEnumerator<long> enumerator;
        private readonly PrimesUi ui;
        private readonly MethodWeb web;
    }
}
