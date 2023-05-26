using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposUbicacione
{
    public int IdTipoUbicacion { get; set; }

    public string Tipo { get; set; } = null!;

    public int EmpresaId { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Ubicacione> Ubicaciones { get; set; } = new List<Ubicacione>();
}
