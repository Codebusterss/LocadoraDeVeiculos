using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Testes.Compartilhado
{

    public class BaseIntegrationTest
    {
        public BaseIntegrationTest()
        {
            Db.ExecutarSql("DELETE FROM TAXA;");

            Db.ExecutarSql("DELETE FROM CONDUTOR;");

            Db.ExecutarSql("DELETE FROM CLIENTE;");

            Db.ExecutarSql("DELETE FROM FUNCIONARIO;");

            Db.ExecutarSql("DELETE FROM VEICULO;");

            Db.ExecutarSql("DELETE FROM PLANODECOBRANCA;");

            Db.ExecutarSql("DELETE FROM GRUPODEVEICULOS;");
        }
    }
}