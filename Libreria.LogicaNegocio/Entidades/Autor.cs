using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    /// <summary>
    /// Modela el autor de las publicaciones de la librería.
    /// </summary>
 
    public  class Autor
    {
         #region Atributos
        public int Id { get; set; }
        //Por ahora ignoramos la advertencia de los strings nullables
        [StringLength(10)] public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        //Si un autor está vivo necesitamos que su fecha de defunción sea null
        //Por esa razón lo hacemos nullable.
        //La fecha de nacimiento no debería ser null, pero eso se controla en la validación

        public DateTime? FechaDefuncion { get; set; } = null;

        #region Propiedades de navegación

        #endregion

        #endregion
        #region Validaciones
        /// <summary>
        /// Valida que las properties que se setearon en el autor contengan valores válidos
        /// En caso de que alguna de las propiedades fuera inválida, el primer método de validación 
        /// invocado que detecte la anomalía lanzará la excepción.
        /// La excepción no se captura en este método, por lo que subirá en el stack
        /// hasta llegar al primer método que la controle, o hasta el CLR.
        /// </summary>
        public void Validar()
        {
            ValidarFechaNacimiento(this.FechaNacimiento);
            ValidarFechaDefuncion(this.FechaDefuncion);
            ValidarNombre(this.Nombre);
        }

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
                throw new InvalidOperationException("El nombre no puede estar vacío"); ;
        }

        public void ValidarFechaNacimiento(DateTime? fecha)
        {
            if (fecha == null || fecha <= new DateTime(868, 5, 11))
                throw new InvalidOperationException("Fecha de nacimiento no puede ser menor a la fecha 11/5/868");

        }
        public void ValidarFechaDefuncion(DateTime? fechaDefuncion)
        {
            if (FechaNacimiento == null)

                throw new InvalidOperationException("La fecha de nacimiento es null, verifique");

            //La fecha de defunción puede ser nula, pero no puede ser anterior a la de nacimiento

            if (fechaDefuncion != null && fechaDefuncion < FechaNacimiento)
                throw new InvalidOperationException("La fecha de defunción no puede ser menor a la fecha de nacimiento ");



        }
        #endregion
        #region Overrides de Object
        public override string ToString()
        {
            return $"{this.Nombre} {this.FechaNacimiento} {this.FechaDefuncion}";
        }
        #endregion
        #region Propiedades de navegación
        public Biografia MiBiografia { get; set; }
        public Direccion    MiDireccion{ get; set; }
        public List<Telefono> MisTelefonos { get; set; }
       [InverseProperty("Autores")]
        public List<Publicacion> MisPublicaciones { get; set; }
        [InverseProperty("MisAutoresFans")]
        public List<Publicacion> MisPublicacionesFavoritas { get; set; }
        public List<Tema> TemasAbordados { get; set; }
        #endregion
    }
}
