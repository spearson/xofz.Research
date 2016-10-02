namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface MainUi : ShellUi
    {
        event Action ShutdownRequested;
    }
}
