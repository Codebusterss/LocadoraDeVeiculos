using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public bool CondutorCliente { get; set; }

        public Condutor()
        {
           

        }

        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }


        public Condutor( string nome, Cliente cliente, string cpf, string cnh, DateTime validadeCNH, string email, string telefone, string endereco, bool condutorcliente) : this()
        {
          
            Nome = nome;
            Cliente = cliente;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            CondutorCliente = condutorcliente;
        }

        public override void Atualizar(Condutor registro)
        {
            this.Nome = registro.Nome;
            this.CPF = registro.CPF;
            this.CNH = registro.CNH;
            this.ValidadeCNH = registro.ValidadeCNH;
            this.Email = registro.Endereco;
            this.Telefone = registro.Telefone;
            this.Endereco = registro.Endereco;
            this.CondutorCliente = registro.CondutorCliente;
            this.Cliente = registro.Cliente;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                    EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   ID == condutor.ID &&
                   Nome == condutor.Nome &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Endereco == condutor.Endereco &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   ValidadeCNH == condutor.ValidadeCNH &&
                   CondutorCliente == condutor.CondutorCliente;

        }
    }
}
