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
        public Nullable<string> CNPJ { get; set; }
        public Nullable<string> CPF { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }


        public Cliente()
        {

        }

        public Cliente(int n, string nome, string cnpj, string cpf, string endereco, string email, string telefone) : this()
        {
            ID = n;
            Nome = nome;
            CNPJ = cnpj;
            CPF = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public override void Atualizar(Cliente registro)
        {
            this.Nome = registro.Nome;
            this.CNPJ = registro.CNPJ;
            this.CPF = registro.CPF;
            this.Endereco = registro.Endereco;
            this.Email = registro.Endereco;
            this.Telefone = registro.Telefone;
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
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone;
        }
    }
}
