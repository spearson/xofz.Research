namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Threading;
    using Framework;
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
            MethodWeb web)
            : base(ui, shell)
        {
            this.ui = ui;
            this.ui?.AssertStability();
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
            this.web.Subscribe<xofz.Framework.Timer>(
                "Elapsed",
                this.timer_Elapsed,
                "FactorialTimer");

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Input = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });
            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
            this.timer_Elapsed();
            this.web.Run<xofz.Framework.Timer>(
                timer => timer.Start(1000), "FactorialTimer");
        }

        private void ui_DisplayKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                var sw = Stopwatch.StartNew();
                this.ui.Factorial = this.currentFactorial;
                sw.Stop();
                this.ui.DurationInfo += Environment.NewLine +
                                        "Setting TextBox Text property took " + sw.Elapsed;
                this.ui.DisplayKeyVisible = false;
            });
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.SaveKeyVisible = false;
                this.ui.DurationInfo = null;
                this.ui.Factorial = null;
                this.ui.DisplayKeyVisible = false;
            });
            this.ui.WriteFinished.WaitOne();

            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            BigInteger factorial;
            DateTime computationStartTime, computationCompletionTime;

            var sw = Stopwatch.StartNew();
            computationStartTime = DateTime.Now;
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo =
                    "Computation began at approximately "
                    + computationStartTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
            });
            var w = this.web;
            factorial = w.Run<FactorialComputer, BigInteger>(
                computer => computer.Compute(input));
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
                this.ui.Factorial = "Computed, now waiting for ToString()...";
            });
            this.ui.WriteFinished.WaitOne();

            string s;
            var sw2 = Stopwatch.StartNew();
            s = factorial.ToString();
            sw2.Stop();

            this.setCurrentFactorial(s);
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Factorial = string.Empty;
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed;
            });
            this.ui.WriteFinished.WaitOne();

            if (input < 10001)
            {
                UiHelpers.Write(this.ui, () =>
                {
                    var sw3 = Stopwatch.StartNew();
                    this.ui.Factorial = this.currentFactorial;
                    sw3.Stop();
                    this.ui.DurationInfo += Environment.NewLine +
                                            "Setting TextBox Text property took " + sw3.Elapsed;
                });
            }
            else
            {
                UiHelpers.Write(this.ui, () =>
                {
                    this.ui.DisplayKeyVisible = true;
                });
            }
            this.ui.WriteFinished.WaitOne();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = false;
                this.ui.SaveKeyVisible = true;
            });
            this.ui.WriteFinished.WaitOne();

            w.Run<LogEditor>(le => le.AddEntry(
                "Information",
                new[] { "The factorial of " + input + " was computed." }));
        }

        private void ui_SaveKeyTapped()
        {
            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = false);
            this.ui.WriteFinished.WaitOne();

            var w = this.web;
            w.Run<FactorialSaver>(s => s.Save(input,
                this.currentFactorial));
            w.Run<Messenger>(m =>
            {
                UiHelpers.Write(
                    m.Subscriber,
                    () => m.Inform(
                        "Saved the factorial of "
                        + input
                        + " to the current program directory."));
                m.Subscriber.WriteFinished.WaitOne();
            });
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = true);
        }

        private void timer_Elapsed()
        {
            var cal = this.web.Run<AccessController, AccessLevel>(
                ac => ac.CurrentAccessLevel);
            var visible = cal > AccessLevel.None;
            UiHelpers.Write(
                this.ui,
                () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentFactorial(string currentFactorial)
        {
            this.currentFactorial = currentFactorial;
        }

        private int setupIf1;
        private string currentFactorial;
        private readonly FactorialUi ui;
        private readonly MethodWeb web;
    }
}
