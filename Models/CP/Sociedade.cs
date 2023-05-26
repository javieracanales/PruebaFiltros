using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Sociedade
{
    public int IdSociedad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
