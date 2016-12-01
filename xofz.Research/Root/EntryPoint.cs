﻿namespace xofz.Research.Root
{
    using System;
    using System.Windows.Forms;
    using xofz.Presentation;
    using xofz.Root;

    internal static class EntryPoint
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootstrapper = new FormsBootstrapper(
                new Navigator(),
                new CommandExecutor());
            bootstrapper.Bootstrap();

            Application.Run(bootstrapper.Shell);
        }
    }
}