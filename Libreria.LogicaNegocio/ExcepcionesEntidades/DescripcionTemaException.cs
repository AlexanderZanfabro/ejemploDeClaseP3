using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesEntidades
{
	public class DescripcionTemaException:TemaException
	{
		public DescripcionTemaException():base()	{	}
        public DescripcionTemaException(string mensaje):base(mensaje)  {}
		public DescripcionTemaException(string mensaje,Exception innerException) 
			: base(mensaje,innerException){}
	}
}
