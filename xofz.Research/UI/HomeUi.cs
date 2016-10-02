namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;

    public interface HomeUi : Ui
    {
        event Action GenerateKeyTapped;

        event Action RotateKeyTapped;

        int MaxValue { get; set; }

        int NumberOfRotations { get; set; }

        MaterializedEnumerable<int> Numbers { get; set; }
    }
}
