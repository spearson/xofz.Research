namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface HomeNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action PrimesKeyTapped;

        event Action FactorialKeyTapped;

        event Action RotationKeyTapped;

        event Action BigPowKeyTapped;

        event Action ControlHubKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;

        bool ControlHubKeyVisible { get; set; }

        bool HomeKeyVisible { get; set; }
    }
}
