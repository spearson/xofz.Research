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
            FactorialComputer computer,
            AccessController accessController,
            xofz.Framework.Timer timer,
            FactorialSaver saver,
            Messenger messenger) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.computer = computer;
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
            this.ui.DisplayKeyTapped += this.ui_DisplayKeyTapped;
            this.timer.Elapsed += this.timer_Elapsed;

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Input = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
            });
            navigator.RegisterPresenter(this);
            this.timer_Elapsed();
            this.timer.Start(1000);
        }

        private void ui_DisplayKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                var sw3 = Stopwatch.StartNew();
                this.ui.Factorial = this.currentFactorial;
                sw3.Stop();
                this.ui.DurationInfo += Environment.NewLine +
                                        "Setting TextBox Text property took " + sw3.Elapsed;
                this.ui.DisplayKeyVisible = false;
            });
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.DurationInfo = null;
            });
            this.ui.WriteFinished.WaitOne();

            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            BigInteger factorial;
            var sw = Stopwatch.StartNew();
            factorial = this.computer.Compute(input);
            sw.Stop();

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.DurationInfo = "Computation took " + sw.Elapsed;
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
        }

        private void ui_SaveKeyTapped()
        {
            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            this.saver.Save(
                input,
                UiHelpers.Read(this.ui, () => this.ui.Factorial));
            UiHelpers.Write(
                this.messenger.Subscriber, 
                () => this.messenger.Inform(
                    "Saved the factorial of " 
                    + input
                    + " to the current program directory."));
        }

        private void timer_Elapsed()
        {
            var visible = this.accessController.CurrentAccessLevel > AccessLevel.None;
            UiHelpers.Write(this.ui, () => this.ui.DurationInfoVisible = visible);
        }

        private void setCurrentFactorial(string currentFactorial)
        {
            this.currentFactorial = currentFactorial;
        }

        private int setupIf1;
        private string currentFactorial;
        private readonly FactorialUi ui;
        private readonly FactorialComputer computer;
        private readonly AccessController accessController;
        private readonly xofz.Framework.Timer timer;
        private readonly FactorialSaver saver;
        private readonly Messenger messenger;
    }
}
