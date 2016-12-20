namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Computation;
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
            Navigator navigator,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.navigator = navigator;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            this.ui.DisplayKeyTapped += this.ui_DisplayKeyTapped;
            this.ui.BigPowKeyTapped += this.ui_BigPowKeyTapped;
            this.web.Subscribe<xofz.Framework.Timer>(
                "Elapsed",
                this.timer_Elapsed,
                "MultiPowTimer");

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.PowersInput = "3, 3, 3";
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });
            this.navigator.RegisterPresenter(this);
            this.timer_Elapsed();
            this.web.Run<xofz.Framework.Timer>(
                t => t.Start(1000),
                "MultiPowTimer");
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

            var powers = this.readPowers();
            BigInteger multiPower;
            DateTime computationStartTime, computationCompletionTime;
            var w = this.web;

            var sw = Stopwatch.StartNew();
            computationStartTime = DateTime.Now;
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo =
                    "Computation began at approximately "
                    + computationStartTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
            });
            multiPower = w.Run<MultiPow, BigInteger>(mp => mp.Compute(powers));
            computationCompletionTime = DateTime.Now;
            sw.Stop();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo +=
                Environment.NewLine
                + "Computation took "
                + sw.Elapsed
                + " and completed at "
                + computationCompletionTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
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
                    + string.Join(",", powers.Select(p => p.ToString()))
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
            this.navigator.Present<BigPowPresenter>();
        }

        private void timer_Elapsed()
        {
            var cal = this.web.Run<AccessController, AccessLevel>(ac => ac.CurrentAccessLevel);
            var visible = cal > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentMultiPow(string currentMultiPow)
        {
            this.currentMultiPow = currentMultiPow;
        }

        private int setupIf1;
        private string currentMultiPow;
        private readonly MultiPowUi ui;
        private readonly Navigator navigator;
        private readonly MethodWeb web;
    }
}
