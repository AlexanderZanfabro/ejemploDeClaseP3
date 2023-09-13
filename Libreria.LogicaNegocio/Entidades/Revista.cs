using Libreria.LogicaNegocio.InterfacesEntidades;
using Libreria.LogicaNegocio.ExcepcionesEntidades;

namespace Libreria.LogicaNegocio.Entidades
{
	public class Revista : Publicacion, IValidable<Revista>
	{
		public string Nombre{ get; set; }

		public int Numero{ get; set; }

		public int Anho{ get; set; }

		public string TablaContenido{ get; set; }

		public void ValidarNombre(string nom)
		{

		}

	}

}

