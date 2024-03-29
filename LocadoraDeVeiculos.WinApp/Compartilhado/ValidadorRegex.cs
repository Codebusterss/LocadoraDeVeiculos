﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public class ValidadorRegex
    {
        public bool ApenasNumerosInteirosOuDecimais(string numero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(numero, @"^[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)$");

            return estaValido;
        }
        public bool ApenasNumerosInteiros(string numero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(numero, @"(^[0-9])");

            return estaValido;
        }

        public bool ApenasLetra(string letra)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(letra, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$");

            return estaValido;
        }
    }
}
