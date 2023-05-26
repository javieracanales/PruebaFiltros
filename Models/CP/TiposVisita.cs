using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposVisita
{
    public int IdTipoVisita { get; set; }

    public string Tipo { get; set; } = null!;

    public int EmpresaId { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
