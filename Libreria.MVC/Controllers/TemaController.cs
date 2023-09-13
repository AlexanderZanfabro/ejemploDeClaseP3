using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Libreria.MVC.Models.Temas;
using Libreria.MVC.Models.MapeosModels;
using LogicaAccesoDatos.RepositorioEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria.MVC.Models;


namespace Libreria.MVC.Controllers
{
    public class TemaController : Controller
    {
        RepositorioTema _repoTemas = new RepositorioTema();


        // GET: TemaController
        /// <summary>
        /// Desplegar la lista de temas
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string? criterio, string? texto)
        {
            IEnumerable<Tema> _temas = _repoTemas.FindAll();
         

            if (string.IsNullOrEmpty(criterio))
            {
                ViewBag.Mensaje = "Para filtrar seleccione un criterio.";
                return View(_temas);

            }
            try
            {



                if (criterio == "textoNombre")

                    _temas = _repoTemas.GetTemasFiltradosPorTextoNombre(texto);

                else if (criterio == "textoNombreDescripcion")

                    _temas = _repoTemas.GetTemasFiltradosPorNombreDescripcion(texto);

                else if (criterio == "todos")

                    _temas = _repoTemas.FindAll();

                else if (criterio == "alfabetico")

                    _temas = _repoTemas.GetTemasAlfabeticoXnombre();
                if (_temas == null || _temas.Any() )
                    ViewBag.Mensaje = "No hay temas coincidentes.";

                return View(_temas);
            }
            catch (TemaException ex)
            {
                ViewBag.Mensaje = $"Error al filtrar los temas {ex.Message}";
                return View();
            }
            catch (Exception ex)
            {

                return View("Error", new ErrorViewModel { Mensaje = ex.Message });
            }

        }
        // GET: TemaController
        /// <summary>
        /// Desplegar la lista de temas utilizando el view model
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSinDesc()
        {
            IEnumerable<Tema> temas = _repoTemas.FindAll();
            List<TemaSinDescripcionModel> lista = new List<TemaSinDescripcionModel>();
            foreach (Tema tema in temas)
            {
                lista.Add(MapeoTemas.FromTema(tema));
            }
            return View(lista);
        }

        // GET: TemaController/Details/5
        /// <summary>
        /// Mostrar el Find by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string nombre)
        {
            try
            {
                Tema t = _repoTemas.GetByName(nombre);
                if (t == null)
                {
                    ViewBag.Mensaje = "No hay temas con ese nombre";
                    return View();
                }
                return View(t);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Se produjo una excepción {ex.Message}";

                return View();
            }


        }
        public ActionResult BuscarXId(int id)
        {
            try
            {
                Tema t = _repoTemas.FindById(id);
                if (t == null)
                {
                    ViewBag.Mensaje = "No hay temas con ese id";
                    return View();
                }
                return View(t);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Se produjo una excepción {ex.Message}";

                return View();
            }


        }
        // GET: TemaController/Create
        /// <summary>
        /// Desplegar el form de alta
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Implementar el alta
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: TemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tema nuevo)
        {
            try
            {
                _repoTemas.Add(nuevo);
                TempData["Mensaje"] = "Dado de alta";
                return RedirectToAction(nameof(Index));
            }
            catch (TemaException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;

                return View();
            }
        }

        // GET: TemaController/Edit/5
        /// <summary>
        /// Desplegar el form con el tema en modo edición
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("id nulo");
                Tema t = _repoTemas.FindById(id);
                return View(t);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();

            }
        }

        /// <summary>
        /// Guardar el tema modificado: update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: TemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tema temaModificado)
        {
            try
            {
                if (temaModificado == null)
                    throw new ArgumentNullException("El tema es nulo");
                _repoTemas.Update(temaModificado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(temaModificado);
            }
        }

        // GET: TemaController/Delete/5
        // GET: TemaController/Edit/5
        /// <summary>
        /// Desplegar el form con el tema para confirmar borrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("id nulo");
                Tema t = _repoTemas.FindById(id);
                return View(t);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();

            }
        }
        /// <summary>
        /// Borrar el tema después de la confirmaci´n
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: TemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tema t)
        {
            try
            {
                if (t == null)
                    throw new ArgumentNullException("El tema no puede ser nulo");
                //Para el caso (improbable) en que el tema no venga con Id
                if (t.Id == 0 && id!=0)
                    t.Id = id;
                _repoTemas.Delete(t);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();

            }
        }
    }
}
