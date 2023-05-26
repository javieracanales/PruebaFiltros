using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Rut { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public bool Estado { get; set; }

    public int? TipoPersonaId { get; set; }

    public bool AppMovil { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    public virtual ICollection<Faciale> Faciales { get; set; } = new List<Faciale>();

    public virtual ICollection<Huella> Huellas { get; set; } = new List<Huella>();

    public virtual ICollection<ListasNegra> ListasNegras { get; set; } = new List<ListasNegra>();

    public virtual ICollection<Pase> Pases { get; set; } = new List<Pase>();

    public virtual ICollection<Patente> Patentes { get; set; } = new List<Patente>();

    public virtual ICollection<PersonasEmpresa> PersonasEmpresas { get; set; } = new List<PersonasEmpresa>();

    public virtual ICollection<PersonasEstacionamiento> PersonasEstacionamientos { get; set; } = new List<PersonasEstacionamiento>();

    public virtual ICollection<PersonasUbicacione> PersonasUbicaciones { get; set; } = new List<PersonasUbicacione>();

    public virtual ICollection<PinPass> PinPasses { get; set; } = new List<PinPass>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();

    public virtual TiposPersona? TipoPersona { get; set; }

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
