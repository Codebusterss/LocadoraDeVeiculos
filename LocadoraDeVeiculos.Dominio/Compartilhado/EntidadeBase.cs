using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taikandi;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid ID { get; set; }

        public abstract void Atualizar(T registro);

        public EntidadeBase()
        {
            ID = SequentialGuid.NewGuid();
        }
    }
}