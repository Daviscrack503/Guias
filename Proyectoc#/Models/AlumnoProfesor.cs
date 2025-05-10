using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectoc_.Models
{
    public class AlumnoProfesor
    {

        public int Id { get; set; }
        public string Dui { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Edad { get; set; } = null!;
        public string Correo { get; set; } = null!;
           
    }
}
