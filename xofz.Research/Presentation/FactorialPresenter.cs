namespace xofz.Research.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Framework;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Computation;
    using xofz.Framework.Logging;
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
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<EventSubscriberV2>(subV2 =>
            {
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.ComputeKeyTapped),
                    this.ui_ComputeKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveKeyTapped),
                    this.ui_SaveKeyTapped);
                subV2.Subscribe(
                    this.ui,
                    nameof(this.ui.DisplayKeyTapped),
                    this.ui_DisplayKeyTapped);
            });

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.Input = 1000;
                this.ui.SaveKeyVisible = false;
                this.ui.DisplayKeyVisible = false;
                this.ui.DurationInfoVisible = false;
            });

            w.Run<EventSubscriber, AccessController>((sub, ac) =>
            {
                sub.Subscribe<AccessLevel>(
                    ac,
                    nameof(ac.AccessLevelChanged),
                    this.accessLevelChanged);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Computing = true;
                this.ui.SaveKeyVisible = false;
                this.ui.DurationInfo = null;
                this.ui.Factorial = null;
                this.ui.DisplayKeyVisible = false;
            });

            var w = this.web;
            BigInteger factorial = 0;
            var computationCompletionTime = DateTime.MinValue;
            Stopwatch sw = null;
            var input = UiHelpers.Read(
                this.ui,
                () => this.ui.Input);
            w.Run<FactorialComputer>(fc =>
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

                factorial = fc.Compute(input);
                computationCompletionTime = DateTime.Now;
                sw.Stop();
            });

            if (sw == null)
            {
                UiHelpers.Write(
                    this.ui,
                    () => this.ui.DurationInfo +=
                        Environment.NewLine
                        + "Factorial computer not found.");
                return;
            }

            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.DurationInfo +=
                    Environment.NewLine
                    + "Computation took "
                    + sw.Elapsed
                    + " and completed at "
                    + computationCompletionTime.ToString(
                        "MM/dd/yyyy hh:mm.ss.fff tt");
                this.ui.Factorial = "Computed, now waiting for ToString()...";
            });

            string s;
            var sw2 = Stopwatch.StartNew();
            s = factorial.ToString();
            sw2.Stop();

            this.setCurrentFactorial(s);
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Factorial = string.Empty;
                this.ui.DurationInfo += Environment.NewLine +
                                        "ToString() took " + sw2.Elapsed;
            });

            if (input < 10001)
            {
                UiHelpers.WriteSync(this.ui, () =>
                {
                    var sw3 = Stopwatch.StartNew();
                    this.ui.Factorial = this.currentFactorial;
                    sw3.Stop();
                    this.ui.DurationInfo += Environment.NewLine +
                                            "Setting TextBox Text property took " + sw3.Elapsed;
                });

                goto finishUp;
            }

            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.DisplayKeyVisible = true;
            });

            finishUp:
            UiHelpers.WriteSync(this.ui, () =>
            {
                this.ui.Computing = false;
                this.ui.SaveKeyVisible = true;
            });

            w.Run<LogEditor>(le => le.AddEntry(
                "Information",
                new[] { "The factorial of " + input + " was computed." }));
        }

        private void ui_SaveKeyTapped()
        {
            var input = UiHelpers.Read(this.ui, () => this.ui.Input);
            UiHelpers.WriteSync(
                this.ui, 
                () => this.ui.SaveKeyVisible = false);

            var w = this.web;
            w.Run<FactorialSaver>(s => s.Save(
                input,
                this.currentFactorial));
            w.Run<Messenger>(m =>
            {
                UiHelpers.WriteSync(
                    m.Subscriber,
                    () => m.Inform(
                        "Saved the factorial of "
                        + input
                        + " to the current program directory."));
            });
            UiHelpers.Write(
                this.ui, 
                () => this.ui.SaveKeyVisible = true);
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

        private void accessLevelChanged(AccessLevel newAccessLevel)
        {
            var visible = newAccessLevel >= AccessLevel.Level1;
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
