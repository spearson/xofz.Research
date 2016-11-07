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
            BigPow bigPow,
            AccessController accessController,
            xofz.Framework.Timer timer,
            BigPowSaver saver,
            Messenger messenger,
            Navigator navigator,
            LogEditor logEditor)
            : base(ui, shell)
        {
            this.ui = ui;
            this.bigPow = bigPow;
            this.accessController = accessController;
            this.timer = timer;
            this.saver = saver;
            this.messenger = messenger;
            this.navigator = navigator;
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
            this.ui.MultiPowKeyTapped += this.ui_MultiPowKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.NumberInput = 1000;
                this.ui.ExponentInput = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });
            this.navigator.RegisterPresenter(this);
            this.timer_Elapsed();
            this.timer.Start(1000);
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

            var sw = Stopwatch.StartNew();
            computationStartTime = DateTime.Now;
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo =
                    "Computation began at approximately "
                    + computationStartTime.ToString("MM/dd/yyyy hh:mm.ss.fff tt");
            });
            power = this.bigPow.Compute(number, exponent);
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

            this.logEditor.AddEntry(
                "Information",
                new[]
                {
                    number + " raised to the "
                    + exponent + " power was computed."
                });
        }

        private void ui_SaveKeyTapped()
        {
            var number = UiHelpers.Read(this.ui, () => this.ui.NumberInput);
            var exponent = UiHelpers.Read(this.ui, () => this.ui.ExponentInput);
            this.saver.Save(
                number,
                exponent,
                this.currentPower);
            UiHelpers.Write(
                this.messenger.Subscriber,
                () => this.messenger.Inform(
                    "Saved "
                    + number
                    + " raised to the "
                    + exponent
                    + " power to the current program directory."));
        }

        private void ui_MultiPowKeyTapped()
        {
            this.navigator.Present<MultiPowPresenter>();
        }

        private void timer_Elapsed()
        {
            var visible = this.accessController.CurrentAccessLevel > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentPower(string currentPower)
        {
            this.currentPower = currentPower;
        }

        private int setupIf1;
        private string currentPower;
        private readonly BigPowUi ui;
        private readonly BigPow bigPow;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
        private readonly BigPowSaver saver;
        private readonly Messenger messenger;
        private readonly Navigator navigator;
        private readonly LogEditor logEditor;
    }
}
