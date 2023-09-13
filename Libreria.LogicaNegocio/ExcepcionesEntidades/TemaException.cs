using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesEntidades
{
    public  class TemaException:Exception
    {
        public TemaException() : base() { }
        public TemaException(string mensaje) : base(mensaje) { }
        public TemaException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
