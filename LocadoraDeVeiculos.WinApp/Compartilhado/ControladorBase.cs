using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public virtual void Editar() { }
        public abstract void Excluir();
        public abstract UserControl ObtemListagem();
        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();
    }
}