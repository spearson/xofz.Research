namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface PrimesUi : Ui
    {
        event Action GenerateKeyTapped;

        event Action StopKeyTapped;

        event Action RestartKeyTapped;

        event Action SaveKeyTapped;

        event Action LoadKeyTapped;

        string LoadLocation { get; set; }

        bool Generating { get; set; }

        bool Stopping { get; set; }

        bool RestartKeyVisible { get; set; }

        bool StopKeyVisible { get; set; }

        bool LoadKeyVisible { get; set; }

        bool SaveKeyVisible { get; set; }

        int NumberToGenerate { get; set; }

        long? CurrentPrime { get; set; }

        int? CurrentPrimeIndex { get; set; }

        void DisplayLoadLocator();
    }
}
