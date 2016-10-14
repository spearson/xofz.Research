namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;

    public interface FactorialUi : Ui
    {
        event Action ComputeKeyTapped;

        event Action SaveKeyTapped;

        BigInteger Input { get; set; }

        string Factorial { get; set; }

        string DurationInfo { get; set; }

        bool DurationInfoVisible { get; set; }

        bool Computing { get; set; }

        bool SaveKeyVisible { get; set; }
    }
}
