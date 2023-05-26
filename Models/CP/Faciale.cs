using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Faciale
{
    public int IdFacial { get; set; }

    public string Codigo { get; set; } = null!;

    public int PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
