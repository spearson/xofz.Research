namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.Research.Framework;
    using xofz.Research.UI;
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
            Messenger messenger)
            : base(ui, shell)
        {
            this.ui = ui;
            this.bigPow = bigPow;
            this.accessController = accessController;
            this.timer = timer;
            this.saver = saver;
            this.messenger = messenger;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            this.ui.SaveKeyTapped += this.ui_SaveKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.NumberInput = 1000;
                this.ui.ExponentInput = 1000;
                this.ui.SaveKeyVisible = false;
            });
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
            var power = this.bigPow.Compute(
                UiHelpers.Read(this.ui, () => this.ui.NumberInput),
                UiHelpers.Read(this.ui, () => this.ui.ExponentInput));
            sw.Stop();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo = "Computation took " + sw.Elapsed;
                this.ui.Power = "Computed, now waiting for ToString()...";
            });
            this.ui.WriteFinished.WaitOne();

            var sw2 = Stopwatch.StartNew();
            var s = power.ToString();
            sw2.Stop();

            UiHelpers.Write(this.ui, () =>
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed);
            this.ui.WriteFinished.WaitOne();

            var sw3 = Stopwatch.StartNew();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Power = s;
                sw3.Stop();
                this.ui.DurationInfo += Environment.NewLine +
                                        "Setting TextBox Text property took " + sw3.Elapsed;
            });
            this.ui.WriteFinished.WaitOne();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = false;
                this.ui.SaveKeyVisible = true;
            });
            this.ui.WriteFinished.WaitOne();
        }

        private void ui_SaveKeyTapped()
        {
            var number = UiHelpers.Read(this.ui, () => this.ui.NumberInput);
            var exponent = UiHelpers.Read(this.ui, () => this.ui.ExponentInput);
            this.saver.Save(
                number,
                exponent,
                UiHelpers.Read(this.ui, () => this.ui.Power));
            UiHelpers.Write(
                this.messenger.Subscriber,
                () => this.messenger.Inform(
                    "Saved "
                    + number
                    + " raised to the "
                    + exponent
                    + " power to the current program directory."));
        }

        private void timer_Elapsed()
        {
            var visible = this.accessController.CurrentAccessLevel > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private int setupIf1;
        private readonly BigPowUi ui;
        private readonly BigPow bigPow;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
        private readonly BigPowSaver saver;
        private readonly Messenger messenger;
    }
}
