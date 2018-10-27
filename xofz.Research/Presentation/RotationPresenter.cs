namespace xofz.Research.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using UI;
    using xofz.Framework;
    using xofz.Framework.Lots;
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
            var max = UiHelpers.Read(
                this.ui,
                () => this.ui.MaxValue);
            w.Run<Random>(rng =>
            {
                for (var i = 0; i < 15; ++i)
                {
                    numbers.AddLast(rng.Next(0, max));
                }
            });

            var me = new LinkedListLot<int>(
                numbers);
            UiHelpers.Write(
                this.ui,
                () => this.ui.Numbers = me);

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
            var numbers = UiHelpers.Read(
                this.ui,
                () => this.ui.Numbers);
            Lot<int> rotatedNumbers;
            if (UiHelpers.Read(this.ui, () => this.ui.RandomizeRotations))
            {
                w.Run<Random, EnumerableRotator>((rng, rot) =>
                {
                    var cycleCount = rng.Next(1, 6);
                    rotatedNumbers = rot.Rotate(
                        numbers,
                        cycleCount,
                        goRight);
                    UiHelpers.Write(
                        this.ui,
                        () =>
                        {
                            this.ui.Numbers = rotatedNumbers;
                            this.ui.NumberOfRotations = cycleCount;
                        });
                });
                return;
            }

            w.Run<EnumerableRotator>(rot =>
            {
                rotatedNumbers = rot.Rotate(
                    numbers,
                    UiHelpers.Read(
                        this.ui,
                        () => this.ui.NumberOfRotations),
                    goRight);
                UiHelpers.Write(
                    this.ui,
                    () => this.ui.Numbers = rotatedNumbers);
            });
        }

        private int setupIf1;
        private readonly RotationUi ui;
        private readonly MethodWeb web;
    }
}
