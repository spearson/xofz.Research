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

    public sealed class BigPowPresenter : Presenter
    {
        public BigPowPresenter(
            BigPowUi ui,
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

            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            this.ui.DisplayKeyTapped += this.ui_DisplayKeyTapped;
            this.ui.MultiPowKeyTapped += this.ui_MultiPowKeyTapped;
            this.web.Subscribe<xofz.Framework.Timer>(
                "Elapsed", 
                this.timer_Elapsed, 
                "BigPowTimer");

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.NumberInput = 1000;
                this.ui.ExponentInput = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });

            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
            this.timer_Elapsed();
            this.web.Run<xofz.Framework.Timer>(
                t => t.Start(1000),
                "BigPowTimer");
        }

        private void ui_DisplayKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                var sw = Stopwatch.StartNew();
                this.ui.Power = this.currentPower;
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
                this.ui.Power = null;
                this.ui.DisplayKeyVisible = false;
            });
            this.ui.WriteFinished.WaitOne();

            var number = UiHelpers.Read(this.ui, () => this.ui.NumberInput);
            var exponent = UiHelpers.Read(this.ui, () => this.ui.ExponentInput);
            BigInteger power;
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
            power = w.Run<BigPow, BigInteger>(bp => bp.Compute(number, exponent));
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
                this.ui.Power = "Computed, now waiting for ToString()...";
            });
            this.ui.WriteFinished.WaitOne();

            string s;
            var sw2 = Stopwatch.StartNew();
            s = power.ToString();
            sw2.Stop();

            this.setCurrentPower(s);
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Power = string.Empty;
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed;
            });
            this.ui.WriteFinished.WaitOne();

            if (number + exponent < 10001)
            {
                UiHelpers.Write(this.ui, () =>
                {
                    var sw3 = Stopwatch.StartNew();
                    this.ui.Power = s;
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
                new[]
                {
                    number + " raised to the "
                    + exponent + " power was computed."
                }));
        }

        private void ui_SaveKeyTapped()
        {
            var number = UiHelpers.Read(this.ui, () => this.ui.NumberInput);
            var exponent = UiHelpers.Read(this.ui, () => this.ui.ExponentInput);
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = false);
            this.ui.WriteFinished.WaitOne();
            var w = this.web;
            w.Run<BigPowSaver>(bps => bps.Save(
                number,
                exponent,
                this.currentPower));
            w.Run<Messenger>(m =>
            {
                UiHelpers.Write(
                    m.Subscriber,
                    () => m.Inform(
                        "Saved "
                        + number
                        + " raised to the "
                        + exponent
                        + " power to the current program directory."));
                m.Subscriber.WriteFinished.WaitOne();
            });
            
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = true);
        }

        private void ui_MultiPowKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<MultiPowPresenter>());
        }

        private void timer_Elapsed()
        {
            var cal = this.web.Run<AccessController, AccessLevel>(ac => ac.CurrentAccessLevel);
            var visible = cal > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentPower(string currentPower)
        {
            this.currentPower = currentPower;
        }

        private int setupIf1;
        private string currentPower;
        private readonly BigPowUi ui;
        private readonly MethodWeb web;
    }
}
