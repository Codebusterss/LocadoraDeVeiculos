using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;

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
                    [ENDERECO],
                    [EMAIL],
                    [TELEFONE]
                )
            VALUES
                (
                    @NOME,
                    @CNPJ,
                    @CPF,
                    @ENDERECO,
                    @EMAIL,
                    @TELEFONE
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [CLIENTE]
                    SET 
                        [NOME] = @NOME,
                        [CNPJ] = @CNPJ,
                        [CPF] = @CPF,
                        [ENDERECO] = @ENDERECO,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE
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
                [TELEFONE]
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
                [TELEFONE]
            FROM
                [CLIENTE]
            WHERE 
                [ID] = @ID";
    }
}
