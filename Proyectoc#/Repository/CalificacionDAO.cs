using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectoc_.Context;
using Proyectoc_.Models;

namespace Proyectoc_.Repository
{
    public class CalificacionDao
    {
        private RegistroAlumunoContext _context = new RegistroAlumunoContext();

        public List<Calificacione> Seleccion(int matriculaid, List<Calificacione> calificacion)
        {
            var matricula = _context.Matriculas.Where(x => x.Id == matriculaid).ToList();

            try
            {
                if (matricula != null)
                {
                    var calificaciones = _context.Calificaciones.Where(x => x.Matriculaid == matriculaid).ToList();

                    return calificaciones;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool insertar(Calificacione Calificacion)
        {
            try
            {
                if (Calificacion == null)
                {
                    return false;
                }

                _context.Calificaciones.Add(Calificacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
     
        
        
        }


        public bool eliminarCalifcion(int id)
        {
            var califiacion = _context.Calificaciones.Where(x => x.Id == id).FirstOrDefault();

            try
            {if (califiacion != null)
                {
                    _context.Calificaciones.Remove(califiacion);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Calificacion no encontrada");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;




            }

        }
    }
}
