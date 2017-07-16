namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface MultiPowUi : Ui
    {
        event Action ComputeKeyTapped;

        event Action DisplayKeyTapped;

        event Action SaveKeyTapped;

        event Action BigPowKeyTapped;

        string PowersInput { get; set; }

        string MultiPower { get; set; }

        string DurationInfo { get; set; }

        bool DurationInfoVisible { get; set; }
        
        bool DisplayKeyVisible { get; set; }

        bool Computing { get; set; }

        bool SaveKeyVisible { get; set; }
    }
}
