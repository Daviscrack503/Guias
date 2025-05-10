using System;
using System.Collections.Generic;

namespace Proyectoc_.Models;

public partial class Matricula
{
    public int Id { get; set; }

    public int Alumnoid { get; set; }

    public int Asignaturaid { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Asignatura Asignatura { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
