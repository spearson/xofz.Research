namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface HomeNavUi : Ui
    {
        event Action PrimesKeyTapped;

        event Action FactorialKeyTapped;

        event Action RotationKeyTapped;

        event Action ControlHubKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;

        bool ControlHubKeyVisible { get; set; }
    }
}
