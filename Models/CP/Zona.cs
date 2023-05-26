using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Zona
{
    public int IdZona { get; set; }

    public string Nombre { get; set; } = null!;

    public bool AntiPassBack { get; set; }

    public bool Estado { get; set; }

    public int EmpresaId { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    public virtual ICollection<Actore> Actores { get; set; } = new List<Actore>();

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Estacionamiento> Estacionamientos { get; set; } = new List<Estacionamiento>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();

    public virtual ICollection<Ubicacione> Ubicaciones { get; set; } = new List<Ubicacione>();
}
