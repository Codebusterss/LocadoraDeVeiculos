﻿using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados : RepositorioBase<Condutor, MapeadorCondutor>, IRepositorioCondutor
    {


        protected override string sqlInserir =>
            @"INSERT INTO [CONDUTOR]
                (
                    [ID],
                    [CLIENTEID],
                    [NOME],
                    [VALIDADECNH],
                    [CPF],
                    [CNH],
                    [ENDERECO],
                    [EMAIL],
                    [TELEFONE],
                    [CONDUTORCLIENTE]
                    
                )
            VALUES
                ( 
                    @ID,
                    @CLIENTEID,
                    @NOME,
                    @VALIDADECNH,
                    @CPF,
                    @CNH,
                    @ENDERECO,
                    @EMAIL,
                    @TELEFONE,
                    @CONDUTORCLIENTE
                );";

        protected override string sqlEditar =>
            @" UPDATE [CONDUTOR]
                    SET 
                        [CLIENTEID] = @CLIENTEID,
                        [NOME] = @NOME,
                        [VALIDADECNH] = @VALIDADECNH,
                        [CPF] = @CPF,
                        [CNH] = @CNH,
                        [ENDERECO] = @ENDERECO,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE,
                        [CONDUTORCLIENTE] = @CONDUTORCLIENTE
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [CONDUTOR]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID], 
                [CLIENTEID],
                [NOME],
                [VALIDADECNH],
                [CPF],
                [CNH],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [CONDUTORCLIENTE]
            FROM
                [CONDUTOR]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],  
                [CLIENTEID],
                [NOME],
                [VALIDADECNH],
                [CPF],
                [CNH],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [CONDUTORCLIENTE]
            FROM
                [CONDUTOR]
            WHERE 
                [ID] = @ID";

        protected string sqlSelecionarPorNome =>
                @"SELECT 
                   [ID] ID, 
                   [CLIENTEID] CLIENTEID,
                   [NOME] NOME,
                   [VALIDADECNH] VALIDADECNH,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [CONDUTORCLIENTE] CONDUTORCLIENTE
            FROM
                [CONDUTOR]
            WHERE 
                [NOME] = @NOME";

      

        protected string sqlSelecionarPorCPF =>
                @"SELECT 
                   [ID] ID,     
                   [CLIENTEID] CLIENTEID,
                   [NOME] NOME,
                   [VALIDADECNH] VALIDADECNH,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [CONDUTORCLIENTE] CONDUTORCLIENTE
            FROM
                [CONDUTOR]
            WHERE 
                [CPF] = @CPF";

        protected string sqlSelecionarPorCNH =>
                @"SELECT 
                   [ID] ID,
                   [CLIENTEID] CLIENTEID,
                   [NOME] NOME,
                   [VALIDADECNH] VALIDADECNH,
                   [CPF] CPF,
                   [CNH] CNH,
                   [ENDERECO] ENDERECO,
                   [EMAIL] EMAIL,
                   [TELEFONE] TELEFONE,
                   [CONDUTORCLIENTE] CONDUTORCLIENTE
            FROM
                [CONDUTOR]
            WHERE 
                [CNH] = @CNH";



        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", cpf));
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNH, new SqlParameter("CNH", cnh));
        }
    }

}
