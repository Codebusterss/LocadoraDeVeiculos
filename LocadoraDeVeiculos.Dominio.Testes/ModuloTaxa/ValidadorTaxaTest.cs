using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloTaxa
{
    public class ValidadorTaxaTest
    {
        private Taxa taxa;
        private ValidadorTaxa validadortaxa;

  
        [TestMethod]
        public void Descricao_deve_ter_no_minimo_2_caracteres()
        {
            //arrange
            Taxa taxa = new Taxa();
            taxa.Descricao = "Nome";
            taxa.Valor = 234;
            taxa.Tipo = "CNPJ";
          
            validadortaxa = new ValidadorTaxa();

            //action
            var resultadoValidacao = validadortaxa.Validate(taxa);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }
    }
}
