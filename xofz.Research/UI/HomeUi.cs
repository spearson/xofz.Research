namespace xofz.Research.UI
{
    using System;
    using xofz.UI;

    public interface HomeUi : Ui
    {
        event Action LogKeyTapped;

        event Action BinaryVisualizerKeyTapped;

        string Version { get; set; }

        string Core98Version { get; set; }
    }
}
