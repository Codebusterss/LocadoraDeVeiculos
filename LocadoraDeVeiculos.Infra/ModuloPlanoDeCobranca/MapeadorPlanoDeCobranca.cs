using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;


namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

        public override void ConfigurarParametros(PlanoDeCobranca planoDeCobranca, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", planoDeCobranca.ID);
            comando.Parameters.AddWithValue("GRUPODEVEICULOS_ID", planoDeCobranca.GrupoDeVeiculos.ID);
            comando.Parameters.AddWithValue("DIARIOVALORDIA", planoDeCobranca.DiarioValorDia);
            comando.Parameters.AddWithValue("DIARIOVALORKM", planoDeCobranca.DiarioValorKM);
            comando.Parameters.AddWithValue("LIVREVALORDIA", planoDeCobranca.LivreValorDia);
            comando.Parameters.AddWithValue("CONTROLADOVALORDIA", planoDeCobranca.ControladoValorDia);
            comando.Parameters.AddWithValue("CONTROLADOLIMITEKM", planoDeCobranca.ControladoLimiteKM);
            comando.Parameters.AddWithValue("CONTROLADOVALORKM", planoDeCobranca.ControladoValorKM);
        }



        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorPlanoDeCobranca)
        {
            var id = Convert.ToInt32(leitorPlanoDeCobranca["ID"]);
            var grupoDeVeiculosID = Convert.ToInt32(leitorPlanoDeCobranca["GRUPODEVEICULOS_ID"]);
            var diarioValorDia = Convert.ToDouble(leitorPlanoDeCobranca["DIARIOVALORDIA"]);
            var diarioValorKM = Convert.ToDouble(leitorPlanoDeCobranca["DIARIOVALORKM"]);
            var livreValorDia = Convert.ToDouble(leitorPlanoDeCobranca["LIVREVALORDIA"]);
            var controladoValorDia = Convert.ToDouble(leitorPlanoDeCobranca["CONTROLADOVALORDIA"]);
            var controladoLimiteKM = Convert.ToDouble(leitorPlanoDeCobranca["CONTROLADOLIMITEKM"]);
            var controladoValorKM = Convert.ToDouble(leitorPlanoDeCobranca["CONTROLADOVALORKM"]);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.ID = id;
            planoDeCobranca.GrupoDeVeiculos = repositorioGrupo.SelecionarPorId(grupoDeVeiculosID);
            // new MapeadorGrupoDeVeiculo().ConverterRegistro(leitorPlanoDeCobranca);
            planoDeCobranca.DiarioValorDia = diarioValorDia;
            planoDeCobranca.DiarioValorKM = diarioValorKM;
            planoDeCobranca.LivreValorDia = livreValorDia;
            planoDeCobranca.ControladoValorDia = controladoValorDia;
            planoDeCobranca.ControladoLimiteKM = controladoLimiteKM;
            planoDeCobranca.ControladoValorKM = controladoValorKM;

            return planoDeCobranca;
        }
    }
}