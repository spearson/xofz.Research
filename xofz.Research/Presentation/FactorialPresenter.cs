namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class FactorialPresenter : Presenter
    {
        public FactorialPresenter(
            FactorialUi ui, 
            ShellUi shell,
            FactorialComputer computer,
            AccessController accessController,
            xofz.Framework.Timer timer) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.computer = computer;
            this.accessController = accessController;
            this.timer = timer;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;
            this.timer.Start(1000);
            UiHelpers.Write(this.ui, () => this.ui.Input = 1000);
            navigator.RegisterPresenter(this);
            this.timer_Elapsed();
            this.timer.Start(1000);
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.DurationInfo = null;
            });
            this.ui.WriteFinished.WaitOne();

            var sw = Stopwatch.StartNew();
            var factorial = this.computer.Compute(
                UiHelpers.Read(this.ui, () => this.ui.Input));
            sw.Stop();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo = "Computation took " + sw.Elapsed;
                this.ui.Factorial = "Computed, now waiting for ToString()...";
            });
            this.ui.WriteFinished.WaitOne();

            var sw2 = Stopwatch.StartNew();
            var s = factorial.ToString();
            sw2.Stop();

            UiHelpers.Write(this.ui, () =>
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed);
            this.ui.WriteFinished.WaitOne();

            var sw3 = Stopwatch.StartNew();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Factorial = s;
                sw3.Stop();
                this.ui.DurationInfo += Environment.NewLine +
                                        "Setting TextBox Text property took " + sw3.Elapsed;
            });
            this.ui.WriteFinished.WaitOne();

            UiHelpers.Write(this.ui, () => this.ui.Computing = false);
            this.ui.WriteFinished.WaitOne();
        }

        private void timer_Elapsed()
        {
            var visible = this.accessController.CurrentAccessLevel > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private int setupIf1;
        private readonly FactorialUi ui;
        private readonly FactorialComputer computer;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
    }
}
