using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectoc_.Models;
using Proyectoc_.Repository;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO _dao = new AlumnoDAO();

        [HttpGet("AlumnoProfesor")]
        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }

        [HttpGet("alumno")]
        public Alumno seletById(int Id)
        {
            var alumno = _dao.GetById(Id);
            return alumno;
      
        
       
        }

        [HttpPut("alumno")]
        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            
            return _dao.update(alumno.Id, alumno);
        }
    


    [HttpPost("alumno")]

    public bool insertarMatricula([FromBody] Alumno alumno, int idAsignatura)

        {
            return _dao.InsertarMatricula(alumno, idAsignatura);
        }

   
    
    
    

    [HttpDelete("alumno")]

    public bool EliminarAlumno(int id)
        {
            return _dao.EliminarAlumno(id);
        }






    }
}
