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

        public Condutor()
        {


        }

        public Condutor(int n, string nome, Cliente cliente, string cpf, string cnh, DateTime validadeCNH, string email, string telefone, string endereco) : this()
        {
            ID = n;
            Nome = nome;
            Cliente = cliente;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
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
            //ver com o luan se precisa cliente
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   ID == condutor.ID &&
                   Nome == condutor.Nome &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Endereco == condutor.Endereco &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   ValidadeCNH == condutor.ValidadeCNH;

        }
    }
}
