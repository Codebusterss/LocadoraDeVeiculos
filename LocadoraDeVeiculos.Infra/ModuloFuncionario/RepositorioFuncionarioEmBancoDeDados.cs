﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentValidation.Results;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>,
        IRepositorioFuncionario

    {
        protected override string sqlInserir =>
            @"INSERT INTO [FUNCIONARIO]
                (
                    [ID],
                    [NOME],
                    [LOGIN],
                    [SENHA],
                    [SALARIO],
                    [DATAADMISSAO],
                    [ADMIN]
                )
            VALUES
                (
                    @ID,
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @ADMIN
                );";

        protected override string sqlEditar =>
            @" UPDATE [FUNCIONARIO]
                    SET 
                        [NOME] = @NOME,
                        [LOGIN] = @LOGIN,
                        [SENHA] = @SENHA,
                        [SALARIO] = @SALARIO,
                        [DATAADMISSAO] = @DATAADMISSAO,
                        [ADMIN] = @ADMIN
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [FUNCIONARIO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [ADMIN]
            FROM
                [FUNCIONARIO]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [ADMIN]
            FROM
                [FUNCIONARIO]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorNome =>
               @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [LOGIN] LOGIN,
                   [SENHA] SENHA,
                   [DATAADMISSAO] DATAADMISSAO,
                   [SALARIO] SALARIO,
                   [ADMIN] ADMIN
            FROM
                [FUNCIONARIO]
            WHERE 
                [NOME] = @NOME";

        protected string sqlSelecionarPorLogin =>
            @"SELECT 
                   [ID] ID,       
                   [NOME] NOME,
                   [LOGIN] LOGIN,
                   [SENHA] SENHA,
                   [DATAADMISSAO] DATAADMISSAO,
                   [SALARIO] SALARIO,
                   [ADMIN] ADMIN
            FROM
                [FUNCIONARIO]
            WHERE 
                [LOGIN] = @LOGIN";

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }
    }
}

