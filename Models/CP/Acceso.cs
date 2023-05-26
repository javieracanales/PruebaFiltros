using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Acceso
{
    public int IdAcceso { get; set; }

    public bool Estado { get; set; }

    public int ZonaId { get; set; }

    public int PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Zona Zona { get; set; } = null!;
}
