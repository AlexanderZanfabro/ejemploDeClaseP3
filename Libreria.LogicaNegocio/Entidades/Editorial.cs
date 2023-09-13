using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesEntidades;
using System.Collections.Generic;

namespace Libreria.LogicaNegocio.Entidades
{
	public class Editorial : IValidable<Editorial>
	{
		public int Id{ get; set; }

		public string Nombre{ get; set; }

		public string Pais{ get; set; }

		 
		/// <see>LogicaNegocio.Entidades.IValidable<T>#Validar()</see>
		public void Validar()
		{
			if (Nombre == null || Pais == null) throw 
					new EditorialException("No es válida la editorial");
		}

	}

}

