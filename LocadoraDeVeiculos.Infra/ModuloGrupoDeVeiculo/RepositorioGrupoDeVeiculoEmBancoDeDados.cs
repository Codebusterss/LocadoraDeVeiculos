using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosEmBancoDeDados :
        RepositorioBase<GrupoDeVeiculo, ValidadorGrupoDeVeiculo, MapeadorGrupoDeVeiculo>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [GRUPODEVEICULOS]
                (
                    [NOME]      
                )
            VALUES
                (
                    @NOME
                ); SELECT SCOPE_IDENTITY();";

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

        public override ValidationResult Validar(GrupoDeVeiculo registro)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontradoNome = SelecionarTodos()
                .Select(x => x.Nome.ToLower())
                .Contains(registro.Nome.ToLower());

            if (registroEncontradoNome)
            {
                if (registro.ID == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Cliente já cadastrado"));
                else if (registro.ID != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Cliente já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}

