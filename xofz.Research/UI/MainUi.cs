namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface MainUi : Ui
    {
        event Action ShutdownRequested;
    }
}
