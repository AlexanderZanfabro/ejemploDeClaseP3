using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioTema:IRepositorio<Tema>
    {
        public IEnumerable<Tema> GetTemasFiltradosPorNombreDescripcion(string texto);
        public IEnumerable<Tema> GetTemasAlfabeticoXnombre();
        public Tema GetByName(string name);
        public IEnumerable<Tema> GetTemasFiltradosPorTextoNombre(string name);
    }
}
