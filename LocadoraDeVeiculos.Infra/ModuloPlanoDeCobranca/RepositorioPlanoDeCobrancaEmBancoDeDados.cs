using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaEmBancoDeDados :
        RepositorioBase<PlanoDeCobranca, MapeadorPlanoDeCobranca>,
        IRepositorioPlanoDeCobranca

    {
        protected override string sqlInserir =>
            @"INSERT INTO [PLANODECOBRANCA]
                (
                    [ID],
                    [GRUPODEVEICULOSID],  
                    [DIARIOVALORDIA],
                    [DIARIOVALORKM],
                    [LIVREVALORDIA],
                    [CONTROLADOVALORDIA],
                    [CONTROLADOLIMITEKM],
                    [CONTROLADOVALORKM]
                )
            VALUES
                (
                    @ID,
                    @GRUPODEVEICULOSID,
                    @DIARIOVALORDIA,
                    @DIARIOVALORKM,
                    @LIVREVALORDIA,
                    @CONTROLADOVALORDIA,
                    @CONTROLADOLIMITEKM,
                    @CONTROLADOVALORKM
                );";

        protected override string sqlEditar =>
            @" UPDATE [PLANODECOBRANCA]
                    SET 
                        [GRUPODEVEICULOSID] = @GRUPODEVEICULOSID,
                        [DIARIOVALORDIA] = @DIARIOVALORDIA,
                        [DIARIOVALORKM] = @DIARIOVALORKM,
                        [LIVREVALORDIA] = @LIVREVALORDIA,
                        [CONTROLADOVALORDIA] = @CONTROLADOVALORDIA,
                        [CONTROLADOLIMITEKM] = @CONTROLADOLIMITEKM,
                        [CONTROLADOVALORKM] = @CONTROLADOVALORKM
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [PLANODECOBRANCA]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [GRUPODEVEICULOSID],
                [DIARIOVALORDIA],
                [DIARIOVALORKM],
                [LIVREVALORDIA],
                [CONTROLADOVALORDIA],
                [CONTROLADOLIMITEKM],
                [CONTROLADOVALORKM]
            FROM
                [PLANODECOBRANCA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [GRUPODEVEICULOSID],
                [DIARIOVALORDIA],
                [DIARIOVALORKM],
                [LIVREVALORDIA],
                [CONTROLADOVALORDIA],
                [CONTROLADOLIMITEKM],
                [CONTROLADOVALORKM]
            FROM
                [PLANODECOBRANCA]
            WHERE 
                [ID] = @ID";
        protected string sqlSelecionarPorIdDoGrupo =>
            @"SELECT 
                [ID],       
                [GRUPODEVEICULOSID],
                [DIARIOVALORDIA],
                [DIARIOVALORKM],
                [LIVREVALORDIA],
                [CONTROLADOVALORDIA],
                [CONTROLADOLIMITEKM],
                [CONTROLADOVALORKM]
            FROM
                [PLANODECOBRANCA]
            WHERE 
                [GRUPODEVEICULOSID] = @GRUPODEVEICULOSID";

        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid idGrupo)
        {
            return SelecionarPorParametro(sqlSelecionarPorIdDoGrupo, new SqlParameter("GRUPODEVEICULOS_ID", idGrupo));
        }
    }
}
