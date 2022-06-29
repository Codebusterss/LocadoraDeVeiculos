using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo
{
    public class ServicoGrupoDeVeiculo
    {
        private IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo;

        public ServicoGrupoDeVeiculo(IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
        }

        public ValidationResult Inserir(GrupoDeVeiculo grupoDeVeiculo)
        {
            var resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoDeVeiculo.Inserir(grupoDeVeiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculo grupoDeVeiculo)
        {
            var resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoDeVeiculo.Editar(grupoDeVeiculo);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculo grupoDeVeiculo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            var resultadoValidacao = validador.Validate(grupoDeVeiculo);

            if (NomeDuplicado(grupoDeVeiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoDeVeiculo grupoDeVeiculo)
        {
            var grupoEncontrado = repositorioGrupoDeVeiculo.SelecionarGrupoPorNome(grupoDeVeiculo.Nome);

            return grupoEncontrado != null &&
                   grupoEncontrado.Nome == grupoDeVeiculo.Nome &&
                   grupoEncontrado.ID != grupoDeVeiculo.ID;
        }

    }
}

