using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectoc_.Models;
using Proyectoc_.Repository;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalifiacionController : ControllerBase
    {
        private CalificacionDao _cdao = new CalificacionDao();

        [HttpGet("calificacion")]
        public List<Calificacione> get(int idMatricula)
        {
            return _cdao.Seleccion(idMatricula);
        }

        [HttpPost("calificacion")]
        public bool insertar([FromBody] Calificacione Calificacion)
        {
            return _cdao.insertar(Calificacion);
        }
    


    [HttpDelete("calificacion")]

    public bool delete(int idCalificacion)
        {
            return _cdao.eliminarCalifcion(idCalificacion);
        }

       


    }
}
