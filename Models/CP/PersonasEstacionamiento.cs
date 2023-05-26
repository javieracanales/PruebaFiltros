using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class PersonasEstacionamiento
{
    public int IdPersonaEstacionamiento { get; set; }

    public int EstacionamientoId { get; set; }

    public int PersonaId { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Estacionamiento Estacionamiento { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
