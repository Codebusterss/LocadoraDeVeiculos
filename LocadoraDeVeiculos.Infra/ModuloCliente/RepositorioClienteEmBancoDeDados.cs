using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados :
        RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [CLIENTE]
                (
                    [NOME],
                    [CNPJ],
                    [CPF],
                    [CNH],
                    [ENDERECO],
                    [EMAIL],
                    [TELEFONE],
                    [TIPOCLIENTE]
                )
            VALUES
                (
                    @NOME,
                    @CNPJ,
                    @CPF,
                    @CNH,
                    @ENDERECO,
                    @EMAIL,
                    @TELEFONE,
                    @TIPOCLIENTE
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [CLIENTE]
                    SET 
                        [NOME] = @NOME,
                        [CNPJ] = @CNPJ,
                        [CPF] = @CPF,
                        [CNH] = @CNH,
                        [ENDERECO] = @ENDERECO,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE,
                        [TIPOCLIENTE] = @TIPOCLIENTE
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [CLIENTE]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [NOME],
                [CNPJ],
                [CPF],
                [CNH],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [TIPOCLIENTE]
            FROM
                [CLIENTE]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME],
                [CNPJ],
                [CPF],
                [CNH],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [TIPOCLIENTE]
            FROM
                [CLIENTE]
            WHERE 
                [ID] = @ID";

        public override ValidationResult Validar(Cliente registro)
        {
            var validador = new ValidadorCliente();

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

            if(registro.CPF == "")
            {
                var registroEncontradoCNPJ = SelecionarTodos()
                .Select(x => x.CNPJ.ToLower())
                .Contains(registro.CNPJ.ToLower());

                if (registroEncontradoCNPJ)
                {
                    if (registro.ID == 0)
                        resultadoValidacao.Errors.Add(new ValidationFailure("", "CNPJ já cadastrado"));
                    else if (registro.ID != 0)
                    {
                        resultadoValidacao.Errors.Add(new ValidationFailure("", "CNPJ já cadastrado"));
                    }
                }
            }
            else if(registro.CNPJ == "")
            {
                var registroEncontradoCPF = SelecionarTodos()
                .Select(x => x.CPF.ToLower())
                .Contains(registro.CPF.ToLower());

                if (registroEncontradoCPF)
                {
                    if (registro.ID == 0)
                        resultadoValidacao.Errors.Add(new ValidationFailure("", "CPF já cadastrado"));
                    else if (registro.ID != 0)
                    {
                        resultadoValidacao.Errors.Add(new ValidationFailure("", "CPF já cadastrado"));
                    }
                }
            }
            

            return resultadoValidacao;
        }
    }
}
