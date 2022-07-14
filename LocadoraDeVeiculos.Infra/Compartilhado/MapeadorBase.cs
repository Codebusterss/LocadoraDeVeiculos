using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T registro, SqlCommand comando);
        public override void ConfigurarParametros(ValidadorVeiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.ID);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", registro.CapacidadeDoTanque);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorrido);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("TIPOCOMBUSTIVEL", registro.TipoCombustivel);

        }

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }
}