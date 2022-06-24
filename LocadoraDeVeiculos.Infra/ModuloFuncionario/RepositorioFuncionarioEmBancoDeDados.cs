using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [FUNCIONARIO]
                (
                    [NOME],  
                    [LOGIN],
                    [SENHA],
                    [SALARIO],
                    [DATADEADMISSAO],
                    [ADMIN]
                )
            VALUES
                (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATADEADMISSAO,
                    @ADMIN
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [FUNCIONARIO]
                    SET 
                        [NOME] = @NOME,
                        [LOGIN] = @LOGIN,
                        [SENHA] = @SENHA,
                        [SALARIO] = @SALARIO,
                        [DATADEADMISSAO] = @DATADEADMISSAO,
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

        public override ValidationResult Validar(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontradoNome = SelecionarTodos()
                .Select(x => x.Nome.ToLower())
                .Contains(registro.Nome.ToLower());

            if (registroEncontradoNome)
            {
                if (registro.ID == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionário já cadastrado"));
                else if (registro.ID != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionário já cadastrado"));
                }
            }

            var registroEncontradoLogin = SelecionarTodos()
                .Select(x => x.Login.ToLower())
                .Contains(registro.Login.ToLower());

            if (registroEncontradoLogin)
            {
                if (registro.ID == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já cadastrado"));
                else if (registro.ID != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}

