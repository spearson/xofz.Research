namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface ControlHubNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action PrimesKeyTapped;

        event Action FactorialKeyTapped;

        event Action RotationKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;
    }
}
