namespace xofz.Research.UI
{
    using System;
    using System.Numerics;
    using xofz.UI;
    public interface BinaryVisualizerUi : Ui
    {
        event Action TranslateKeyTapped;

        BigInteger Input { get; set; }

        string Binary { get; set; }

        bool Translating { get; set; }
    }
}
