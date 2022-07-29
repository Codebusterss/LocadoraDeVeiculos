using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloLocacao
{
    public class RepositorioLocacao :
        RepositorioBase<Locacao, MapeadorLocacao>,
        IRepositorioLocacao

    {
        protected override string sqlInserir =>
            @"INSERT INTO [LOCACAO]
                (
                    [ID],
                    [VEICULOID],
                    [FUNCIONARIOID],
                    [CLIENTEID],
                    [CONDUTORID],
                    [PLANOID],
                    [DATALOCACAO],
                    [DATADEVOLUCAO],
                    [STATUSLOCACAO],
                    [SEGURO],
                    [VALOR]
                )
            VALUES
                (
                    @ID,
                    @VEICULOID,
                    @FUNCIONARIOID,
                    @CLIENTEID,
                    @CONDUTORID,
                    @PLANOID,
                    @DATALOCACAO,
                    @DATADEVOLUCAO,
                    @STATUSLOCACAO,
                    @SEGURO,
                    @VALOR
                );";

        protected override string sqlEditar =>
            @" UPDATE [LOCACAO]
                    SET 
                    [ID] = @ID,
                    [VEICULOID] = @VEICULOID,
                    [FUNCIONARIOID] = @FUNCIONARIOID,
                    [CLIENTEID] = @CLIENTEID,
                    [CONDUTORID] = @CONDUTORID,
                    [PLANOID] = @PLANOID,
                    [DATALOCACAO] = @DATALOCACAO,
                    [DATADEVOLUCAO] = @DATADEVOLUCAO,
                    [STATUSLOCACAO] = @STATUSLOCACAO,
                    [SEGURO] = @SEGURO,
                    [VALOR] = @VALOR
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [LOCACAO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
                    [VEICULOID],
                    [FUNCIONARIOID],
                    [CLIENTEID],
                    [CONDUTORID],
                    [PLANOID],
                    [DATALOCACAO],
                    [DATADEVOLUCAO],
                    [STATUSLOCACAO],
                    [SEGURO],
                    [VALOR]
            FROM
                [LOCACAO]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                    [VEICULOID],
                    [FUNCIONARIOID],
                    [CLIENTEID],
                    [CONDUTORID],
                    [PLANOID],
                    [DATALOCACAO],
                    [DATADEVOLUCAO],
                    [STATUSLOCACAO],
                    [SEGURO],
                    [VALOR]
            FROM
                [LOCACAO]
            WHERE 
                [ID] = @ID"; 
    }
}
