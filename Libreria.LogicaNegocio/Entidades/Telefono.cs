using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(AutorId),nameof(CodigoArea),nameof(Numero))]
    public class Telefono
    {
        public int AutorId { get; set; }
        public int CodigoArea { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
    
    }
}
