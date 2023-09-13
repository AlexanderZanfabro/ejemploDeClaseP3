using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class Libreria2023Context : DbContext
    {
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Revista> Revistas { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
            string cadenaConexion = @"SERVER=(LocalDb)\MsSqlLocalDb;DATABASE=LibreriaM3AAgosto2023V11;INTEGRATED SECURITY=TRUE;ENCRYPT=FALSE";
            optionsBuilder.UseSqlServer(cadenaConexion);
        }
    }
}
