using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesEntidades
{
    public class NombreTemaException:TemaException
    {
		public NombreTemaException() : base() { }
		public NombreTemaException(string mensaje) : base(mensaje) { }
		public NombreTemaException(string mensaje, Exception innerException)
			: base(mensaje, innerException) { }
	}
}
