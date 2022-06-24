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
    public Funcionario(int n, string nome, string login, string senha, float salario, bool admin, DateTime dataAdmissao)
    {
        ID = n;
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

    public override void Atualizar(Funcionario registro)
    {
        this.Nome = registro.Nome;
        this.Login = registro.Login;
        this.Senha = registro.Senha;
        this.Salario = registro.Salario;
        this.Admin = registro.Admin;
        this.DataAdmissao = registro.DataAdmissao;
    }

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

   
}


