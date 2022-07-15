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
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.ID);
            comando.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            comando.Parameters.AddWithValue("TIPO", registro.Tipo);
            comando.Parameters.AddWithValue("VALOR", registro.Valor);
        }
        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var descricao = Convert.ToString(leitorRegistro["DESCRICAO"]);
            var tipo = Convert.ToString(leitorRegistro["TIPO"]);
            var valor = Convert.ToDouble(leitorRegistro["VALOR"]);

            Taxa taxas = new Taxa();
            taxas.ID = id;
            taxas.Descricao = descricao;
            taxas.Tipo = tipo;
            taxas.Valor = valor;

            return taxas;
        }
    }
    
    
}
