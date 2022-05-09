using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static WebApplication1.Controllers.HomeController;

namespace WebApplication1.Models
{
    public class Metodos
    {
        public static string GenId()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[32 / 16];
            rng.GetBytes(bytes);
            BigInteger num = new BigInteger(bytes);

            string mDato = (num.GetHashCode()).ToString();
            SHA1 hash = new SHA1CryptoServiceProvider();
            StringBuilder x = new StringBuilder();
            //SHA3Managed hash = new SHA3Managed(mTamaño);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] MessageBytes = encoding.GetBytes(mDato);
            byte[] ComputeHashBytes = hash.ComputeHash(MessageBytes);
            foreach (var item in MessageBytes) { x.Append(item.ToString("x2")); }
            return x.ToString();
        }
        public static string AltaUsuario(InfoUsuario listaInformacion)
        {
            string sqry = "";
            string Nombres = listaInformacion.Nombres.ToUpper();
            string ApellidoPaterno = listaInformacion.ApellidoPaterno.ToUpper();
            string ApellidoMaterno = listaInformacion.ApellidoMaterno.ToUpper();
            string Email = listaInformacion.Email.ToLower();
            string Telefono = listaInformacion.Telefono;
            DateTime FechaNacimiento = listaInformacion.FechaNacimiento;

            var cadenaConexion = "Server = 192.168.0.245;Database = DB_YJ; Connection Timeout = 2; Pooling = false;User ID = sa; Password = Med*8642; Trusted_Connection = False";
            SqlConnection conn = new SqlConnection(cadenaConexion);
            SqlCommand cmd;
            cmd = new SqlCommand(sqry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AltaUsuario";
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Email", Email));
            cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
            cmd.Parameters.Add(new SqlParameter("@Nombres", Nombres));
            cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", ApellidoPaterno));
            cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", ApellidoMaterno));
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));
            sqry = cmd.ExecuteScalar().ToString();//(string)cmd.ExecuteScalar();
            conn.Close();
            return sqry;
        }
        public static string AltaDireccion(InfoDireccion listadireccion)
        {
            string sqry = "";
            string calle = listadireccion.NombreCalle.ToUpper();
            int NumeroInterior = listadireccion.NumeroInterior;
            int NumeroExterior = listadireccion.NumeroExterior;
            string Colonia = listadireccion.Colonia;
            string Municipio = listadireccion.MunicipioDelegacion.ToUpper();
            string Estado = listadireccion.Estado.ToUpper();
            string CodigoPostal = listadireccion.CodigoPostal;
            int IDUsuario = listadireccion.Idusuario;
            int IDReferencia = listadireccion.IdReferencia;
            var cadenaConexion = "Server = 192.168.0.245;Database = DB_YJ; Connection Timeout = 2; Pooling = false;User ID = sa; Password = Med*8642; Trusted_Connection = False";
            SqlConnection conn = new SqlConnection(cadenaConexion);
            SqlCommand cmd;
            cmd = new SqlCommand(sqry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AltaDireccion";
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NombreCalle", calle));
            cmd.Parameters.Add(new SqlParameter("@NumeroInterior", NumeroInterior));
            cmd.Parameters.Add(new SqlParameter("@NumeroExterior", NumeroExterior));
            cmd.Parameters.Add(new SqlParameter("@Colonia", Colonia));
            cmd.Parameters.Add(new SqlParameter("@MunicipioDelegacion", Municipio));
            cmd.Parameters.Add(new SqlParameter("@Estado", Estado));
            cmd.Parameters.Add(new SqlParameter("@CodigoPostal", CodigoPostal));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdReferencia", IDReferencia));
            sqry = cmd.ExecuteScalar().ToString();
            conn.Close();
            return sqry;
        }
        public static string BusquedaArticuloCategoria(InfoBusquedaArticuloCategoria listaBusqueda)
        {
            string sqry = "";
            string MetodoPago = listaBusqueda.MetodoPago;
            var cadenaConexion = "Server = 192.168.0.245;Database = DB_YJ; Connection Timeout = 2; Pooling = false;User ID = sa; Password = Med*8642; Trusted_Connection = False";
            SqlConnection conn = new SqlConnection(cadenaConexion);
            SqlCommand cmd;
            cmd = new SqlCommand(sqry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BusquedaArtCat";
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MetodoPAgo", MetodoPago));
            sqry = cmd.ExecuteScalar().ToString();
            conn.Close();
            return sqry;
        }
    }
}