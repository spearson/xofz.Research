namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface FactorialNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action PrimesKeyTapped;

        event Action RotationKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;
    }
}
