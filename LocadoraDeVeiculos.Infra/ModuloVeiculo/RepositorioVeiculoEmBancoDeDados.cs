using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDeDados : RepositorioBase<Veiculo, MapeadorVeiculo>,
        IRepositorioVeiculo
    {

        protected override string sqlInserir =>
            @"INSERT INTO [VEICULO]
                (
                    [ID],
                    [MODELO],
                    [MARCA],
                    [ANO],
                    [COR],
                    [PLACA],
                    [KMPERCORRIDO],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [GRUPODEVEICULOID],
                    [FOTO]
                )
                VALUES
                (
                    @ID,
                    @MODELO,
                    @MARCA,
                    @ANO,
                    @COR,
                    @PLACA,
                    @KMPERCORRIDO,
                    @TIPOCOMBUSTIVEL,
                    @CAPACIDADEDOTANQUE,
                    @GRUPODEVEICULOID,
                    @FOTO
                )";

        protected override string sqlEditar =>
           @" UPDATE [VEICULO]
                    SET 
                    [MODELO] = @MODELO,
                    [MARCA] = @MARCA,
                    [ANO] = @ANO,
                    [COR] = @COR,
                    [PLACA] = @PLACA,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                    [CAPACIDADEDOTANQUE] = @CAPACIDADEDOTANQUE,
                    [GRUPODEVEICULOID] = @GRUPODEVEICULOID,
                    [FOTO] = @FOTO

                WHERE 
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [VEICULO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
                    [MODELO],
                    [MARCA],
                    [ANO],
                    [COR],
                    [PLACA],
                    [KMPERCORRIDO],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [GRUPODEVEICULOID],
                    [FOTO]
            FROM
                [VEICULO]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
              [ID],
              [MODELO],
              [MARCA],
              [ANO],
              [COR],
              [PLACA],
              [KMPERCORRIDO],
              [TIPOCOMBUSTIVEL],
              [CAPACIDADEDOTANQUE],
              [GRUPODEVEICULOID],
              [FOTO]
            FROM
                [VEICULO]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorPlaca =>
            @"SELECT 
              [ID],
              [MODELO],
              [MARCA],
              [ANO],
              [COR],
              [PLACA],
              [KMPERCORRIDO],
              [TIPOCOMBUSTIVEL],
              [CAPACIDADEDOTANQUE],
              [GRUPODEVEICULOID],
              [FOTO]
            FROM
                [VEICULO]
            WHERE 
                [PLACA] = @PLACA";

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
