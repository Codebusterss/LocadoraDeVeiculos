using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool PessoaFisica { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cnpj, string cpf, string cnh, string endereco, string email, string telefone, bool pessoaFisica) : this()
        {
            Nome = nome;
            CNPJ = cnpj;
            CPF = cpf;
            CNH = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            PessoaFisica = pessoaFisica;
        }

        public override void Atualizar(Cliente registro)
        {
            this.Nome = registro.Nome;
            this.CNPJ = registro.CNPJ;
            this.CPF = registro.CPF;
            this.CNH = registro.CNH;
            this.Endereco = registro.Endereco;
            this.Email = registro.Endereco;
            this.Telefone = registro.Telefone;
            this.PessoaFisica = registro.PessoaFisica;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   ID == cliente.ID &&
                   Nome == cliente.Nome &&
                   CNPJ == cliente.CNPJ &&
                   CPF == cliente.CPF &&
                   CNH == cliente.CNH &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   PessoaFisica == cliente.PessoaFisica;
        }
    }
}
