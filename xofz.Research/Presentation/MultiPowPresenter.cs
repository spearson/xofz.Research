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
            MultiPow multiPow,
            Navigator navigator,
            xofz.Framework.Timer timer,
            MultiPowSaver saver,
            Messenger messenger,
            AccessController accessController,
            LogEditor logEditor) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.multiPow = multiPow;
            this.navigator = navigator;
            this.timer = timer;
            this.saver = saver;
            this.messenger = messenger;
            this.accessController = accessController;
            this.logEditor = logEditor;
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
            this.timer.Elapsed += this.timer_Elapsed;

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.PowersInput = "3, 3, 3";
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });
            this.navigator.RegisterPresenter(this);
            this.timer_Elapsed();
            this.timer.Start(1000);
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

            var sw = Stopwatch.StartNew();
            computationStartTime = DateTime.Now;
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo =
                    "Computation began at approximately "
                    + computationStartTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
            });
            multiPower = this.multiPow.Compute(powers);
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

            this.logEditor.AddEntry(
                "Information",
                new[]
                {
                    "The multi-power of "
                    + string.Join(",", powers.Select(p => p.ToString()))
                    + " was computed."
                });
        }

        private void ui_SaveKeyTapped()
        {
            var powers = this.readPowers();
            this.saver.Save(
                powers, 
                this.currentMultiPow);

            UiHelpers.Write(
                this.messenger.Subscriber,
                () => this.messenger.Inform(
                    "Saved this multi-pow to the "
                    + "current program directory."));
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
            var visible = this.accessController.CurrentAccessLevel > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentMultiPow(string currentMultiPow)
        {
            this.currentMultiPow = currentMultiPow;
        }

        private int setupIf1;
        private string currentMultiPow;
        private readonly MultiPowUi ui;
        private readonly MultiPow multiPow;
        private readonly Navigator navigator;
        private readonly xofz.Framework.Timer timer;
        private readonly MultiPowSaver saver;
        private readonly Messenger messenger;
        private readonly AccessController accessController;
        private readonly LogEditor logEditor;
    }
}
