﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorioBase<Taxa>
    {
        Taxa SelecionarTaxaPorDescricao(string descricacao);
    }
}