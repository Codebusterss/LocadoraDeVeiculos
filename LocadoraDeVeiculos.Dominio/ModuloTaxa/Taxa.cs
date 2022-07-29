using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa> 
    {
       public double Valor { get; set; }
       public string Tipo { get; set; }
       public string Descricao { get; set; }


        public Taxa()
        {

        }
        public Taxa(double valor, string tipo, string descricao) : this()
        {
            Valor = valor;
            Tipo = tipo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return Descricao;       
        }

        public Taxa Clone()
        {
            return MemberwiseClone() as Taxa;
        }

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   ID == taxa.ID &&
                   Valor == taxa.Valor &&
                   Tipo == taxa.Tipo &&
                   Descricao == taxa.Descricao;
        }
    }
}
