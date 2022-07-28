using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

public class Funcionario : EntidadeBase<Funcionario>
{
    public Funcionario()
    {

    }
    public Funcionario(string nome, string login, string senha, float salario, bool admin, DateTime dataAdmissao)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Salario = salario;
        DataAdmissao = dataAdmissao;
        Admin = admin;
    }

    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public float Salario { get; set; }
    public bool Admin { get; set; }
    public DateTime DataAdmissao { get; set; }

    public override string? ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return obj is Funcionario funcionario &&

               DataAdmissao == funcionario.DataAdmissao &&
               Login == funcionario.Login &&
               Senha == funcionario.Senha &&
               Salario == funcionario.Salario;

    }
    public Funcionario Clone()
    {
        return MemberwiseClone() as Funcionario;
    }

}


