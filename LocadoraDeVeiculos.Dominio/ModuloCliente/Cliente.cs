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
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool PessoaFisica { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cnpj, string cpf, string endereco, string email, string telefone, bool pessoaFisica) : this()
        {
            Nome = nome;
            CNPJ = cnpj;
            CPF = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            PessoaFisica = pessoaFisica;
        }

        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   ID == cliente.ID &&
                   Nome == cliente.Nome &&
                   CNPJ == cliente.CNPJ &&
                   CPF == cliente.CPF &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   PessoaFisica == cliente.PessoaFisica;
        }
    }
}
