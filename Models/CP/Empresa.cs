using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public int Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public string Oficina { get; set; } = null!;

    public int? SociedadId { get; set; }

    public int TipoEmpresaId { get; set; }

    public virtual ICollection<Errore> Errores { get; set; } = new List<Errore>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual ICollection<PersonasEmpresa> PersonasEmpresas { get; set; } = new List<PersonasEmpresa>();

    public virtual Sociedade? Sociedad { get; set; }

    public virtual TiposEmpresa TipoEmpresa { get; set; } = null!;

    public virtual ICollection<TiposPersona> TiposPersonas { get; set; } = new List<TiposPersona>();

    public virtual ICollection<TiposUbicacione> TiposUbicaciones { get; set; } = new List<TiposUbicacione>();

    public virtual ICollection<TiposVisita> TiposVisita { get; set; } = new List<TiposVisita>();

    public virtual ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}
