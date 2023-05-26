using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposPersona
{
    public int IdTipoPersona { get; set; }

    public string Tipo { get; set; } = null!;

    public int EmpresaId { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
