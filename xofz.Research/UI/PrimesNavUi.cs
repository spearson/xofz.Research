namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface PrimesNavUi : Ui
    {
        event Action RotationKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;
    }
}
