﻿namespace xofz.Research.UI
{
    using System;
    using xofz.UI;
    public interface PrimesNavUi : Ui
    {
        event Action HomeKeyTapped;

        event Action FactorialKeyTapped;

        event Action RotationKeyTapped;

        event Action BigPowKeyTapped;

        event Action ControlHubKeyTapped;

        event Action LogInKeyTapped;

        event Action ShutdownKeyTapped;

        bool ControlHubKeyVisible { get; set; }
    }
}
