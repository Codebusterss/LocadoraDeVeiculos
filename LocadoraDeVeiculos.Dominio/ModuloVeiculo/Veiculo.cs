using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double CapacidadeDoTanque { get; set; }
        public double KmPercorrido { get; set; }
        public int Ano { get; set; }
        public string TipoCombustivel { get; set; }
        public GrupoDeVeiculo GrupoDeVeiculo { get; set; }
        public byte[] Foto { get; set; }

        public override void Atualizar(Veiculo registro)
        {
            this.Marca = registro.Marca;
            this.Modelo = registro.Modelo;
            this.Placa = registro.Placa;
            this.Cor = registro.Cor;
            this.CapacidadeDoTanque = registro.CapacidadeDoTanque;
            this.KmPercorrido = registro.KmPercorrido;
            this.Ano = registro.Ano;
            this.TipoCombustivel = registro.TipoCombustivel;
            this.GrupoDeVeiculo = registro.GrupoDeVeiculo;
            this.Foto = registro.Foto;
        }


        public Veiculo()
        {

        }

        public Veiculo(string modelo, string marca, string placa, string cor, double capacidadeDoTanque, double kmPercorrido, int ano, string tipoCombustivel, GrupoDeVeiculo grupoDeVeiculo, byte[] foto) : this()
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Placa = placa;
            this.Cor = cor;
            this.CapacidadeDoTanque = capacidadeDoTanque;
            this.KmPercorrido = kmPercorrido;
            this.Ano = ano;
            this.TipoCombustivel = tipoCombustivel;
            this.GrupoDeVeiculo = grupoDeVeiculo;
            this.Foto = foto;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public Veiculo Clone()
        {
            return MemberwiseClone() as Veiculo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   ID.Equals(veiculo.ID) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   CapacidadeDoTanque == veiculo.CapacidadeDoTanque &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   Ano == veiculo.Ano &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   EqualityComparer<GrupoDeVeiculo>.Default.Equals(GrupoDeVeiculo, veiculo.GrupoDeVeiculo);
        }
    }
}
