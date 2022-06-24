using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    internal class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [FUNCIONARIO]
                (
                    [NOME]      
                )
            VALUES
                (
                    @NOME
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [FUNCIONARIO]
                    SET 
                        [NOME] = @NOME
                        [LOGIN] = @LOGIN
                        [SENHA] = @SENHA
                        [SALARIO] = @SALARIO
                        [DATADEADMISSAO] = @DATAADMISSAO
                        [ADMIN] = @ADMIN
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [FUNCIONARIO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATADEADMISSAO],
                [ADMIN]
            FROM
                [FUNCIONARIO]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATADEADMISSAO],
                [ADMIN]
            FROM
                [FUNCIONARIO]
            WHERE 
                [ID] = @ID";

        
    }
}

