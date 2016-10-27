namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface BigPowNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action PrimesKeyTapped;

        event Action FactorialKeyTapped;

        event Action RotationKeyTapped;

        event Action ControlHubKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;

        bool ControlHubKeyVisible { get; set; }
    }
}
