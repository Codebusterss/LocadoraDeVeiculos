
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDeDados : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa> 
    {
        private const string enderecoBanco =
         @"(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        protected override string sqlInserir =>
            @"INSERT INTO [TAXA]
                (
                    [DESCRICAO],       
                    [VALOR], 
                    [TIPO] 
                )
            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPO
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @" UPDATE [TAXA]
                    SET 
                        [DESCRICAO] = @DESCRICAO, 
                        [VALOR] = @VALOR, 
                        [TIPO] = @TIPO
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TAXA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPO]
            FROM
                [TAXA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPO]
            FROM
                [TAXA]
            WHERE 
                [ID] = @ID";

        public ValidationResult Inserir( Taxa novoRegistro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
            {
                return resultadoValidacao;
            }

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTaxas(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.ID = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Editar(Taxa registro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var x = SelecionarPorID(registro.ID);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTaxas(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Excluir(Taxa registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", registro.ID);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Taxa SelecionarPorID(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorTaxa = comandoSelecao.ExecuteReader();

            Taxa taxas = null;
            if (leitorTaxa.Read())
                taxas = ConverterParaTaxa(leitorTaxa);

            conexaoComBanco.Close();

            return taxas;
        }
        public List<Taxa> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTaxa = comandoSelecao.ExecuteReader();

            List<Taxa> taxa = new List<Taxa>();

            while (leitorTaxa.Read())
            {
                Taxa taxas = ConverterParaTaxa(leitorTaxa);

                taxa.Add(taxas);
            }

            conexaoComBanco.Close();

            return taxa;
        }
        private Taxa ConverterParaTaxa(SqlDataReader leitorTaxa)
        {
            var id = Convert.ToInt32(leitorTaxa["ID"]);
            var tipo = Convert.ToString(leitorTaxa["TIPO"]);
            var descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            var valor = Convert.ToInt32(leitorTaxa["VALOR"]);
          

            Taxa taxas = new Taxa();
            taxas.ID = id;
            taxas.Tipo = tipo;
            taxas.Descricao = descricao;
            taxas.Valor = valor;
          

            return taxas;
        }
        private void ConfigurarParametrosTaxas(Taxa taxas, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", taxas.ID);
            comando.Parameters.AddWithValue("TIPO", taxas.Tipo);
            comando.Parameters.AddWithValue("DESCRICAO", taxas.Descricao);
            comando.Parameters.AddWithValue("VALOR", taxas.Valor);
           

            

        }
    }

}

