using LocadoraDeVeiculos.Infra.Logging;
using LocadoraDeVeiculos.ORM.Compartilhado;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();
            ConfiguracaoLogs.ConfigurarEscritaLogs();
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaLogin());
        }
    }
}