namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;

    public interface RotationUi : Ui
    {
        event Action GenerateKeyTapped;

        event Action RotateKeyTapped;

        bool RandomizeRotations { get; set; }

        int MaxValue { get; set; }

        int NumberOfRotations { get; set; }

        MaterializedEnumerable<int> Numbers { get; set; }
    }
}
