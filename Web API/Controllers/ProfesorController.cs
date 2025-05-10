using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectoc_.Models;
using Proyectoc_.Repository;

namespace Web_API.Controllers
{

    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDao _proDao = new ProfesorDao();

        [HttpPost("Autenticacion")]

        public string loginProfesor([FromBody] Profesor prof)
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass);
            if (prof1 != null)
            {
                return prof1.Usuario;
            }
            return "Elemento no encontrado";
            

        }
    }
}
