using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosMemoria
{
    public class RepositorioTema : IRepositorioTema
    {

        private static readonly RepositorioTema _instancia = new RepositorioTema();

        private RepositorioTema(){}
        public static RepositorioTema Instancia { 
            get { 

                return _instancia; 
            }
        }
        private List<Tema> _temas=new List<Tema>();
        public void Add(Tema obj)
        {
           if (obj==null) throw new TemaException("Necesito tema");
            obj.Validar();
            if (GetByName(obj.Nombre) != null)
                throw new TemaException($"No se puede dar de alta un tema duplicado. Nombre {obj.Nombre}");
           _temas.Add(obj);
        }

        public void Delete(Tema obj)
        {
            if (obj == null) 
                throw new TemaException("Es necesario indicar el tema a eliminar");
            _temas.Remove(obj);

        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new TemaException("Es necesario indicar el Id del tema a eliminar");
            Tema t = FindById(id);
            if (t == null)
                throw new TemaException("No existe un tema con ese id");
            _temas.Remove(t);
        }

        public IEnumerable<Tema> FindAll()
        {
            return _temas;
        }

        public Tema FindById(int? id)
        {
            int i=0;
            while (i<_temas.Count && _temas[i].Id != id)
            {
                i++;
            }
            if (i < _temas.Count)
                return _temas[i];
            return null;
        }

        public IEnumerable<Tema> GetTemasAlfabeticoXnombre()
        {
            //En este caso no importa, pero si interesara mantener el orden 
            //original habría que clonar la lista antes de ordenarla
            _temas.Sort();
            return _temas;
        }

        public IEnumerable<Tema> GetTemasFiltradosPorNombreDescripcion(string texto)
        {
            List<Tema> temasFiltrados = new List<Tema>();
            foreach (Tema t in _temas)
                if (t.Contiene(texto))
                    temasFiltrados.Add(t);
            return temasFiltrados;
        }

        public void Update(Tema obj)
        {
            if (obj == null)
                throw new TemaException("Es necesario indicar el tema a modificar");
            
            obj.Validar();
            if (GetByName(obj.Nombre) != null)
                throw new TemaException($"No se puede dar de alta un tema duplicado. Nombre {obj.Nombre}");

            Tema original = FindById(obj.Id);
            if (original == null)
                throw new TemaException("No existe un tema con ese Id");
            //TODO Sería conveniente tener un método en Tema que modifique sus datos a partir de los de otra instancia
            original.Nombre = obj.Nombre;
            original.Descripcion = obj.Descripcion;
        }

        public void Update(int id, Tema obj)
        {
            //Se puede reusar el otro método update siempre y cuando coincidan los ids
            if (obj != null && id==obj.Id)
                Update(obj);

        }

        public Tema GetByName(string name)
        {
            int i = 0;

            while (i < _temas.Count && !_temas[i].NombreCoincidente(name))
            {
                i++;
            }
            if (i < _temas.Count)
                return _temas[i];
            return null;
        }

        public IEnumerable<Tema> GetTemasFiltradosPorTextoNombre(string texto)
        {
            List<Tema> temasFiltrados = new List<Tema>();
            foreach (Tema t in _temas)
                if (t.NombreContiene(texto))
                    temasFiltrados.Add(t);
            return temasFiltrados;
        }
    }
}
