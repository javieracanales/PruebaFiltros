using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PruebaFiltros.Models;
using PruebaFiltros.Models.CP;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace PruebaFiltros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Dbcp2Context _context;
        public HomeController(ILogger<HomeController> logger, Dbcp2Context context)
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult RellenoZona(string zona)
        //{
        //    var lstDdl = (from r in _context.Registros
        //                  select new SelectListItem
        //                  {
        //                      Value = r.Zona.Nombre.ToString(),
        //                      Text = r.Zona.Nombre.ToString()
        //                  }).ToList();

        //    return View();
        //}

        public IActionResult Index(string Busqueda,string zona, bool entrada, bool salida)
        {
            
            var LstEmp = from r in _context.Registros join
                         z in _context.Zonas on r.ZonaId equals z.IdZona join
                         e in _context.Empresas on z.EmpresaId equals e.IdEmpresa join
                         s in _context.Sentidos on r.SentidoId equals s.IdSentido join
                         p in _context.Patentes on r.PatenteId equals p.IdPatente join
                         pe in _context.Personas on r.PersonaId equals pe.IdPersona join
                         ta in _context.TiposActores on r.TipoActorId equals ta.IdTipoActor join
                         u in _context.Ubicaciones on r.UbicacionId equals u.IdUbicacion 

                         select new Registro()
                         {
                             IdRegistro=r.IdRegistro,
                             Fecha=r.Fecha,
                             Zona= z,
                             Sentido= s,
                             Patente=p,
                             Persona=pe,
                             TipoActor=ta,
                             Ubicacion=u,
                         };

            List<Zona> lst = (from z in _context.Zonas
                                select new Zona
                                {
                                    IdZona= z.IdZona,
                                    Nombre=z.Nombre
                                }).ToList();

            List<SelectListItem> LstICombo = lst.ConvertAll(z =>
            {
                return new SelectListItem()
                {
                    Text = z.Nombre.ToString(),
                    Value = z.IdZona.ToString(),
                    Selected = false
                };
            });

            ViewBag.LstICombo = LstICombo;


            if (!string.IsNullOrEmpty(Busqueda))
            {
                var ent = from r in _context.Registros
                          join
                         s in _context.Sentidos on r.SentidoId equals s.IdSentido
                          where r.Sentido.IdSentido == 1
                          select r;
                LstEmp = LstEmp.Where(r => r.Zona.Empresa.Nombre.Contains(Busqueda) ||
                r.Fecha.ToString().Contains(Busqueda) || r.Sentido.Direccion.Contains(entrada.ToString())||
                 r.Sentido.Direccion.Contains(salida.ToString())|| r.Zona.Nombre.Contains(zona));
                return View(LstEmp);
            }
            return View(LstEmp.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        //Registros: Filtro fecha

        [HttpPost]
        public async Task<FileResult?> ExportarRegistros(string fecha)
        {
            if (!string.IsNullOrEmpty(fecha))
            {
                List<Registro> LstRegistroFiltro = await _context.Registros.Where(r => r.Fecha.ToString()==fecha).ToListAsync();
                var DatosFiltro = ToExcel(LstRegistroFiltro);
                return File(DatosFiltro, "application/vnd.ms-excel", "Registros por fecha requerida, Fecha de descarga: " + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xlsx");
            }
            return null;

        }

        public Byte[] ToExcel(List<Registro> LstRegistros)
        {
            byte[] buffer = DatosAExcel(LstRegistros);

            return buffer;

        }

        public byte[] DatosAExcel(List<Registro> LstRegistros)
        {

            using MemoryStream guardar = new();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using ExcelPackage excel = new();
            var HojaExcel = excel.Workbook.Worksheets.Add("Personas");
            HojaExcel.Column(1).Width = 10.00;
            HojaExcel.Column(2).Width = 25.00;
            HojaExcel.Column(3).Width = 25.00;
            HojaExcel.Column(4).Width = 25.00;
            HojaExcel.Column(5).Width = 10.00;
            HojaExcel.Column(6).Width = 25.00;
            HojaExcel.Column(7).Width = 25.00;


            HojaExcel.Column(1).Style.WrapText = true;
            HojaExcel.Column(2).Style.WrapText = true;
            HojaExcel.Column(3).Style.WrapText = true;
            HojaExcel.Column(4).Style.WrapText = true;
            HojaExcel.Column(5).Style.WrapText = true;
            HojaExcel.Column(6).Style.WrapText = true;
            HojaExcel.Column(7).Style.WrapText = true;


            Color Blanco = Color.White;
            HojaExcel.Cells["A1:G1"].Style.Font.Color.SetColor(Blanco);
            HojaExcel.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            HojaExcel.Cells["A1"].Value = "FECHA";
            HojaExcel.Cells["B1"].Value = "ZONA";
            HojaExcel.Cells["C1"].Value = "SENTIDO";
            HojaExcel.Cells["D1"].Value = "PATENTE";
            HojaExcel.Cells["E1"].Value = "PERSONA";
            HojaExcel.Cells["F1"].Value = "TIPO DE ACTOR";
            HojaExcel.Cells["G1"].Value = "UBICACION";

            int i = 2;

            foreach (var item in LstRegistros)
            {
                HojaExcel.Cells["A" + i.ToString()].Value = item.Fecha;
                HojaExcel.Cells["B" + i.ToString()].Value = item.ZonaId;
                HojaExcel.Cells["C" + i.ToString()].Value = item.SentidoId;
                HojaExcel.Cells["D" + i.ToString()].Value = item.PatenteId;
                HojaExcel.Cells["E" + i.ToString()].Value = item.PersonaId;
                HojaExcel.Cells["F" + i.ToString()].Value = item.TipoActorId;
                HojaExcel.Cells["G" + i.ToString()].Value = item.UbicacionId;

                i++;
            }

            excel.SaveAs(guardar);
            Byte[] buffer = guardar.ToArray();
            return buffer;
        }

        //Registros con tipo Actor
        [HttpPost]
        public async Task<FileResult?> ExportarRegistrosActor(string actor)
        {
            if (!string.IsNullOrEmpty(actor))
            {
                List<Registro> LstRegistroFiltro = await _context.Registros.Include(r=>r.Zona).Include(r=>r.Sentido).
                    Include(r=>r.Patente).Include(r=>r.Persona).Include(r=>r.TipoActor).Include(r=>r.Ubicacion)
                    .Where(r => r.TipoActor.Tipo == actor).ToListAsync();
                var DatosFiltro = ToExcelActor(LstRegistroFiltro);
                return File(DatosFiltro, "application/vnd.ms-excel", "Registros por fecha requerida, Fecha de descarga: " + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xlsx");
            }
            return null;
        }
        public Byte[] ToExcelActor(List<Registro> LstRegistrosActor)
        {
            byte[] buffer = DatosAExcelActor(LstRegistrosActor);

            return buffer;

        }
        public byte[] DatosAExcelActor(List<Registro> LstRegistrosActor)
        {

            using MemoryStream guardar = new();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using ExcelPackage excel = new();
            var HojaExcel = excel.Workbook.Worksheets.Add("Personas");
            HojaExcel.Column(1).Width = 10.00;
            HojaExcel.Column(2).Width = 25.00;
            HojaExcel.Column(3).Width = 25.00;
            HojaExcel.Column(4).Width = 25.00;
            HojaExcel.Column(5).Width = 10.00;
            HojaExcel.Column(6).Width = 25.00;
            HojaExcel.Column(7).Width = 25.00;


            HojaExcel.Column(1).Style.WrapText = true;
            HojaExcel.Column(2).Style.WrapText = true;
            HojaExcel.Column(3).Style.WrapText = true;
            HojaExcel.Column(4).Style.WrapText = true;
            HojaExcel.Column(5).Style.WrapText = true;
            HojaExcel.Column(6).Style.WrapText = true;
            HojaExcel.Column(7).Style.WrapText = true;


            Color Blanco = Color.White;
            HojaExcel.Cells["A1:G1"].Style.Font.Color.SetColor(Blanco);
            HojaExcel.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            HojaExcel.Cells["A1"].Value = "FECHA";
            HojaExcel.Cells["B1"].Value = "ZONA";
            HojaExcel.Cells["C1"].Value = "SENTIDO";
            HojaExcel.Cells["D1"].Value = "PATENTE";
            HojaExcel.Cells["E1"].Value = "PERSONA";
            HojaExcel.Cells["F1"].Value = "TIPO DE ACTOR";
            HojaExcel.Cells["G1"].Value = "UBICACION";

            int i = 2;

            foreach (var item in LstRegistrosActor)
            {
                HojaExcel.Cells["A" + i.ToString()].Value = item.Fecha;
                HojaExcel.Cells["B" + i.ToString()].Value = item.Zona.Nombre;
                HojaExcel.Cells["C" + i.ToString()].Value = item.Sentido.Direccion;
                HojaExcel.Cells["D" + i.ToString()].Value = item.Patente.PatenteDigitos;
                HojaExcel.Cells["E" + i.ToString()].Value = item.Persona.Nombres;
                HojaExcel.Cells["F" + i.ToString()].Value = item.TipoActor.Tipo;
                HojaExcel.Cells["G" + i.ToString()].Value = item.Ubicacion.Nombre;

                i++;
            }

            excel.SaveAs(guardar);
            Byte[] buffer = guardar.ToArray();
            return buffer;
        }


        //Registros: Filtro zonas

        [HttpPost]
        public async Task<FileResult?> ExportarZonas(string zona)
        {
            if (!string.IsNullOrEmpty(zona))
            {
                List<Registro> LstRegistroFiltro = await _context.Registros.Where(r => r.ZonaId.ToString() == zona).ToListAsync();
                var DatosFiltro = ToExcelZonas(LstRegistroFiltro);
                return File(DatosFiltro, "application/vnd.ms-excel", "Registros por fecha requerida, Fecha de descarga: " + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xlsx");
            }
            return null;

        }

        public Byte[] ToExcelZonas(List<Registro> LstRegistrosZona)
        {
            byte[] buffer = DatosAExcelZonas(LstRegistrosZona);

            return buffer;

        }

        public byte[] DatosAExcelZonas(List<Registro> LstRegistrosZona)
        {

            using MemoryStream guardar = new();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using ExcelPackage excel = new();
            var HojaExcel = excel.Workbook.Worksheets.Add("Personas");
            HojaExcel.Column(1).Width = 10.00;
            HojaExcel.Column(2).Width = 25.00;
            HojaExcel.Column(3).Width = 25.00;
            HojaExcel.Column(4).Width = 25.00;
            HojaExcel.Column(5).Width = 10.00;
            HojaExcel.Column(6).Width = 25.00;
            HojaExcel.Column(7).Width = 25.00;


            HojaExcel.Column(1).Style.WrapText = true;
            HojaExcel.Column(2).Style.WrapText = true;
            HojaExcel.Column(3).Style.WrapText = true;
            HojaExcel.Column(4).Style.WrapText = true;
            HojaExcel.Column(5).Style.WrapText = true;
            HojaExcel.Column(6).Style.WrapText = true;
            HojaExcel.Column(7).Style.WrapText = true;


            Color Blanco = Color.White;
            HojaExcel.Cells["A1:G1"].Style.Font.Color.SetColor(Blanco);
            HojaExcel.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            HojaExcel.Cells["A1"].Value = "FECHA";
            HojaExcel.Cells["B1"].Value = "ZONA";
            HojaExcel.Cells["C1"].Value = "SENTIDO";
            HojaExcel.Cells["D1"].Value = "PATENTE";
            HojaExcel.Cells["E1"].Value = "PERSONA";
            HojaExcel.Cells["F1"].Value = "TIPO DE ACTOR";
            HojaExcel.Cells["G1"].Value = "UBICACION";

            int i = 2;

            foreach (var item in LstRegistrosZona)
            {
                HojaExcel.Cells["A" + i.ToString()].Value = item.Fecha;
                HojaExcel.Cells["B" + i.ToString()].Value = item.ZonaId;
                HojaExcel.Cells["C" + i.ToString()].Value = item.SentidoId;
                HojaExcel.Cells["D" + i.ToString()].Value = item.PatenteId;
                HojaExcel.Cells["E" + i.ToString()].Value = item.PersonaId;
                HojaExcel.Cells["F" + i.ToString()].Value = item.TipoActorId;
                HojaExcel.Cells["G" + i.ToString()].Value = item.UbicacionId;

                i++;
            }

            excel.SaveAs(guardar);
            Byte[] buffer = guardar.ToArray();
            return buffer;
        }


        //filtro empresas

        [HttpPost]
        public async Task<FileResult?> ExportarRegistrosEmpresa(string empresa)
        {
            if (!string.IsNullOrEmpty(empresa))
            {
                List<Registro> LstRegistroFiltro = await (from r in _context.Registros
                                                          join
                          z in _context.Zonas on r.ZonaId equals z.IdZona
                                                          join
                          e in _context.Empresas on z.EmpresaId equals e.IdEmpresa
                                                          join
                          s in _context.Sentidos on r.SentidoId equals s.IdSentido
                                                          join
                          p in _context.Patentes on r.PatenteId equals p.IdPatente
                                                          join
                          pe in _context.Personas on r.PersonaId equals pe.IdPersona
                                                          join
                          ta in _context.TiposActores on r.TipoActorId equals ta.IdTipoActor
                                                          join
                          u in _context.Ubicaciones on r.UbicacionId equals u.IdUbicacion
                                                          where r.Zona.Empresa.Nombre == empresa
                                                          select new Registro()
                                                          {
                                                              IdRegistro = r.IdRegistro,
                                                              Fecha = r.Fecha,
                                                              Zona = z,
                                                              Sentido = s,
                                                              Patente = p,
                                                              Persona = pe,
                                                              TipoActor = ta,
                                                              Ubicacion = u,
                                                          }).ToListAsync();
                var DatosFiltro = ToExcelEmpresa(LstRegistroFiltro);
                return File(DatosFiltro, "application/vnd.ms-excel", "Registros por fecha requerida, Fecha de descarga: " + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xlsx");
            }
            return null;

        }

        public Byte[] ToExcelEmpresa(List<Registro> LstRegistrosEmpresa)
        {
            byte[] buffer = DatosAExcelEmpresas(LstRegistrosEmpresa);

            return buffer;

        }

        public byte[] DatosAExcelEmpresas(List<Registro> LstRegistrosEmpresa)
        {

            using MemoryStream guardar = new();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using ExcelPackage excel = new();
            var HojaExcel = excel.Workbook.Worksheets.Add("Personas");
            HojaExcel.Column(1).Width = 10.00;
            HojaExcel.Column(2).Width = 25.00;
            HojaExcel.Column(3).Width = 25.00;
            HojaExcel.Column(4).Width = 25.00;
            HojaExcel.Column(5).Width = 10.00;
            HojaExcel.Column(6).Width = 25.00;
            HojaExcel.Column(7).Width = 25.00;


            HojaExcel.Column(1).Style.WrapText = true;
            HojaExcel.Column(2).Style.WrapText = true;
            HojaExcel.Column(3).Style.WrapText = true;
            HojaExcel.Column(4).Style.WrapText = true;
            HojaExcel.Column(5).Style.WrapText = true;
            HojaExcel.Column(6).Style.WrapText = true;
            HojaExcel.Column(7).Style.WrapText = true;


            Color Blanco = Color.White;
            HojaExcel.Cells["A1:G1"].Style.Font.Color.SetColor(Blanco);
            HojaExcel.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            HojaExcel.Cells["A1"].Value = "FECHA";
            HojaExcel.Cells["B1"].Value = "ZONA";
            HojaExcel.Cells["C1"].Value = "SENTIDO";
            HojaExcel.Cells["D1"].Value = "PATENTE";
            HojaExcel.Cells["E1"].Value = "PERSONA";
            HojaExcel.Cells["F1"].Value = "TIPO DE ACTOR";
            HojaExcel.Cells["G1"].Value = "UBICACION";

            int i = 2;

            foreach (var item in LstRegistrosEmpresa)
            {
                HojaExcel.Cells["A" + i.ToString()].Value = item.Fecha;
                HojaExcel.Cells["B" + i.ToString()].Value = item.Zona.Nombre;
                HojaExcel.Cells["C" + i.ToString()].Value = item.Sentido.Direccion;
                HojaExcel.Cells["D" + i.ToString()].Value = item.Patente.PatenteDigitos;
                HojaExcel.Cells["E" + i.ToString()].Value = item.Persona.Nombres + "" + item.Persona.Apellidos;
                HojaExcel.Cells["F" + i.ToString()].Value = item.TipoActor.Tipo;
                HojaExcel.Cells["G" + i.ToString()].Value = item.Ubicacion.Nombre;

                i++;
            }

            excel.SaveAs(guardar);
            Byte[] buffer = guardar.ToArray();
            return buffer;
        }

    }
}