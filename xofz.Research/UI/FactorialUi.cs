namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;

    public interface FactorialUi : Ui
    {
        event Action ComputeKeyTapped;

        BigInteger Input { get; set; }

        string Factorial { get; set; }

        bool Computing { get; set; }
    }
}
