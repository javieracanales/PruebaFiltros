using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Visita
{
    public int IdVisita { get; set; }

    public DateTime FechaVisita { get; set; }

    public bool Estado { get; set; }

    public int PersonaId { get; set; }

    public int CreadorId { get; set; }

    public int TipoVisitaId { get; set; }

    public int UbicacionId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual TiposVisita TipoVisita { get; set; } = null!;

    public virtual Ubicacione Ubicacion { get; set; } = null!;
}
