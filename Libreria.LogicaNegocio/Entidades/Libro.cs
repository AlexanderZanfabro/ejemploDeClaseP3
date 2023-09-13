using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesEntidades;
 

namespace Libreria.LogicaNegocio.Entidades
{
	public class Libro : Publicacion, IValidable<Revista>
	{
		const int LargoIsbn= 12;
		public long ISBN{ get; set; }
        public string Titulo { get; set; }


        public void ValidarISBN(long isbn)
		{
			string isbnTexto = isbn.ToString();
			if (isbnTexto.Length == LargoIsbn)
				throw new PublicacionException("El largo del ISBN debe ser 12");
		}

		public void ValidarTitulo(string titulo)
		{
			if (string.IsNullOrEmpty(titulo))
				throw new PublicacionException("El título del libro es requerido");
		}

	}

}

