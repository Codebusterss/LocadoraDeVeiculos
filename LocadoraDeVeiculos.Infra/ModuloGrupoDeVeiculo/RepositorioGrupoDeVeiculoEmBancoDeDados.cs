using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosEmBancoDeDados :
        RepositorioBase<GrupoDeVeiculo, MapeadorGrupoDeVeiculo>,
        IRepositorioGrupoDeVeiculo
    {
        protected override string sqlInserir =>
            @"INSERT INTO [GRUPODEVEICULOS]
                (
                    [ID],
                    [NOME]      
                )
            VALUES
                (
                    @ID,
                    @NOME
                );";

        protected override string sqlEditar =>
            @" UPDATE [GRUPODEVEICULOS]
                    SET 
                        [NOME] = @NOME
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [GRUPODEVEICULOS]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [NOME]
            FROM
                [GRUPODEVEICULOS]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME]
            FROM
                [GRUPODEVEICULOS]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorNome =>
                @"SELECT 
                   [ID] ID,       
                   [NOME] NOME
            FROM
                [GRUPODEVEICULOS]
            WHERE 
                [NOME] = @NOME";

        public GrupoDeVeiculo SelecionarGrupoPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}

