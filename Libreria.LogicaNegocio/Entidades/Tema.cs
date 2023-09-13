using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libreria.LogicaNegocio.Entidades
{
	/// <summary>
	/// Modela los temas sobre los que tratan las publicaciones de la librería.
	/// </summary>
	public class Tema : IEquatable<Tema>, IComparable<Tema>, IValidable<Tema>
	{
		#region Atributos
		public int Id { get; set; }
		[Required(ErrorMessage = "El nombre no puede ser vacío")]
		[MinLength(3,  ErrorMessage = "El nombre debe tener 3 caracteres como mínimo") ]

		public string Nombre { get; set; }
		[Required(ErrorMessage = "La descripción no puede ser vacía")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "El largo de la descripción varía entre 2 y 30")]
		[Display(Name = "Descripción del tema.")]
		public string Descripcion { get; set; }


        #endregion
        #region Propiedades de navegación

        public List<Autor> AutoresUsanTema { get; set; }
        #endregion

        #region Redefiniciones e implementaciones de interfaces del lenguaje
        public override string ToString()
		{
			//Si no conoce el operador ?? por favor haga una búsqueda por "operador null coalescing" de C# o
			//consulte: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/operators/null-coalescing-operator
			string nombre = this.Nombre ?? "Sin nombre";
			string descripcion = this.Descripcion ?? "Sin descripción";
			return $"Id: {this.Id} Nombre: {nombre} Descripción: {descripcion}";
		}
		//Para saber más sobre comparaciones de string consultar:https://learn.microsoft.com/es-es/dotnet/csharp/how-to/compare-strings
		public bool Equals(Tema? other)
		{
			if (other == null) return false;
			return other.Id == Id;
		}
		public int CompareTo(Tema? other)
		{
			if (other == null) return -1;
			return this.Nombre.Trim().CompareTo(other.Nombre.Trim());
		}

		#endregion

		#region Validaciones
		public void Validar()
		{
			if (string.IsNullOrEmpty(this.Nombre) || this.Nombre.Length < 3)
				throw new NombreTemaException("El nombre debe tener al menos 3 caracteres");
			if (string.IsNullOrEmpty(this.Descripcion))
				throw new DescripcionTemaException("La descripción no puede ser vacía");

		}
		#endregion
		#region Reglas de negocio típicas de los temas
		public bool NombreCoincidente(Tema otro)
		{
			if (otro == null) return false;
			return this.CompareTo(otro) == 0;
		}
        public bool NombreCoincidente(string name)
        {
             
            return this.Nombre.Equals(name,
				StringComparison.InvariantCultureIgnoreCase) ;
        }
        public bool Contiene(string texto)
		{
			if (string.IsNullOrEmpty(texto))
				return false;
			//Observar que se "parte" la sentencia en varias líneas para evitar el desplazamiento horizontal
			return this.Nombre.Contains(texto, StringComparison.InvariantCultureIgnoreCase)
				|| this.Descripcion.Contains(texto, StringComparison.InvariantCultureIgnoreCase);
		}
		public bool NombreContiene(string texto) { 
			if (string.IsNullOrEmpty(texto))
				return false ;

			return this.Nombre.Contains(texto,
				StringComparison.InvariantCultureIgnoreCase);
				 
	}
 
        #endregion
    }
}
