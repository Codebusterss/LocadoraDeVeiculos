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
                    [MODELO],       
                    [MARCA],
                    [PLACA], 
                    [COR],
                    [CAPACIDADEDOTANQUE],
                    [KMPERCORRIDO],
                    [ANO],
                    [TIPOCOMBUSTIVEL],
                )
            VALUES
                (
                    @MODELO,
                    @MARCA,
                    @PLACA,
                    @COR,
                    @CAPACIDADEDOTANQUE,
                    @KMPERCORRIDO,
                    @ANO,
                    @TIPOCOMBUSITVEL,
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @" UPDATE [VEICULO]
                    SET 
                        [MODELO] = @MODELO, 
                        [MARCA] = @MARCA, 
                        [PLACA] = @PLACA,
                        [COR] = @COR,
                        [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                        [KMPERCORRIDO] = @KMPERCORRIDO,
                        [ANO] = @ANO,
                        [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [VEICULO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [MODELO],       
                [MARCA],
                [PLACA], 
                [COR],
                [CAPACIDADEDOTANQUE],
                [KMPERCORRIDO],
                [ANO],
                [TIPOCOMBUSTIVEL],
            FROM
                [VEICULO]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
              [MODELO],       
              [MARCA],
              [PLACA], 
              [COR],
              [CAPACIDADEDOTANQUE],
              [KMPERCORRIDO],
              [ANO],
              [TIPOCOMBUSTIVEL]
            FROM
                [VEICULO]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorDescricao =>
                @"SELECT 
                [MODELO] MODELO,       
                [MARCA] MARCA,
                [PLACA] PLACA,
                [COR] COR,
                [CAPACIDADEDOTANQUE] CAPACIDADEDOTANQUE,
                [KMPERCORRIDO] KMPERCORRIDO,
                [ANO] ANO,
                [TIPOCOMBUSTIVEL] TIPOCOMBUSTIVEL
            FROM
                [VEICULO]
            WHERE 
                [MODELOO] = @MODELO";

        public Veiculo SelecionarFuncionarioPorLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarFuncionarioPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
