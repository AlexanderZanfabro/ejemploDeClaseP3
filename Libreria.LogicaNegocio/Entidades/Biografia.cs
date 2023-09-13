 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
 public class Biografia
    {
        [Key, ForeignKey(nameof(MiAutor))]
        public int AutorId { get; set; }
        public string LugarNacimiento { get; set; }
    
        public string EstadoCivil { get; set; }
        public string Descripcion { get; set; }

        public Autor MiAutor { get; set; }
    }
}
