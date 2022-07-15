using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public GrupoDeVeiculo GrupoDeVeiculos { get; set; }
        public double DiarioValorDia { get; set; }
        public double DiarioValorKM { get; set; }
        public double LivreValorDia { get; set; }
        public double ControladoValorDia { get; set; }
        public double ControladoLimiteKM { get; set; }
        public double ControladoValorKM { get; set; }

        public PlanoDeCobranca()
        {

        }

        public PlanoDeCobranca(GrupoDeVeiculo grupoDeVeiculos, double diarioValorDia, double diarioValorKM, double livreValorDia, double controladoValorDia, double controladoLimiteKM, double controladoValorKM) : this()
        {
            GrupoDeVeiculos = grupoDeVeiculos;
            DiarioValorDia = diarioValorDia;
            DiarioValorKM = diarioValorKM;
            LivreValorDia = livreValorDia;
            ControladoValorDia = controladoValorDia;
            ControladoLimiteKM = controladoLimiteKM;
            ControladoValorKM = controladoValorKM;
        }

        public override void Atualizar(PlanoDeCobranca registro)
        {
            this.GrupoDeVeiculos = registro.GrupoDeVeiculos;
            this.DiarioValorDia = registro.DiarioValorDia;
            this.DiarioValorKM = registro.DiarioValorKM;
            this.LivreValorDia = registro.LivreValorDia;
            this.ControladoValorDia = registro.ControladoValorDia;
            this.ControladoLimiteKM = registro.ControladoLimiteKM;
            this.ControladoValorKM = registro.ControladoValorKM;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public PlanoDeCobranca Clone()
        {
            return MemberwiseClone() as PlanoDeCobranca;
        }
        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   ID == cobranca.ID &&
                   EqualityComparer<GrupoDeVeiculo>.Default.Equals(GrupoDeVeiculos, cobranca.GrupoDeVeiculos) &&
                   DiarioValorDia == cobranca.DiarioValorDia &&
                   DiarioValorKM == cobranca.DiarioValorKM &&
                   LivreValorDia == cobranca.LivreValorDia &&
                   ControladoValorDia == cobranca.ControladoValorDia &&
                   ControladoLimiteKM == cobranca.ControladoLimiteKM &&
                   ControladoValorKM == cobranca.ControladoValorKM;
        }
    }
}