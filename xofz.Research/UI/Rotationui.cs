namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface RotationUi : Ui
    {
        event Action GenerateKeyTapped;

        event Action RotateLeftKeyTapped;

        event Action RotateRightKeyTapped;

        bool RandomizeRotations { get; set; }

        int MaxValue { get; set; }

        int NumberOfRotations { get; set; }

        MaterializedEnumerable<int> Numbers { get; set; }
    }
}
