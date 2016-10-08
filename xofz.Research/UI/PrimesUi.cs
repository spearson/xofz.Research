﻿namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface PrimesUi : Ui
    {
        event Action GenerateKeyTapped;

        event Action RestartKeyTapped;

        event Action SaveKeyTapped;

        bool Generating { get; set; }

        int NumberToGenerate { get; set; }

        long? CurrentPrime { get; set; }

        int? CurrentPrimeIndex { get; set; }
    }
}
