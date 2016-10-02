namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface HomeNavUi : Ui
    {
        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;
    }
}
