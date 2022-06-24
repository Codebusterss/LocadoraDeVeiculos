using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo
{
    public class GrupoDeVeiculo : EntidadeBase<GrupoDeVeiculo>
    {
        public string Nome { get; set; }

        public GrupoDeVeiculo()
        {

        }

        public GrupoDeVeiculo(int n, string nome) : this()
        {
            ID = n;
            Nome = nome;
        }

        public override void Atualizar(GrupoDeVeiculo registro)
        {
            this.Nome = registro.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoDeVeiculo disciplina &&
                   ID == disciplina.ID &&
                   Nome == disciplina.Nome;
        }
    }
}
