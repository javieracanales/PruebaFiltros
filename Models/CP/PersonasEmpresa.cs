using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class PersonasEmpresa
{
    public int IdPersonaEmpresa { get; set; }

    public int EmpresaId { get; set; }

    public int PersonaId { get; set; }

    public bool Estado { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
