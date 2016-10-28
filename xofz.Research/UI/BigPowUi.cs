namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;

    public interface BigPowUi : Ui
    {
        event Action ComputeKeyTapped;

        event Action DisplayKeyTapped;

        event Action SaveKeyTapped;

        BigInteger NumberInput { get; set; }

        BigInteger ExponentInput { get; set; }

        string Power { get; set; }

        string DurationInfo { get; set; }

        bool DurationInfoVisible { get; set; }

        bool DisplayKeyVisible { get; set; }

        bool Computing { get; set; }

        bool SaveKeyVisible { get; set; }
    }
}
