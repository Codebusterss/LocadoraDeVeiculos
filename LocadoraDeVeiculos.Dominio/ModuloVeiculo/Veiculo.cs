using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

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
        public string Ano { get; set; }
        public string TipoCombustivel { get; set; }
        public static object Count { get; set; }

        public override void Atualizar(Veiculo registro)
        {
            throw new NotImplementedException();
        }


        public Veiculo()
        {

        }

        public Veiculo(int n, string modelo, string marca, string placa, string cor, double capacidadeDoTanque, double kmPercorrido, string ano, string tipoCombustivel) : this()
        {
            ID = n;
            Modelo = modelo;
            Marca = marca;
            Placa = placa;
            Cor = cor;
            CapacidadeDoTanque = capacidadeDoTanque;
            KmPercorrido = kmPercorrido;
            Ano = ano;
            TipoCombustivel = tipoCombustivel;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&

                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   CapacidadeDoTanque == veiculo.CapacidadeDoTanque &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   Ano == veiculo.Ano &&
                   TipoCombustivel == veiculo.TipoCombustivel;

        }










    }
}
