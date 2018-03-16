namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Framework.Logging;
    using xofz.Framework.Materialization;
    using xofz.Presentation;
    using xofz.Research.Framework;
    using xofz.Research.UI;
    using xofz.UI;

    public sealed class MultiPowPresenter : Presenter
    {
        public MultiPowPresenter(
            MultiPowUi ui, 
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
            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            this.ui.DisplayKeyTapped += this.ui_DisplayKeyTapped;
            this.ui.BigPowKeyTapped += this.ui_BigPowKeyTapped;
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.PowersInput = "3, 3, 3";
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
                this.ui.DurationInfoVisible = false;
            });

            w.Run<AccessController>(ac =>
                ac.AccessLevelChanged += this.accessLevelChanged);
            w.Run<Navigator>(
                n => n.RegisterPresenter(this));
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.SaveKeyVisible = false;
                this.ui.DurationInfo = null;
                this.ui.MultiPower = null;
                this.ui.DisplayKeyVisible = false;
            });
            this.ui.WriteFinished.WaitOne();

            var w = this.web;
            BigInteger multiPower = 0;
            var computationCompletionTime = DateTime.MinValue;
            Stopwatch sw = null;
            var input = this.readPowers();
            w.Run<MultiPow>(mp =>
            {
                sw = Stopwatch.StartNew();
                var computationStartTime = DateTime.Now;
                UiHelpers.Write(this.ui,
                    () =>
                    {
                        this.ui.DurationInfo =
                            "Computation began at approximately "
                            + computationStartTime.ToString(
                                "MM/dd/yyyy hh:mm.ss.fff tt");
                    });

                multiPower = mp.Compute(input);
                computationCompletionTime = DateTime.Now;
                sw.Stop();
            });

            if (sw == null)
            {
                UiHelpers.Write(
                    this.ui,
                    () => this.ui.DurationInfo +=
                        Environment.NewLine
                        + "MultiPow computer not found.");
                return;
            }

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo +=
                    Environment.NewLine
                    + "Computation took "
                    + sw.Elapsed
                    + " and completed at "
                    + computationCompletionTime.ToString(
                        "MM/dd/yyyy hh:mm.ss.fff tt");
                this.ui.MultiPower = "Computed, now waiting for ToString()...";
            });
            this.ui.WriteFinished.WaitOne();

            string s;
            var sw2 = Stopwatch.StartNew();
            s = multiPower.ToString();
            sw2.Stop();

            this.setCurrentMultiPow(s);
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.MultiPower = string.Empty;
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed;
                this.ui.Computing = false;
                this.ui.SaveKeyVisible = true;
                this.ui.DisplayKeyVisible = true;
            });
            this.ui.WriteFinished.WaitOne();

            w.Run<LogEditor>(le => le.AddEntry(
                "Information",
                new[]
                {
                    "The multi-power of "
                    + string.Join(",", input.Select(p => p.ToString()))
                    + " was computed."
                }));
        }

        private void ui_SaveKeyTapped()
        {
            var powers = this.readPowers();
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = false);
            this.ui.WriteFinished.WaitOne();
            var w = this.web;
            w.Run<MultiPowSaver>(s => s.Save(powers, this.currentMultiPow));
            w.Run<Messenger>(m =>
            {
                UiHelpers.Write(
                    m.Subscriber,
                    () => m.Inform(
                        "Saved this multi-pow to the "
                        + "current program directory."));
                m.Subscriber.WriteFinished.WaitOne();
            });
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = true);
        }

        private void ui_DisplayKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                var sw = Stopwatch.StartNew();
                this.ui.MultiPower = this.currentMultiPow;
                sw.Stop();
                this.ui.DurationInfo += Environment.NewLine +
                                        "Setting TextBox Text property took " + sw.Elapsed;
                this.ui.DisplayKeyVisible = false;
            });
        }

        private MaterializedEnumerable<BigInteger> readPowers()
        {
            var input = UiHelpers.Read(this.ui, () => this.ui.PowersInput);
            return new LinkedListMaterializedEnumerable<BigInteger>(
                input
                    .Split(',')
                    .Select(s => s.Trim())
                    .Select(BigInteger.Parse));
        }

        private void ui_BigPowKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<BigPowPresenter>());
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var level1 = newAccessLevel >= AccessLevel.Level1;
            UiHelpers.Write(
                this.ui,
                () => this.ui.DurationInfoVisible = level1);
        }

        private void setCurrentMultiPow(string currentMultiPow)
        {
            this.currentMultiPow = currentMultiPow;
        }

        private int setupIf1;
        private string currentMultiPow;
        private readonly MultiPowUi ui;
        private readonly MethodWeb web;
    }
}
