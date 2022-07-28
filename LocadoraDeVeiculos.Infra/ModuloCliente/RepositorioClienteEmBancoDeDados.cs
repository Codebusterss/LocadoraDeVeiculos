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
                    [ID],
                    [NOME],
                    [CNPJ],
                    [CPF],                  
                    [ENDERECO],
                    [EMAIL],
                    [TELEFONE],
                    [PESSOAFISICA]
                )
            VALUES
                (
                    @ID,
                    @NOME,
                    @CNPJ,
                    @CPF,               
                    @ENDERECO,
                    @EMAIL,
                    @TELEFONE,
                    @PESSOAFISICA
                );";

        protected override string sqlEditar =>
            @" UPDATE [CLIENTE]
                    SET 
                        [NOME] = @NOME,
                        [CNPJ] = @CNPJ,
                        [CPF] = @CPF,                   
                        [ENDERECO] = @ENDERECO,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE,
                        [PESSOAFISICA] = @PESSOAFISICA
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
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [PESSOAFISICA]
            FROM
                [CLIENTE]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME],
                [CNPJ],
                [CPF],               
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [PESSOAFISICA]
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
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [PESSOAFISICA] PESSOAFISICA
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
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [PESSOAFISICA] PESSOAFISICA
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
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [PESSOAFISICA] PESSOAFISICA
            FROM
                [CLIENTE]
            WHERE 
                [CPF] = @CPF";

      

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

       
    }
}
