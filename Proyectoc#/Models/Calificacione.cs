using System;
using System.Collections.Generic;

namespace Proyectoc_.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public float Nota { get; set; }

    public int Procentaje { get; set; }

    public int Matriculaid { get; set; }

    public virtual Matricula? Matricula { get; set; } = null!;
}
