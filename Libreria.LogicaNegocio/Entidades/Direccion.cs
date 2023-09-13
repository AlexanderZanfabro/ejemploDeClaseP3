using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public string NumeroPuerta { get; set; }
    }
}
