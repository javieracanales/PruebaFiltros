using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Asignacione
{
    public int IdAsignacion { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaTermino { get; set; }

    public int PersonaId { get; set; }

    public int HorarioId { get; set; }

    public virtual Horario Horario { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
