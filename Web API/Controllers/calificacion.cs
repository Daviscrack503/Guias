using System.Linq.Expressions;

namespace Web_API.Controllers
{
    public class calificacion
    {
        [HttpGet("calificacion")]
        public bool insertar([FromBody] Calificacione Calificacion)
        {
            return _cdao.insertar(Calificacion);
        }


















    }
}