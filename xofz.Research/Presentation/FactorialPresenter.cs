namespace xofz.Research.Presentation
{
    using System.Threading;
    using UI;
    using xofz.Framework.Computation;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class FactorialPresenter : Presenter
    {
        public FactorialPresenter(
            FactorialUi ui, 
            ShellUi shell,
            FactorialComputer computer) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.computer = computer;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.ComputeKeyTapped += this.ui_ComputeKeyTapped;
            navigator.RegisterPresenter(this);
        }

        private void ui_ComputeKeyTapped()
        {
            UiHelpers.Write(this.ui, () => this.ui.Computing = true);
            var factorial = this.computer.Compute(
                UiHelpers.Read(this.ui, () => this.ui.Input));
            
            UiHelpers.Write(this.ui, () => this.ui.Factorial = factorial.ToString());
            UiHelpers.Write(this.ui, () => this.ui.Computing = false);
        }

        private int setupIf1;
        private readonly FactorialUi ui;
        private readonly FactorialComputer computer;
    }
}
