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
    public class RepositorioTaxaEmBancoDeDados : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa> 
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

        public override ValidationResult Validar(Taxa registro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontrado = SelecionarTodos()
                .Select(x => x.Descricao.ToLower())
                .Contains(registro.Descricao.ToLower());

            if (registroEncontrado)
            {
                if (registro.ID == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado"));
                else if (registro.ID != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}

