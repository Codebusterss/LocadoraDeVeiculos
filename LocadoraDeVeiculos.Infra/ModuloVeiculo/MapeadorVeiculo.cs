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
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var modelo = Convert.ToString(leitorRegistro["MODELO"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var cor = Convert.ToString(leitorRegistro["COR"]);
            var capacidadetanque = Convert.ToDouble(leitorRegistro["CAPACIDADEDOTANQUE"]);
            var kmpercorrido = Convert.ToDouble(leitorRegistro["KMPERCORRIDO"]);
            var ano = Convert.ToDouble(leitorRegistro["ANO"]);
            var tipocombustivel = Convert.ToDouble(leitorRegistro["TIPOCOMBUSTIVEL"]);

            Veiculo veiculo = new Veiculo();
            veiculo.ID = id;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            veiculo.Cor = cor;

            return veiculo;
        }
    }
}
