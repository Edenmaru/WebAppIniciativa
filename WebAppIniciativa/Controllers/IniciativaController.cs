using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using WebAppIniciativa.Models;
using System.Data.SqlClient;
using System.Data;
using OfficeOpenXml;

namespace WebAppIniciativa.Controllers
{
    public class IniciativaController : Controller
    {
        //Conexion a la base de datos

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnwin"].ConnectionString);
        
        
        //************
        //**Listados**
        //************

        IEnumerable<Eje> listadoEje()
        {
            List<Eje> temporal = new List<Eje>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_ejes",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Eje reg = new Eje();
                reg.codEje = dr.GetString(0);
                reg.nomEje = dr.GetString(1);
                reg.desEje = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Requerimiento> listadoRequerimientoxEje(string codEje)
        {
            List<Requerimiento> temporal = new List<Requerimiento>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_requerimientosxeje", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codEje", codEje);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Requerimiento reg = new Requerimiento();
                reg.codReq = dr.GetString(0);
                reg.nomReq = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<RequerimientoxEje> listadoRequerimiento()
        {
            List<RequerimientoxEje> temporal = new List<RequerimientoxEje>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_requerimientos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                RequerimientoxEje reg = new RequerimientoxEje();
                reg.codReq = dr.GetString(0);
                reg.nomEje = dr.GetString(1);
                reg.nomReq = dr.GetString(2);
                reg.desReq = dr.GetString(3);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Impacto> listadoImpacto()
        {
            List<Impacto> temporal = new List<Impacto>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Impactos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Impacto reg = new Impacto();
                reg.codImp = dr.GetInt32(0);
                reg.nomImp = dr.GetString(1);
                reg.desImp = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Interesado> listadoInteresado()
        {
            List<Interesado> temporal = new List<Interesado>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_interesados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Interesado reg = new Interesado();
               
                reg.nomGer = dr.GetString(0);
                reg.nomJef = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Anexo> listadoAnexo()
        {
            List<Anexo> temporal = new List<Anexo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Anexos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Anexo reg = new Anexo();
                reg.codAne = dr.GetInt32(0);
                reg.nomAne = dr.GetString(1);
                reg.desAne = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<ClasificacionInversion> listadoClasificacionInversion()
        {
            List<ClasificacionInversion> temporal = new List<ClasificacionInversion>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_clasificacion_inversion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClasificacionInversion reg = new ClasificacionInversion();
                reg.nomTinv = dr.GetString(0);
                reg.nomFam = dr.GetString(1);
                reg.desFam = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Gerencia> listadoGerencia()
        {
            List<Gerencia> temporal = new List<Gerencia>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Gerencias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Gerencia reg = new Gerencia();
                reg.codGer = dr.GetInt32(0);
                reg.nomGer = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Jefatura> listadoJefaturaxGerencia(int codGer)
        {
            List<Jefatura> temporal = new List<Jefatura>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_JefaturasxGerencia", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codGer", codGer);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Jefatura reg = new Jefatura();
                reg.codJef = dr.GetInt32(0);
                reg.nomJef = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Jefatura> listadoJefatura()
        {
            List<Jefatura> temporal = new List<Jefatura>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Jefaturas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Jefatura reg = new Jefatura();
                reg.codJef = dr.GetInt32(0);
                reg.nomJef = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<CapaDeRed> listadoCapaDeRed()
        {
            List<CapaDeRed> temporal = new List<CapaDeRed>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Capas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CapaDeRed reg = new CapaDeRed();
                reg.codCapa = dr.GetInt32(0);
                reg.nomCapa = dr.GetString(1);
                reg.desCapa = dr.GetString(2);   
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<TipoIniciativa> listadoTipoIniciativa()
        {
            List<TipoIniciativa> temporal = new List<TipoIniciativa>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Tipo_Iniciativa", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoIniciativa reg = new TipoIniciativa();
                reg.codTipoIni = dr.GetInt32(0);
                reg.nomTipoIni = dr.GetString(1);
                reg.desTipoIni = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<BusinessCase> listadoBusinessCase()
        {
            List<BusinessCase> temporal = new List<BusinessCase>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_BCase", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BusinessCase reg = new BusinessCase();
                reg.codBc = dr.GetInt32(0);
                reg.desBc = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<TipoInversion> listadoTipoInversion()
        {
            List<TipoInversion> temporal = new List<TipoInversion>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Tipo_inversion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoInversion reg = new TipoInversion();
                reg.codTipoInv = dr.GetInt32(0);
                reg.nomTipoInv = dr.GetString(1);
                reg.desTipoInv = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Familia> listadoFamiliaxTipo(int codInv)
        {
            List<Familia> temporal = new List<Familia>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_FamiliaxTipo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codInv", codInv);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Familia reg = new Familia();
                reg.codFam= dr.GetInt32(0);
                reg.nomFam = dr.GetString(1);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Familia> listadoFamilia()
        {
            List<Familia> temporal = new List<Familia>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Familia", cn);
            cmd.CommandType = CommandType.StoredProcedure;          
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Familia reg = new Familia();
                reg.codFam = dr.GetInt32(0);
                reg.nomFam = dr.GetString(1);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<TipoSitio> listadoTipoSitio()
        {
            List<TipoSitio> temporal = new List<TipoSitio>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Tipo_sitio", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoSitio reg = new TipoSitio();
                reg.codTipoSit = dr.GetInt32(0);
                reg.nomTipoSit = dr.GetString(1);
                reg.desTipoSit = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<TipoEstructura> listadoTipoEstructura()
        {
            List<TipoEstructura> temporal = new List<TipoEstructura>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_Tipo_estructura", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoEstructura reg = new TipoEstructura();
                reg.codTipoEst = dr.GetInt32(0);
                reg.nomTipoEst = dr.GetString(1);
                reg.desTipoEst = dr.GetString(2);
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Cliente> listadoCliente()
        {
            List<Cliente> temporal = new List<Cliente>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_clientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente reg = new Cliente();
                reg.codCli = dr.GetInt32(0);
                reg.nomCli = dr.GetString(1);
                reg.apeCli = dr.GetString(2);
                reg.dniCli = dr.GetString(3);
                reg.dirCli = dr.GetString(4);
                reg.emailCli = dr.GetString(5);
                reg.tipo = dr.GetInt32(6);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }
        
        IEnumerable<SolicitudIniciativa> listadoSolIniGuardada()
        {
            List<SolicitudIniciativa> temporal = new List<SolicitudIniciativa>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_soliniguardada", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SolicitudIniciativa reg = new SolicitudIniciativa();
                reg.nroCorrelativo = dr.GetString(0);
                reg.codCli = dr.GetInt32(1);
                reg.codEje = dr.GetString(3);
                reg.codReq = dr.GetString(4);
                reg.nomIni = dr.GetString(5);
                reg.desIni = dr.GetString(6);
                reg.objIni = dr.GetString(7);
                reg.benIni = dr.GetString(8);
                reg.codImp = dr.GetInt32(9);
                reg.desImp = dr.GetString(10);
                reg.fecIni = dr.GetDateTime(11);
                reg.fecTer = dr.GetDateTime(12);
                reg.codGer = dr.GetInt32(13);
                reg.codJef = dr.GetInt32(14);
                reg.codCap = dr.GetInt32(15);
                reg.ubicacion = dr.GetString(16);
                reg.codTip = dr.GetInt32(17);
                reg.desTip = dr.GetString(18);
                reg.codAne = dr.GetInt32(19);
                reg.desAne = dr.GetString(20);
                reg.busCase = dr.GetBoolean(21);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        IEnumerable<DetalleIniciativa> listadoDetIniGuardada(string nro)
        {
            List<DetalleIniciativa> temporal = new List<DetalleIniciativa>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_detiniguardada", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro", nro);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleIniciativa reg = new DetalleIniciativa();
                reg.nroItem = dr.GetInt32(0);
                reg.nomInv = dr.GetString(1);
                reg.nomFam = dr.GetString(2);
                reg.desItem = dr.GetString(3);
                reg.nomSit = dr.GetString(4);
                reg.nomEst = dr.GetString(5);
               
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        IEnumerable<DetalleInversion> listadoDetInvGuardadaxItem(int nroItem)
        {
            List<DetalleInversion> temporal = new List<DetalleInversion>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_detinvguardadaxitem", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro", nroItem);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleInversion reg = new DetalleInversion();
                reg.nro_correlativo = dr.GetString(0);
                reg.nro_item = dr.GetInt32(1);
                reg.fec_inv  = dr.GetDateTime(2);
                reg.precio = dr.GetDecimal(3);
                reg.cantidad = dr.GetInt32(4);
                
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        IEnumerable<SolicitudIniciativa> listadoSolicitudesxCliente(int cod)
        {
            List<SolicitudIniciativa> temporal = new List<SolicitudIniciativa>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listarSolicitudxCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SolicitudIniciativa reg = new SolicitudIniciativa();
                reg.nroCorrelativo = dr.GetString(0);
                reg.codEje = dr.GetString(1);
                reg.nomEje = dr.GetString(2);
                reg.codReq = dr.GetString(3);
                reg.nomReq = dr.GetString(4);
                reg.fecSol = dr.GetDateTime(5);
                reg.nomIni = dr.GetString(6);
                reg.desIni = dr.GetString(7);
                reg.objIni = dr.GetString(8);
                reg.benIni = dr.GetString(9);
                reg.nomImp = dr.GetString(10);
                reg.desImp = dr.GetString(11);
                reg.fecIni = dr.GetDateTime(12);
                reg.fecTer = dr.GetDateTime(13);
                reg.nomGer = dr.GetString(14);
                reg.nomJef = dr.GetString(15);
                reg.nomCap = dr.GetString(16);
                reg.ubicacion = dr.GetString(17);
                reg.nomTip = dr.GetString(18);
                reg.desTip = dr.GetString(19);
                reg.nomAne = dr.GetString(20);
                reg.desAne = dr.GetString(21);
                reg.nomBusCase = dr.GetString(22);
                reg.estado = dr.GetString(23);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        IEnumerable<ReporteIniciativa> reporteIniciativa()
        {
            List<ReporteIniciativa> temporal = new List<ReporteIniciativa>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_resumenIniciativa", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ReporteIniciativa reg = new ReporteIniciativa();
                reg.nroCorrelativo = dr.GetString(0);
                reg.codEje = dr.GetString(1);
                reg.nomEje = dr.GetString(2);
                reg.codReq = dr.GetString(3);
                reg.nomReq = dr.GetString(4);
                reg.fechaSol = dr.GetDateTime(5);
                reg.nomIni = dr.GetString(6);
                reg.desIni = dr.GetString(7);
                reg.objIni = dr.GetString(8);
                reg.benIni = dr.GetString(9);
                reg.tipoImp = dr.GetString(10);
                reg.desImp = dr.GetString(11);
                reg.fecIni = dr.GetDateTime(12);
                reg.fecTer = dr.GetDateTime(13);
                reg.nomGer = dr.GetString(14);
                reg.nomJef = dr.GetString(15);
                reg.nomCap = dr.GetString(16);
                reg.ubi = dr.GetString(17);
                reg.tipoIni = dr.GetString(18);
                reg.desTipoIni = dr.GetString(19);
                reg.nomAne = dr.GetString(20);
                reg.desAne = dr.GetString(21);
                reg.bcase = dr.GetString(22);
                reg.nomInv = dr.GetString(23);
                reg.nomFam = dr.GetString(24);
                reg.desItem = dr.GetString(25);
                reg.nomSit = dr.GetString(26);
                reg.nomEst = dr.GetString(27);
                reg.fechaInv = dr.GetDateTime(28);
                reg.precio = dr.GetDecimal(29);
                reg.cantidad = dr.GetInt32(30);
                reg.capex = dr.GetDecimal(31);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        //***********
        //*Funciones*
        //***********


        List<Usuario> validaUsuario(string usu, string pas)
        {
            List<Usuario> temporal = new List<Usuario>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_validaUsuario",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usu", usu);
            cmd.Parameters.AddWithValue("@pas", pas);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario reg = new Usuario();
                reg.codCli = dr.GetInt32(0);
                reg.usuario = dr.GetString(1);
                reg.clave = dr.GetString(2);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<Cliente> buscarCliente(int codCli)
        {
            List<Cliente> temporal = new List<Cliente>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_buscaCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente reg = new Cliente();
                reg.codCli = dr.GetInt32(0);
                reg.nomCli = dr.GetString(1);
                reg.apeCli = dr.GetString(2);
                reg.dniCli = dr.GetString(3);
                reg.dirCli = dr.GetString(4);
                reg.emailCli = dr.GetString(5);

                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        //Listado de Fechas

        IEnumerable<Fecha> mesAño()
        {
            List<Fecha> temporal = new List<Fecha>();
            string año = DateTime.Now.ToString("yy");
            string[] mes = { "ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic" };
            for(int i=0; i <3; i++)
            {
                for(int j=0; j < 12; j++)
                {
                    Fecha fecha = new Fecha();
                    fecha.fec =  mes[j]+ "-" + año;
                    temporal.Add(fecha);
                }
                int año2=int.Parse(año);
                año2++;
                año = año2.ToString();
            }
            return temporal;
        }

        string autogenera()
        {
            SqlCommand cmd = new SqlCommand("select dbo.fx_autogenera()", cn);
            cn.Open();
            string codigo = cmd.ExecuteScalar().ToString();
            cn.Close();
            return codigo;
        }

        int generaNro()
        {
            SqlCommand cmd = new SqlCommand("select dbo.fx_generanroitem()", cn);
            cn.Open();
            int nro =int.Parse( cmd.ExecuteScalar().ToString());
            cn.Close();
            return nro;
        }
        
        public void ExportarExcel()
        {
            List<ReporteIniciativa> lista = (List<ReporteIniciativa>)reporteIniciativa();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Reporte de Iniciativa";
            ws.Cells["A3"].Value = "Fecha de descarga :";
            ws.Cells["B3"].Value = DateTime.Now.ToString();

            //Cabecera
            ws.Cells["A6"].Value = "Nro. Correlativo";
            ws.Cells["B6"].Value = "COD Eje";
            ws.Cells["C6"].Value = "Eje Estrategico";
            ws.Cells["D6"].Value = "COD Req";
            ws.Cells["E6"].Value = "Requerimiento";
            ws.Cells["F6"].Value = "Fecha de solicitud";
            ws.Cells["G6"].Value = "Nombre de la iniciativa";
            ws.Cells["H6"].Value = "Descripción de la Iniciativa";
            ws.Cells["I6"].Value = "Objetivo de la iniciativa";
            ws.Cells["J6"].Value = "Beneficio de la iniciativa";
            ws.Cells["K6"].Value = "Impacto de no ejecutar la Iniciativa (escala)";
            ws.Cells["L6"].Value = "Impacto de no ejecutar la Iniciativa (descripción)";
            ws.Cells["M6"].Value = "MES DE INICIO";
            ws.Cells["N6"].Value = "MES DE TERMINO";
            ws.Cells["O6"].Value = "Gerencia sponsor";
            ws.Cells["P6"].Value = "Jefatura solicitante";
            ws.Cells["Q6"].Value = "Capa de Red (clasificación)";
            ws.Cells["R6"].Value = "Ubicación ¿Dónde?";
            ws.Cells["S6"].Value = "Tipo de  Iniciativa (clasificación)";
            ws.Cells["T6"].Value = "Tipo de  Iniciativa (descripción)";
            ws.Cells["U6"].Value = "Anexo (clasificación)";
            ws.Cells["V6"].Value = "Anexo (descripción)";
            ws.Cells["W6"].Value = "BUSINESS CASE";
            ws.Cells["X6"].Value = "Tipo de Inversión";
            ws.Cells["Y6"].Value = "Familia";
            ws.Cells["Z6"].Value = "Descripción";
            ws.Cells["AA6"].Value = "Tipo de sitio";
            ws.Cells["AB6"].Value = "Tipo de estructura";
            ws.Cells["AC6"].Value = "Fecha de Inversion";
            ws.Cells["AD6"].Value = "Precio";
            ws.Cells["AE6"].Value = "Cantidad";
            ws.Cells["AF6"].Value = "CAPEX";

            int rowStart = 7;

            foreach (var item in lista)
            {


                ws.Cells[string.Format("A{0}", rowStart)].Value = item.nroCorrelativo;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.codEje;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.nomEje;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.codReq;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.nomReq;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.fechaSol.ToString("dd-MM-yyyy");
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.nomIni;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.desIni;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.objIni;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.benIni;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.tipoImp;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.desImp;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.fecIni.ToString("MMM-yyyy");
                ws.Cells[string.Format("N{0}", rowStart)].Value = item.fecTer.ToString("MMM-yyyy");
                ws.Cells[string.Format("O{0}", rowStart)].Value = item.nomGer;
                ws.Cells[string.Format("P{0}", rowStart)].Value = item.nomJef;
                ws.Cells[string.Format("Q{0}", rowStart)].Value = item.nomCap;
                ws.Cells[string.Format("R{0}", rowStart)].Value = item.ubi;
                ws.Cells[string.Format("S{0}", rowStart)].Value = item.tipoIni;
                ws.Cells[string.Format("T{0}", rowStart)].Value = item.desTipoIni;
                ws.Cells[string.Format("U{0}", rowStart)].Value = item.nomAne;
                ws.Cells[string.Format("V{0}", rowStart)].Value = item.desAne;
                ws.Cells[string.Format("W{0}", rowStart)].Value = item.bcase;
                ws.Cells[string.Format("X{0}", rowStart)].Value = item.nomInv;
                ws.Cells[string.Format("Y{0}", rowStart)].Value = item.nomFam;
                ws.Cells[string.Format("Z{0}", rowStart)].Value = item.desItem;
                ws.Cells[string.Format("AA{0}", rowStart)].Value = item.nomSit;
                ws.Cells[string.Format("AB{0}", rowStart)].Value = item.nomEst;
                ws.Cells[string.Format("AC{0}", rowStart)].Value = item.fechaInv.ToString("MMM-yyyy");
                ws.Cells[string.Format("AD{0}", rowStart)].Value = item.precio.ToString();
                ws.Cells[string.Format("AE{0}", rowStart)].Value = item.cantidad.ToString();
                ws.Cells[string.Format("AF{0}", rowStart)].Value = item.capex.ToString();

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ReporteDeIniciativas.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        //****************
        //*Vistas básicas*
        //****************


        //Menu Principal
        
        public ActionResult Index(string msj="")
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                int cod =(int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();

                if (cli.tipo == 1)
                    return RedirectToAction("InicioAdm");

                string nombre = cli.nomCli;
                ViewBag.nombre = nombre;
                ViewBag.mensaje = msj;
                return View();
            }
            
        }

        //Autenticacion

        public ActionResult Login(string msj)
        {
            ViewBag.mensaje = msj;
            return View();
        }

        [HttpPost] public ActionResult Login(string usu, string pas)
        {
            string mensaje;
            List<Usuario> validado = validaUsuario(usu, pas);
            if (validado.Any())
            {
                Usuario usuario = validado.Where(c => c.usuario == usu).FirstOrDefault();
                //int cod = usuario.codCli;
                Cliente cliente = listadoCliente().Where(c => c.codCli == usuario.codCli).FirstOrDefault();

                mensaje = "";
                Session["codCli"] = usuario.codCli;

                if (cliente.tipo == 0)
                {
                    return RedirectToAction("Index", "Iniciativa", new { msj = mensaje });
                }
                else
                {
                    return RedirectToAction("InicioAdm", "Iniciativa", new { msj = mensaje });
                }
     
                
            }

            else
            {
                mensaje = "Ingrese los datos correctos";
                return RedirectToAction("Login", "Iniciativa", new { msj = mensaje });
            }
        }

        //Vista Glosario

        public ActionResult Glosario()
        {
            if (Session["codCli"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int cod = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();
                if (cli.tipo == 1) 
                    return RedirectToAction("InicioAdm");
                ViewBag.listaEje = listadoEje();
                ViewBag.listaReq = listadoRequerimiento();
                ViewBag.listaInt = listadoInteresado();
                ViewBag.listaCap = listadoCapaDeRed();
                ViewBag.listaTipIni = listadoTipoIniciativa();
                ViewBag.listaTipoInv = listadoTipoInversion();
                ViewBag.listaCla = listadoClasificacionInversion();
                ViewBag.listaSit = listadoTipoSitio();
                ViewBag.listaTes = listadoTipoEstructura();
                ViewBag.listaAne = listadoAnexo();

                return View();
            }
        }

        //Vista Administrador

        public ActionResult InicioAdm()
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                int cod = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();

                if (cli.tipo == 0)
                    return RedirectToAction("Index");
                return View();
            }   
        }

        

        //*************
        //*Formularios*
        //*************


        //Vista de Solicitud de Inversión

        public ActionResult CreateSIn()
        {
           if (Session["codCli"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int cod = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();
                if (cli.tipo==1)
                    return RedirectToAction("InicioAdm");

                ViewBag.ejes = new SelectList(listadoEje(), "codEje", "nomEje");
                ViewBag.req = new SelectList(listadoRequerimiento(), "codReq", "nomReq");
                ViewBag.fecIni = new SelectList(mesAño(), "fec", "fec");
                ViewBag.fecTer = new SelectList(mesAño(), "fec", "fec");
                ViewBag.ger = new SelectList(listadoGerencia(), "codGer", "nomGer");
                ViewBag.jef = new SelectList(listadoJefatura(), "codJef", "nomJef");
                ViewBag.capa = new SelectList(listadoCapaDeRed(), "codCapa", "nomCapa");
                ViewBag.tini = new SelectList(listadoTipoIniciativa(), "codTipoIni", "nomTipoIni");
                ViewBag.ane = new SelectList(listadoAnexo(), "codAne", "nomAne");
                

                return View(new SolicitudIniciativa());
            }

           
        }

        [HttpPost]public ActionResult CreateSIn(SolicitudIniciativa reg)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else if(reg.nroCorrelativo!=null){
                ViewBag.mensaje="La solicitud ya ha sido guardada";
                ViewBag.ejes = new SelectList(listadoEje(), "codEje", "nomEje", reg.codEje);
                ViewBag.req = new SelectList(listadoRequerimiento(), "codReq", "nomReq", reg.codReq);
                ViewBag.fecIni = new SelectList(mesAño(), "fec", "fec", reg.fecIni);
                ViewBag.fecTer = new SelectList(mesAño(), "fec", "fec", reg.fecTer);
                ViewBag.ger = new SelectList(listadoGerencia(), "codGer", "nomGer", reg.codGer);
                ViewBag.jef = new SelectList(listadoJefatura(), "codJef", "nomJef", reg.codJef);
                ViewBag.capa = new SelectList(listadoCapaDeRed(), "codCapa", "nomCapa", reg.codCap);
                ViewBag.tini = new SelectList(listadoTipoIniciativa(), "codTipoIni", "nomTipoIni", reg.codTip);
                ViewBag.ane = new SelectList(listadoAnexo(), "codAne", "nomAne", reg.codAne);
                return View(reg);
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ejes = new SelectList(listadoEje(), "codEje", "nomEje", reg.codEje);
                    ViewBag.req = new SelectList(listadoRequerimiento(), "codReq", "nomReq", reg.codReq);
                    ViewBag.fecIni = new SelectList(mesAño(), "fec", "fec", reg.fecIni);
                    ViewBag.fecTer = new SelectList(mesAño(), "fec", "fec", reg.fecTer);
                    ViewBag.ger = new SelectList(listadoGerencia(), "codGer", "nomGer", reg.codGer);
                    ViewBag.jef = new SelectList(listadoJefatura(), "codJef", "nomJef", reg.codJef);
                    ViewBag.capa = new SelectList(listadoCapaDeRed(), "codCapa", "nomCapa", reg.codCap);
                    ViewBag.tini = new SelectList(listadoTipoIniciativa(), "codTipoIni", "nomTipoIni", reg.codTip);
                    ViewBag.ane = new SelectList(listadoAnexo(), "codAne", "nomAne", reg.codAne);
                    ViewBag.mensaje = "Complete el formulario";
                    return View(reg);
                }
                string mensaje;
                string codigo = autogenera();
                reg.nroCorrelativo = codigo;
                cn.Open();

                SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
                try
                {


                    SqlCommand cmd = new SqlCommand(
                        "sp_inSolIniGuardar", cn, tr);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro", reg.nroCorrelativo);
                    cmd.Parameters.AddWithValue("@codcli", reg.codCli);
                    cmd.Parameters.AddWithValue("@codeje", reg.codEje);
                    cmd.Parameters.AddWithValue("@codreq", reg.codReq);
                    cmd.Parameters.AddWithValue("@nom", reg.nomIni);
                    cmd.Parameters.AddWithValue("@des", reg.desIni);
                    cmd.Parameters.AddWithValue("@obj", reg.objIni);
                    cmd.Parameters.AddWithValue("@ben", reg.benIni);
                    cmd.Parameters.AddWithValue("@codimp", reg.codImp);
                    cmd.Parameters.AddWithValue("@desimp", reg.desImp);
                    cmd.Parameters.AddWithValue("@fecini", reg.fecIni);
                    cmd.Parameters.AddWithValue("@fecter", reg.fecTer);
                    cmd.Parameters.AddWithValue("@codger", reg.codGer);
                    cmd.Parameters.AddWithValue("@codjef", reg.codJef);
                    cmd.Parameters.AddWithValue("@codcap", reg.codCap);
                    cmd.Parameters.AddWithValue("@ubicacion", reg.ubicacion);
                    cmd.Parameters.AddWithValue("@codtip", reg.codTip);
                    cmd.Parameters.AddWithValue("@destip", reg.desTip);
                    cmd.Parameters.AddWithValue("@codane", reg.codAne);
                    cmd.Parameters.AddWithValue("@desane", reg.desAne);
                    cmd.Parameters.AddWithValue("@buscase", reg.busCase);

                    cmd.ExecuteNonQuery();

                    tr.Commit();
                    mensaje = "Solicitud guardada";

                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }

                ViewBag.ejes = new SelectList(listadoEje(), "codEje", "nomEje", reg.codEje);
                ViewBag.req = new SelectList(listadoRequerimiento(), "codReq", "nomReq", reg.codReq);
                ViewBag.fecIni = new SelectList(mesAño(), "fec", "fec", reg.fecIni);
                ViewBag.fecTer = new SelectList(mesAño(), "fec", "fec", reg.fecTer);
                ViewBag.ger = new SelectList(listadoGerencia(), "codGer", "nomGer", reg.codGer);
                ViewBag.jef = new SelectList(listadoJefatura(), "codJef", "nomJef", reg.codJef);
                ViewBag.capa = new SelectList(listadoCapaDeRed(), "codCapa", "nomCapa", reg.codCap);
                ViewBag.tini = new SelectList(listadoTipoIniciativa(), "codTipoIni", "nomTipoIni", reg.codTip);
                ViewBag.ane = new SelectList(listadoAnexo(), "codAne", "nomAne", reg.codAne);
                ViewBag.mensaje = mensaje;

                return View(reg);
            }


            
        }
        
        //Vista de Flujo de Inversión

        public ActionResult CreateFIn(string nroCo)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                if (nroCo == null) return RedirectToAction("CreateSIn");
                else
                {
                   
                    SolicitudIniciativa si = listadoSolIniGuardada().Where(s => s.nroCorrelativo == nroCo).FirstOrDefault();
                    int cod = (int)Session["codCli"];
                    Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();

                    if (si == null)
                        return RedirectToAction("CreateSIn");
                    if (si.codCli != cli.codCli)
                        return RedirectToAction("Index");
                    

                    ViewBag.solini = si;
                    ViewBag.tiin = new SelectList(listadoTipoInversion(), "codTipoInv", "nomTipoInv");
                    ViewBag.fam = new SelectList(listadoFamilia(), "codFam", "nomFam");
                    ViewBag.tisi = new SelectList(listadoTipoSitio(), "codTipoSit", "nomTipoSit");
                    ViewBag.ties = new SelectList(listadoTipoEstructura(), "codTipoEst", "nomTipoEst");
                    ViewBag.listaDetIni = listadoDetIniGuardada(nroCo);

                    return View(new DetalleIniciativa());
                }
            }

            
        }

        [HttpPost]public ActionResult CreateFIn(DetalleIniciativa reg)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                if (!ModelState.IsValid)
                {
                    SolicitudIniciativa sol = listadoSolIniGuardada().Where(s => s.nroCorrelativo == reg.nroCorrelativo).FirstOrDefault();
                    ViewBag.solini = sol;
                    ViewBag.tiin = new SelectList(listadoTipoInversion(), "codTipoInv", "nomTipoInv", reg.codInv);
                    ViewBag.fam = new SelectList(listadoFamilia(), "codFam", "nomFam", reg.codFam);
                    ViewBag.tisi = new SelectList(listadoTipoSitio(), "codTipoSit", "nomTipoSit", reg.codSit);
                    ViewBag.ties = new SelectList(listadoTipoEstructura(), "codTipoEst", "nomTipoEst", reg.codEst);
                    ViewBag.listaDetIni = listadoDetIniGuardada(reg.nroCorrelativo);
                    ViewBag.mensaje = "Completar formulario";
                    return View(reg);
                }

                string mensaje;
                SolicitudIniciativa si = listadoSolIniGuardada().Where(s => s.nroCorrelativo == reg.nroCorrelativo).FirstOrDefault();
                //int meses = (si.fecTer.Month - si.fecIni.Month);
                int meses = (int)((si.fecTer - si.fecIni).TotalDays / 30);
                int nro = generaNro();
                cn.Open();

                SqlTransaction t = cn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "sp_inDetSolGuardar", cn, t);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro", reg.nroCorrelativo);
                    cmd.Parameters.AddWithValue("@nitem", nro);
                    cmd.Parameters.AddWithValue("@codinv", reg.codInv);
                    cmd.Parameters.AddWithValue("@codfam", reg.codFam);
                    cmd.Parameters.AddWithValue("@desitem", reg.desItem);
                    cmd.Parameters.AddWithValue("@codsit", reg.codSit);
                    cmd.Parameters.AddWithValue("@codest", reg.codEst);

                    cmd.ExecuteNonQuery();


                    mensaje = "Linea de inversion agregada";

                    for (int i = 0; i <= meses; i++)
                    {
                        cmd = new SqlCommand("sp_inPrimerDetInvGuardar", cn, t);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nco", reg.nroCorrelativo);
                        cmd.Parameters.AddWithValue("@nro", nro);
                        cmd.Parameters.AddWithValue("@fec", si.fecIni.AddMonths(i));
                        cmd.ExecuteNonQuery();
                    }
                    t.Commit();
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }


                ViewBag.solini = si;
                ViewBag.tiin = new SelectList(listadoTipoInversion(), "codTipoInv", "nomTipoInv", reg.codInv);
                ViewBag.fam = new SelectList(listadoFamilia(), "codFam", "nomFam", reg.codFam);
                ViewBag.tisi = new SelectList(listadoTipoSitio(), "codTipoSit", "nomTipoSit", reg.codSit);
                ViewBag.ties = new SelectList(listadoTipoEstructura(), "codTipoEst", "nomTipoEst", reg.codEst);
                ViewBag.listaDetIni = listadoDetIniGuardada(reg.nroCorrelativo);
                ViewBag.mensaje = mensaje;

                return View(reg);
            }

           
        }
        
        //Vista Detalle de Inversion

        public ActionResult EditDIn(int nroItem, string msg="")
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else{
                DetalleInversion di = listadoDetInvGuardadaxItem(nroItem).FirstOrDefault();

                SolicitudIniciativa si = listadoSolIniGuardada().Where(s => s.nroCorrelativo == di.nro_correlativo).FirstOrDefault();
                int cod = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();

                if (si.codCli != cli.codCli)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.detinv = di;
                ViewBag.listaDetInv = listadoDetInvGuardadaxItem(nroItem);
                ViewBag.mensaje = msg;
                return View();
            }
            
        }
        
        //Vista Editar Detalle de Inversion

        public ActionResult EditarDetalleInversion(string nco="",int nro=0, DateTime ? fec=null)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                DateTime f = fec == null ? DateTime.Today : (DateTime)fec;
                DetalleInversion di = listadoDetInvGuardadaxItem(nro).Where(d => d.fec_inv == f).FirstOrDefault();


                ViewBag.detinv = di;
                if (di == null)
                {
                    string mensaje = "Campos Actualizados";
                    return RedirectToAction("EditDIn", new { nroItem = nro, msg = mensaje });
                }

                SolicitudIniciativa si = listadoSolIniGuardada().Where(s => s.nroCorrelativo == di.nro_correlativo).FirstOrDefault();
                int cod = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == cod).SingleOrDefault();

                if (si.codCli != cli.codCli)
                {
                    return RedirectToAction("Index");
                }

                return View(di);
            }
           
        }

        [HttpPost]public ActionResult EditarDetalleInversion(DetalleInversion detalle)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                
                //Validacion del Modelo
                if (!ModelState.IsValid)
                {
                    ViewBag.mensaje = "Complete el formulario";
                    DetalleInversion det = listadoDetInvGuardadaxItem(detalle.nro_item).Where(d => d.fec_inv == detalle.fec_inv).FirstOrDefault();
                    ViewBag.detinv = det;
                    return View(detalle);
                }

                string mensaje;
                cn.Open();


                //Insercion de valores
                SqlTransaction t = cn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "sp_edDetInvGuardar", cn, t);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nco", detalle.nro_correlativo);
                    cmd.Parameters.AddWithValue("@nro", detalle.nro_item);
                    cmd.Parameters.AddWithValue("@fec", detalle.fec_inv);
                    cmd.Parameters.AddWithValue("@pre", detalle.precio);
                    cmd.Parameters.AddWithValue("@can", detalle.cantidad);

                    cmd.ExecuteNonQuery();

                    t.Commit();
                    mensaje = " Actualizado correctamente ";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }

                ViewBag.mensaje = mensaje;
                DetalleInversion di = listadoDetInvGuardadaxItem(detalle.nro_item).Where(d => d.fec_inv == detalle.fec_inv).FirstOrDefault();
                ViewBag.detinv = di;

                return View(detalle);
            }
            
        }

        //Vista de Solicitudes

        public ActionResult VerSolicitudIniciativa(int cod=0, string msj="")
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {

                int codigo = (int)Session["codCli"];
                Cliente cli = listadoCliente().Where(n => n.codCli == codigo).SingleOrDefault();

                if (cod != cli.codCli)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.mensaje = msj;
                return View(listadoSolicitudesxCliente(cod));
            }
        }
        

        public ActionResult EliminarSolicitud(string nroCo = "")
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                int codigo = (int)Session["codCli"];
                string mensaje = "";

                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarSolicitudIniciativa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nco", nroCo);
                    cmd.ExecuteNonQuery();
                    mensaje = "Solicitud eliminada";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }

               
                return RedirectToAction("VerSolicitudIniciativa",new {cod =codigo,msj = mensaje });
            }
        }

        //DropDownList dependientes

        [HttpGet] public JsonResult Requerimiento (string cod)
        {
            List<Requerimiento> lista = new List<Requerimiento>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_REQUERIMIENTOSXEJE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codEje", cod);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Requerimiento reg = new Requerimiento();
                reg.codReq = dr.GetString(0);
                reg.nomReq = dr.GetString(1);                
                lista.Add(reg);
            }
            dr.Close(); cn.Close();

            return Json(lista ,JsonRequestBehavior.AllowGet);
        }

        [HttpGet] public JsonResult Jefatura(int cod)
        {
            List<Jefatura> lista = new List<Jefatura>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_JEFATURASxGERENCIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codGer", cod);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Jefatura reg = new Jefatura();
                reg.codJef = dr.GetInt32(0);
                reg.nomJef = dr.GetString(1);
                lista.Add(reg);
            }
            dr.Close(); cn.Close();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] public JsonResult Familia(int cod)
        {
            List<Familia> lista = new List<Familia>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPOINVERSIONxFAMILIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codInv", cod);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Familia reg = new Familia();
                reg.codFam = dr.GetInt32(0);
                reg.nomFam = dr.GetString(1);
                lista.Add(reg);
            }
            dr.Close(); cn.Close();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        //Enviar Solicitud

        public ActionResult EnviarSolicitud(string cod)
        {
            if (Session["codCli"] == null)
                return RedirectToAction("Login");
            else
            {
                string mensaje = "";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_enviarSolicitudIniciativa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nco", cod);
                    cmd.ExecuteNonQuery();
                    mensaje = "Solicitud Enviada";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally
                {
                    cn.Close();
                }

                return RedirectToAction("Index", new { msj = mensaje });
            }
            
        }

    }
}