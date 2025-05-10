using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectoc_.Context;
using Proyectoc_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Windows.Markup;
using System.Linq.Expressions;


namespace Proyectoc_.Repository
{
    public class AlumnoDAO
    {
        public RegistroAlumunoContext contex = new RegistroAlumunoContext();

        public List<Alumno> SelectAll()
        {
            var Alumno = contex.Alumnos.ToList<Alumno>();
            return Alumno;
        }

        public Alumno? GetId(int id)
        {
            var Alumno = contex.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return Alumno == null ? null : Alumno;
        }

        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Dui = alumno.Dui,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Nombre = alumno.Nombre
                };

                contex.Alumnos.Add(alum);
                contex.SaveChanges();

                return true;

            }
            catch (Exception e)
            {

                return false;
            }

        }

        public bool update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetId(id);
                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dui = actualizar.Dui;
                alumnoUpdate.Edad = actualizar.Edad;
                alumnoUpdate.Email = actualizar.Email;
                alumnoUpdate.Nombre = actualizar.Nombre;

                contex.Update(alumnoUpdate);
                contex.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return false;
        }

        public bool deleteAllumno(int id)
        {
            var borrar = GetId(id);
            try
            {
                if (borrar == null)
                {
                    return false;
                }
                else
                {
                    contex.Alumnos.Remove(borrar);
                    contex.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public List<AlumnoAsigantura> SelectAlumASig()
        {
            var consulta = from a in contex.Alumnos
                           join m in contex.Matriculas on a.Id equals m.Alumnoid
                           join asig in contex.Asignaturas on m.Asignaturaid equals asig.Id
                           select new AlumnoAsigantura
                           {
                               nombreAlunmo = a.Nombre,
                               nombreAsignatura = asig.Nombre
                           }; 
                           return consulta.ToList();





        } 


        public List<AlumnoProfesor> alumnoProfesors(string nombreProfesor)
        {
            var listadoAlumno = from a in contex.Alumnos
                                join m in contex.Matriculas on a.Id equals m.Alumnoid
                                join asig in contex.Asignaturas on m.Asignaturaid equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Dui = a.Dui,
                                    Nombre = a.Nombre,
                                    Apellido = a.Direccion,
                                    Telefono = a.Email,
                                    Edad = a.Edad.ToString(),
                                    Correo = a.Email
                                };
            return listadoAlumno.ToList();



        }


        public Alumno? GetById(int Id)
        {
            var alumno = contex.Alumnos.Where(x => x.Id == Id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }

        public Alumno DuiAlumno(Alumno alumno)
        {
            var alumnos = contex.Alumnos.Where(x => x.Dui == alumno.Dui).FirstOrDefault();
            return alumnos == null ? null : alumnos;
        }

        public bool InsertarMatricula(Alumno alumno, int idAsignatura)
        {
            try
            {
                var alumnoDui = DuiAlumno(alumno);
                if (alumnoDui == null)
                {
                    insertarAlumno(alumno);

                    var unirAlumnoMatricula = matriculaAsignaturaAlumno(alumno, idAsignatura);
                    if (unirAlumnoMatricula == false)
                    {
                        return false;
                    }


                    return true;


                }

                else
                {
                    matriculaAsignaturaAlumno(alumnoDui, idAsignatura);
                    return true;
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    public bool matriculaAsignaturaAlumno(Alumno alumno, int idAsignatura)
        {
            try
            {
                Matricula matricula = new Matricula();
                
                    matricula.Alumnoid = alumno.Id;
                    matricula.Asignaturaid = idAsignatura;

                
                contex.Matriculas.Add(matricula);
                contex.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    

public bool EliminarAlumno(int id)
        {
            try
            {
                var alumno = contex.Alumnos.Where(x => x.Id == id).FirstOrDefault();

                if (alumno != null)
                {
                    var matriculaA = contex.Matriculas.Where(x => x.Alumnoid == id);
                    foreach (Matricula m in matriculaA)
                    {
                        var calificacion = contex.Calificaciones.Where(x => x.Matriculaid == m.Id);

                        contex.Calificaciones.RemoveRange(calificacion);
                    }

                    contex.Matriculas.RemoveRange(matriculaA);
                    contex.Alumnos.Remove(alumno);
                    contex.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Alumno no encontrado");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }














}
    }




























