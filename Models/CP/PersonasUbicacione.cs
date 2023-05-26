using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class PersonasUbicacione
{
    public int IdPersonaUbicacion { get; set; }

    public int UbicacionId { get; set; }

    public int PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Ubicacione Ubicacion { get; set; } = null!;
}
