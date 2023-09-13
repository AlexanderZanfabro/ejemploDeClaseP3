using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Libreria.LogicaNegocio.Entidades
{
    public abstract class Publicacion : IValidable<Publicacion>
    {
        #region Atributos
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal PrecioSugerido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

        public int CantidadPaginas { get; set; }

        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string ImagenPortada { get; set; }
        #endregion
        #region Propiedades de navegación
        public List<Autor> Autores { get; set; }
        public List<Autor> MisAutoresFans { get; set; }
        public Tema MiTema { get; set; }
        public Editorial MiEditorial { get; set; }
        #endregion

        #region Manejo de stock
        public void AumentarStock(int cantidad)
        {
            if (cantidad > 0)
                Stock += cantidad;
        }

        public void DeducirStock(int cantidad)
        {
            if (cantidad > 0)


                Stock -= cantidad;
        }
        public bool StockDebajoMinimo()
        {
            return Stock < StockMinimo;
        }
        #endregion
        #region Reseñas



        public void Resenhar(string texto, int puntaje)
        {
            //TODO IMPLEMENTAR LA RESEÑA
        }

        #endregion
        #region Manejo del precio
        public void AumentarPrecio(decimal tasa)
        {
            if (tasa < 0)
                throw new PublicacionException("No es posible aumentar el precio en un porcentaje negativo");

            PrecioSugerido = PrecioSugerido * (1 + tasa) / 100;

        }

        public void DisminuirPrecio(decimal tasa)
        {
            if (tasa < 0)
                throw new PublicacionException("No es posible disminuir el precio en un porcentaje negativo");

            PrecioSugerido = PrecioSugerido * (1 - tasa) / 100;
        }
        #endregion
        #region Validaciones



        /// <see>LogicaNegocio.Entidades.IValidable<T>#Validar()</see>
        public void Validar()
        {
            //if (!ValidarStock(this.Stock))
            //    throw new PublicacionException("El stock no puede ser negativo");
            //if (!ValidarStockMinimo(this.StockMinimo))
            //    throw new PublicacionException("El stock mínimo no puede ser negativo");
            if (!ValidarCantPaginas(this.CantidadPaginas))
                throw new PublicacionException("Debe tener al menos una página");
            //if (!ValidarImagen(this.ImagenPortada))
            //    throw new PublicacionException("Debe ingresar una imagen válida");
            if (!ValidarPrecio(this.PrecioSugerido))
                throw new PublicacionException("El precio debe ser positivo");

        }



        public bool ValidarCantPaginas(int cant)
        {
            return cant > 0;
        }

        public bool ValidarImagen(string imagen)
        {
            return !string.IsNullOrEmpty(imagen);
        }

        public bool ValidarPrecio(decimal precio)
        {
            return precio > 0;
        }
        public bool ValidarStock(int valorStock)
        {
            return valorStock > 0;
        }
        public bool ValidarStockMinimo(int valorStockMin)
        {
            return valorStockMin > 0;
        }
        public bool ValidarTema(Tema tema)
        {
            return tema != null;
        }
        public bool ValidarEditorial(Tema tema)
        {
            return tema != null;
        }
        #endregion
        #region Manejo de autores de la publicación

    }
    #endregion






}



