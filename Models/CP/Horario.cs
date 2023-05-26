using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Horario
{
    public int IdHorario { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Lunes { get; set; }

    public bool Martes { get; set; }

    public bool Miercoles { get; set; }

    public bool Jueves { get; set; }

    public bool Viernes { get; set; }

    public bool Sabado { get; set; }

    public bool Domingo { get; set; }

    public int EmpresaId { get; set; }

    public string HoraIngreso { get; set; } = null!;

    public string HoraSalida { get; set; } = null!;

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();

    public virtual Empresa Empresa { get; set; } = null!;
}
