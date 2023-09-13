using Libreria.LogicaNegocio.Entidades;
using Libreria.MVC.Models.Temas;

namespace Libreria.MVC.Models.MapeosModels
{
    public class MapeoTemas
    {
        public static TemaSinDescripcionModel FromTema (Tema t)
        {
            if (t == null)
                throw new ArgumentNullException("Falta el tema");
            TemaSinDescripcionModel temaModel = new TemaSinDescripcionModel()
            {
                Id = t.Id,
                Nombre = t.Nombre.ToUpper()
            };
            return temaModel;
        }
        /// <summary>
        /// En este caso, es improbable que me sirva para algo, porque sería para dar altas pero le faltan datos.
        /// Para las altas / modificaciones necesitaría otro Model o directo usar el objeto de dominio
        /// </summary>
        /// <param name="tModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Tema ToTema(TemaSinDescripcionModel tModel)
        {
            if (tModel == null)
                throw new ArgumentNullException("Falta el tema model");
            Tema tema = new Tema()
            {
                Id =tModel.Id,
                Nombre = tModel.Nombre 
            };
            return tema;
        }
    }
}
