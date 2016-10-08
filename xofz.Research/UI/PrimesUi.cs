namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface PrimesUi : Ui
    {
        event Action GenerateKeyTapped;

        bool Generating { get; set; }

        int NumberToGenerate { get; set; }

        long CurrentPrime { get; set; }

        int CurrentPrimeIndex { get; set; }
    }
}
