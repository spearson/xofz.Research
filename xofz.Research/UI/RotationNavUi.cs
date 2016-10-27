namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface RotationNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action PrimesKeyTapped;

        event Action FactorialKeyTapped;

        event Action BigPowKeyTapped;

        event Action ControlHubKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;

        bool ControlHubKeyVisible { get; set; }
    }
}
