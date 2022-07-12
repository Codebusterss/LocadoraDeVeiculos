using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog; 
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

            Log.Logger.Debug("Tentando inserir Grupo de veículo... {@g}", grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoDeVeiculo.Inserir(grupoDeVeiculo);
                Log.Logger.Debug("Grupo de veículo {GrupoNome} inserido com sucesso.", grupoDeVeiculo.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Grupo de veículo {GrupoNome} - {Motivo}.", grupoDeVeiculo.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculo grupoDeVeiculo)
        {
            var resultadoValidacao = Validar(grupoDeVeiculo);

            Log.Logger.Debug("Tentando editar Grupo de veículo... {@g}", grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoDeVeiculo.Editar(grupoDeVeiculo);
                Log.Logger.Debug("Grupo de veículo {GrupoNome} editado com sucesso.", grupoDeVeiculo.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Grupo de veículo {GrupoNome} - {Motivo}.", grupoDeVeiculo.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculo grupoDeVeiculo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            Log.Logger.Debug("Validando Grupo de veiculos... {@g}", grupoDeVeiculo);

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

