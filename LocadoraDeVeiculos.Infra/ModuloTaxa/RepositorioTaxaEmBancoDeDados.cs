using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDeDados : RepositorioBase<Taxa, MapeadorTaxa>,
        IRepositorioTaxa
    {

        protected override string sqlInserir =>
            @"INSERT INTO [TAXA]
                (
                    [DESCRICAO],       
                    [VALOR], 
                    [TIPO] 
                )
            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPO
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @" UPDATE [TAXA]
                    SET 
                        [DESCRICAO] = @DESCRICAO, 
                        [VALOR] = @VALOR, 
                        [TIPO] = @TIPO
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TAXA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPO]
            FROM
                [TAXA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPO]
            FROM
                [TAXA]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorDescricao =>
                @"SELECT 
                [ID] ID,       
                [DESCRICAO] DESCRICAO,
                [VALOR] VALOR,
                [TIPO] TIPO
            FROM
                [TAXA]
            WHERE 
                [DESCRICAO] = @DESCRICAO";

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}

