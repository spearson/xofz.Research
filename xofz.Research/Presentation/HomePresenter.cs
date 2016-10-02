namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Materialization;
    using Transformation;
    using UI;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui,
            ShellUi shell,
            Random rng,
            EnumerableRotator rotator)
            : base(ui, shell)
        {
            this.ui = ui;
            this.rng = rng;
            this.rotator = rotator;
        }

        public void Setup(Navigator navigator)
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            this.ui.NumberOfRotations = 1;
            this.ui.MaxValue = 1000;
            this.ui.GenerateKeyTapped += this.ui_GenerateKeyTapped;
            this.ui.RotateKeyTapped += this.ui_RotateKeyTapped;
            this.ui_GenerateKeyTapped();
            navigator.RegisterPresenter(this);
        }

        private void ui_GenerateKeyTapped()
        {
            var numbers = new LinkedList<int>();
            for (var i = 0; i < 15; ++i)
            {
                numbers.AddLast(
                    this.rng.Next(
                        0, UiHelpers.Read(
                            this.ui, () => this.ui.MaxValue)));
            }

            UiHelpers.Write(this.ui, () =>
                this.ui.Numbers = new LinkedListMaterializedEnumerable<int>(numbers));

        }

        private void ui_RotateKeyTapped()
        {
            var rotatedNumbers = this.rotator.Rotate(
                UiHelpers.Read(this.ui, () => this.ui.Numbers),
                UiHelpers.Read(this.ui, () => this.ui.NumberOfRotations));

            UiHelpers.Write(this.ui, () => this.ui.Numbers = rotatedNumbers);
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly Random rng;
        private readonly EnumerableRotator rotator;
    }
}
