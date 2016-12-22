namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class RotationPresenter : Presenter
    {
        public RotationPresenter(
            RotationUi ui,
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

            this.ui.NumberOfRotations = 1;
            this.ui.MaxValue = 1000;
            this.ui.GenerateKeyTapped += this.ui_GenerateKeyTapped;
            this.ui.RotateRightKeyTapped += this.ui_RotateRightKeyTapped;
            this.ui.RotateLeftKeyTapped += this.ui_RotateLeftKeyTapped;
            this.ui_GenerateKeyTapped();

            this.web.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        private void ui_GenerateKeyTapped()
        {
            var numbers = new LinkedList<int>();
            var w = this.web;
            for (var i = 0; i < 15; ++i)
            {
                numbers.AddLast(
                    w.Run<Random, int>(rng => rng.Next(
                        0, UiHelpers.Read(
                            this.ui, () => this.ui.MaxValue))));
            }

            UiHelpers.Write(this.ui, () =>
                this.ui.Numbers = new LinkedListMaterializedEnumerable<int>(numbers));

        }

        private void ui_RotateRightKeyTapped()
        {
            this.rotateKeyTapped(true);
        }

        private void ui_RotateLeftKeyTapped()
        {
            this.rotateKeyTapped(false);
        }

        private void rotateKeyTapped(bool goRight)
        {
            var w = this.web;
            var numbers = UiHelpers.Read(this.ui, () => this.ui.Numbers);
            MaterializedEnumerable<int> rotatedNumbers;
            if (UiHelpers.Read(this.ui, () => this.ui.RandomizeRotations))
            {
                var rotations = w.Run<Random, int>(rng => rng.Next(1, 6));
                rotatedNumbers = w.Run<EnumerableRotator, MaterializedEnumerable<int>>(
                    r => r.Rotate(
                        numbers,
                        rotations,
                        goRight));
                UiHelpers.Write(this.ui, () => this.ui.NumberOfRotations = rotations);
            }
            else
            {
                rotatedNumbers = w.Run<EnumerableRotator, MaterializedEnumerable<int>>(
                    r => r.Rotate(
                        numbers,
                        UiHelpers.Read(this.ui, () => this.ui.NumberOfRotations),
                        goRight));
            }

            UiHelpers.Write(this.ui, () => this.ui.Numbers = rotatedNumbers);
        }

        private int setupIf1;
        private readonly RotationUi ui;
        private readonly MethodWeb web;
    }
}
