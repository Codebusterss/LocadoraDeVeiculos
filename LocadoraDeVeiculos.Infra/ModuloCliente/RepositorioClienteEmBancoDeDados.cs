using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados :
        RepositorioBase<Cliente, MapeadorCliente>,
        IRepositorioCliente
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

        protected string sqlSelecionarPorNome =>
                @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [CNPJ] CNPJ,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [TIPOCLIENTE] TIPOCLIENTE
            FROM
                [CLIENTE]
            WHERE 
                [NOME] = @NOME";

        protected string sqlSelecionarPorCNPJ =>
                @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [CNPJ] CNPJ,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [TIPOCLIENTE] TIPOCLIENTE
            FROM
                [CLIENTE]
            WHERE 
                [CNPJ] = @CNPJ";

        protected string sqlSelecionarPorCPF =>
                @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [CNPJ] CNPJ,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [TIPOCLIENTE] TIPOCLIENTE
            FROM
                [CLIENTE]
            WHERE 
                [CPF] = @CPF";

        protected string sqlSelecionarPorCNH =>
                @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [CNPJ] CNPJ,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [TIPOCLIENTE] TIPOCLIENTE
            FROM
                [CLIENTE]
            WHERE 
                [CNH] = @CNH";



        public Cliente SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Cliente SelecionarClientePorCNPJ(string cnpj)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNPJ, new SqlParameter("CNPJ", cnpj));
        }

        public Cliente SelecionarClientePorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", cpf));
        }

        public Cliente SelecionarClientePorCNH(string cnh)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNH, new SqlParameter("CNH", cnh));
        }
    }
}
