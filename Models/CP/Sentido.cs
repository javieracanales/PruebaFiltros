using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Sentido
{
    public int IdSentido { get; set; }

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
