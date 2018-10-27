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
    using xofz.Framework.Logging;
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

            var w = this.web;
            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            this.ui.DisplayKeyTapped += this.ui_DisplayKeyTapped;
            this.ui.MultiPowKeyTapped += this.ui_MultiPowKeyTapped;

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.NumberInput = 1000;
                this.ui.ExponentInput = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
                this.ui.DurationInfoVisible = false;
            });

            w.Run<AccessController>(ac =>
                ac.AccessLevelChanged += this.accessLevelChanged);
            w.Run<Navigator>(n => n.RegisterPresenter(this));
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
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.SaveKeyVisible = false;
                this.ui.DurationInfo = null;
                this.ui.Power = null;
                this.ui.DisplayKeyVisible = false;
            });

            var number = UiHelpers.Read(this.ui, () => this.ui.NumberInput);
            var exponent = UiHelpers.Read(this.ui, () => this.ui.ExponentInput);
            var power = default(BigInteger);
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
            w.Run<BigPow>(bp =>
                power = bp.Compute(number, exponent));
            computationCompletionTime = DateTime.Now;
            sw.Stop();

            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.DurationInfo += 
                Environment.NewLine
                + "Computation took " 
                + sw.Elapsed
                + " and completed at "
                + computationCompletionTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
                this.ui.Power = "Computed, now waiting for ToString()...";
            });

            string s;
            var sw2 = Stopwatch.StartNew();
            s = power.ToString();
            sw2.Stop();

            this.setCurrentPower(s);
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Power = string.Empty;
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed;
            });

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
                UiHelpers.WriteSync(this.ui, () =>
                {
                    this.ui.DisplayKeyVisible = true;
                });
            }

            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Computing = false;
                this.ui.SaveKeyVisible = true;
            });

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
            UiHelpers.WriteSync(
                this.ui, 
                () => this.ui.SaveKeyVisible = false);
            var w = this.web;
            w.Run<BigPowSaver>(bps => bps.Save(
                number,
                exponent,
                this.currentPower));
            w.Run<Messenger>(m =>
            {
                UiHelpers.WriteSync(
                    m.Subscriber,
                    () => m.Inform(
                        "Saved "
                        + number
                        + " raised to the "
                        + exponent
                        + " power to the current program directory."));
            });
            
            UiHelpers.Write(this.ui, () => this.ui.SaveKeyVisible = true);
        }

        private void ui_MultiPowKeyTapped()
        {
            this.web.Run<Navigator>(n => n.Present<MultiPowPresenter>());
        }

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var level1 = newAccessLevel >= AccessLevel.Level1;
            UiHelpers.Write(
                this.ui,
                () => this.ui.DurationInfoVisible = level1);
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
