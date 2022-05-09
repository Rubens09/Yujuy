using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NodaTime;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using WebApplication1.Models;




namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpPost("AltaUsuario")]
        public ResAlta AltaUsuario(InfoUsuario listaInformacion)
        {
            ResAlta res =new ResAlta();
            res.respuesta= Metodos.AltaUsuario(listaInformacion);
            return res;
        }
        [HttpPost("AltaDireccion")]
        public ResAlta AltaDireccion(InfoDireccion listadireccion)
        {
            ResAlta res = new ResAlta();
            res.respuesta = Metodos.AltaDireccion(listadireccion);
            return res;
        }
        public class ResAlta{
            public string respuesta { get; set; }
        }
        public class InfoUsuario
        {
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public DateTime FechaNacimiento { get; set; }    
        }
        public class InfoBusqueda
        {
            public int IDProducto { get; set; }
            public int IDCategoria { get; set; }
        }
        public class InfoDireccion
        {
            public string NombreCalle { get; set; }
            public int NumeroInterior { get; set; }
            public int NumeroExterior { get; set; }
            public string Colonia { get; set; }
            public string MunicipioDelegacion { get; set; }
            public string Estado { get; set; }
            public string CodigoPostal { get; set; }
            public int Idusuario { get; set; }
            public int IdReferencia { get; set; }
        }
        public class InfoBusquedaArticuloCategoria
        {
            public string MetodoPago { get; set; }
        }
    }
}
