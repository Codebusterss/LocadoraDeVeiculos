using LocadoraDeVeiculos.Infra.Logging;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogs.ConfigurarEscritaLogs();
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaLogin());
        }
    }
}