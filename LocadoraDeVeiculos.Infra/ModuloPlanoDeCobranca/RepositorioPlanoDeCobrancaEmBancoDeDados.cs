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
                    [GRUPODEVEICULOS_ID],  
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
                    @GRUPODEVEICULOS_ID,
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
                        [GRUPODEVEICULOS_ID] = @GRUPODEVEICULOS_ID,
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
                [GRUPODEVEICULOS_ID],
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
                [GRUPODEVEICULOS_ID],
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
                [GRUPODEVEICULOS_ID],
                [DIARIOVALORDIA],
                [DIARIOVALORKM],
                [LIVREVALORDIA],
                [CONTROLADOVALORDIA],
                [CONTROLADOLIMITEKM],
                [CONTROLADOVALORKM]
            FROM
                [PLANODECOBRANCA]
            WHERE 
                [GRUPODEVEICULOS_ID] = @GRUPODEVEICULOS_ID";

        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid idGrupo)
        {
            return SelecionarPorParametro(sqlSelecionarPorIdDoGrupo, new SqlParameter("GRUPODEVEICULOS_ID", idGrupo));
        }
    }
}
