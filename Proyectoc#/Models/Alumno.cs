using System;
using System.Collections.Generic;

namespace Proyectoc_.Models;

public partial class Alumno
{
    public int Id { get; set; }

    public string Dui { get; set; } = null!;

    public string? Nombre { get; set; }

    public string Direccion { get; set; } = null!;

    public int Edad { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
