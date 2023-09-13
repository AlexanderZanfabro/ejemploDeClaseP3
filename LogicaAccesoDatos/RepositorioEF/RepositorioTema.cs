using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class RepositorioTema : IRepositorioTema
    {
        private Libreria2023Context _db = new Libreria2023Context();
        public void Add(Tema obj)
        {
            //TODO Cuando esté implementado el GetByName() verificar que no se repita el nombre.

            try
            {
                if (obj == null)
                    throw new TemaException("Necesitamos el objeto a dar de alta");
                obj.Validar();
                obj.Id = 0;
                _db.Temas.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new TemaException($"Error al dar de alta {ex.Message}", ex);
            }

        }

        public void Delete(Tema obj)
        {
            if (obj == null)
                throw new TemaException("El tema a eliminar no puede ser nulo.");
            try
            {
                _db.Temas.Attach(obj);
                _db.Temas.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TemaException(ex.Message, ex);
            }
        }

   

        public IEnumerable<Tema> FindAll()
        {
            return _db.Temas.
                Include(tem=>tem.AutoresUsanTema)
                .ThenInclude(autor=>autor.MiBiografia)
                .ToList();
        }

        public Tema FindById(int? id)
        {
            try
            {
                if (id == null)
                    throw new TemaException("El id no puede ser null");
                Tema t = _db.Temas.Find(id.Value);
                return t;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Tema obj)
        {
            if (obj==null)
                throw new TemaException("Debe proveer el tema con los datos modificados");
            obj.Validar();
            //TODO Cuando esté implementado el GetByName() verificar que no se repita el nombre.
            try
            {
                _db.Temas.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TemaException($"No se pudo modificar el tema. {ex.Message}", ex);
            }
  
        }

        public Tema GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tema> GetTemasAlfabeticoXnombre()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tema> GetTemasFiltradosPorNombreDescripcion(string texto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tema> GetTemasFiltradosPorTextoNombre(string name)
        {
            throw new NotImplementedException();
        }

 
    }
}
