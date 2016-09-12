namespace xofz.Research.Start
{
    using System;
    using System.Windows.Forms;
    using UI.Forms;
    using xofz.Presentation;

    internal static class EntryPoint
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootstrapper = new FormsBootstrapper(new Navigator());
            bootstrapper.Bootstrap();

            Application.Run(bootstrapper.Shell);
        }
    }
}
