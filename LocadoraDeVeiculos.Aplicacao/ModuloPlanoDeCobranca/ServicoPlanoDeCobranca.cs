using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public ValidationResult Inserir(PlanoDeCobranca plano)
        {
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Inserir(plano);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca plano)
        {
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Editar(plano);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(plano);

            if (GrupoDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("Grupo", "Grupo duplicado"));

            return resultadoValidacao;
        }

        private bool GrupoDuplicado(PlanoDeCobranca plano)
        {
            var planoEncontrado = repositorioPlanoDeCobranca.SelecionarPlanoPorGrupo(plano.GrupoDeVeiculos.ID);

            return planoEncontrado != null &&
                   planoEncontrado.GrupoDeVeiculos.ID == plano.GrupoDeVeiculos.ID &&
                   planoEncontrado.ID != plano.ID;
        }
    }
}

