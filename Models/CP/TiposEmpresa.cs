using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposEmpresa
{
    public int IdTipoEmpresa { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
