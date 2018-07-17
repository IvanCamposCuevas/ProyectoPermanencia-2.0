using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.Data;

namespace ProyectoPermanencia.Negocio
{
    /// <summary>
    /// Clase que servira para consultar y devolver los datos pedidos por la pagina VisionGlobal.aspx,
    /// esta traera todo los alumnos de la base de datos, previo filtro, y los llenara en una grilla.
    /// </summary>
    public class NegocioPaginaGlobal
    {
        /// <summary>
        /// Este metodo servira para consultar a todos los Alumnos de la base de datos, previo filtro, con
        /// sus scores generales.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="jornada"></param>
        /// <param name="sede"></param>
        /// <param name="carrera"></param>
        /// <param name="escuela"></param>
        /// <returns></returns>
        public DataSet ConsultaScorePorFiltro(String sede, String jornada, String escuela, List<string> carrera)
        {
            NegocioConexionBD con = new NegocioConexionBD(); //Instancia la Clase NegocioConexionBD.
            con.configuraConexion(); //Se inicianalizan los parametros que me permitiran conectarme a la base de datos
                                     //Se crean una variable de texto, que permitira establecer las uniones con las tablas de la base datos
            String auxSQL = " WHERE "
       + "AL.Id_Alumno = SC.Id_Alumno"
       + " AND "
       + "AL.Id_Carrera = CA.Id_Carrera"
       + " AND "
       + "CA.Id_Escuela = ES.Id_Escuela"
       + " AND "
       + "AL.Id_Sede = SE.Id_Sede"
       + " AND "
       + "AL.Id_Jornada = JO.Id_Jornada";
            //+ " AND "
            //+ "AL.Desc_Rut_Alumno = IN.RUT";

            //Aplicar Filtros
            if (!String.IsNullOrEmpty(sede))
                auxSQL = auxSQL + " AND AL.Id_Sede = '" + sede + "'";
            if (!String.IsNullOrEmpty(jornada))
                auxSQL = auxSQL + " AND AL.Id_Jornada = '" + jornada + "'";
            if (!String.IsNullOrEmpty(escuela) && int.Parse(escuela) >= 1)
                auxSQL = auxSQL + " AND CA.Id_Escuela = '" + escuela + "'";
            foreach (string item in carrera)
            {
                auxSQL = auxSQL + " AND CA.Desc_Carrera = '" + item + "'";
            }

            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            con.Conec1.IntruccioneSQL = "SELECT AL.Desc_Rut_Alumno AS Rut,"
                                               + "AL.Desc_Alumno AS Nombre,"
                                               + "CA.Desc_Carrera AS Carrera,"
                                               + "AL.Desc_Telefono_Alumno AS Telefono,"
                                               + "AL.Desc_Correo_Inst AS 'Correo Institucional',"
                                               + "AL.Desc_Correo_Part AS 'Correo Privado',"
                                               + "ES.Desc_Escuela AS Escuela,"
                                               + "SE.Desc_Sede AS Sede,"
                                               + "JO.Desc_Jornada AS Jornada,"
                                               + "SC.Score AS Score " + "\n"

                                               + " FROM "
                                               + "dbo.Score_Alumnos SC,"
                                               + "dbo.LK_Alumno AL,"
                                               + "dbo.LK_Carrera CA,"
                                               + "dbo.LK_Escuela ES,"
                                               + "dbo.LK_Sede SE,"
                                               + "dbo.LK_Jornada JO" + "\n"
                                               + auxSQL;

            con.Conec1.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            con.Conec1.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return con.Conec1.DbDat; //Se retornan los datos en un DataSet.
        } // Fin metodo entrega


        /// <summary>
        /// Metodo que sirva para buscar a un Alumno en especifico de la base de datos, 
        /// ya sea tanto por el nombre o el rut, y con sus scores generales. (El resultado final
        /// es el mismo que del metodo consultaScore.
        /// </summary>
        /// <param name="rn"></param>
        /// <param name="valorTipo"></param>
        /// <returns></returns>
        public DataSet consultaScorePorRutNombre(String rn, String valorTipo)
        {
            NegocioConexionBD con = new NegocioConexionBD(); //Instancia la Clase NegocioConexionBD.
            con.configuraConexion(); //Se inicianalizan los parametros que me permitiran conectarme a la base de datos
                                     //Se crean una variable de texto, que permitira establecer las uniones con las tablas de la base datos
            String auxSQL = " WHERE "
                               + "AL.Id_Alumno = SC.Id_Alumno"
                               + " AND "
                               + "AL.Id_Carrera = CA.Id_Carrera"
                               + " AND "
                               + "CA.Id_Escuela = ES.Id_Escuela"
                               + " AND "
                               + "AL.Id_Sede = SE.Id_Sede"
                               + " AND "
                               + "AL.Id_Jornada = JO.Id_Jornada";

            //Aplicar Filtros
            if (!String.IsNullOrEmpty(rn) && valorTipo.Equals("1"))
                auxSQL = auxSQL + " AND AL.Desc_Rut_Alumno = '" + rn + "';";
            else
            {
                auxSQL = auxSQL + " AND AL.Desc_Alumno COLLATE Latin1_General_CI_AI LIKE '%" + rn + "%' COLLATE Latin1_General_CI_AI;";
            }
            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            con.Conec1.IntruccioneSQL = "SELECT AL.Desc_Rut_Alumno AS Rut,"
                                               + "AL.Desc_Alumno AS Nombre,"
                                               + "CA.Desc_Carrera AS Carrera,"
                                               + "AL.Desc_Telefono_Alumno AS Telefono,"
                                               + "AL.Desc_Correo_Inst AS 'Correo Institucional',"
                                               + "AL.Desc_Correo_Part AS 'Correo Privado',"
                                               + "ES.Desc_Escuela AS Escuela," 
                                               + "SE.Desc_Sede AS Sede,"
                                               + "JO.Desc_Jornada AS Jornada,"
                                               + "SC.Score AS Score " + "\n"

                                               + " FROM "
                                               + "dbo.Score_Alumnos SC,"
                                               + "dbo.LK_Alumno AL,"
                                               + "dbo.LK_Carrera CA,"
                                               + "dbo.LK_Escuela ES,"
                                               + "dbo.LK_Sede SE,"
                                               + "dbo.LK_Jornada JO" + "\n"
                                               + auxSQL;

            con.Conec1.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            con.Conec1.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return con.Conec1.DbDat; //Se retornan los datos en un DataSet.
        } // Fin metodo entrega


        /**
         * Ni idea si se usara estas funciones, las comento eso si por si algun día se usan.
         * */


        //public bool validarRut(string rut)
        //{

        //    bool validacion = false;
        //    try
        //    {
        //        rut = rut.ToUpper();
        //        rut = rut.Replace(".", "");
        //        rut = rut.Replace("-", "");
        //        int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

        //        char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

        //        int m = 0, s = 1;
        //        for (; rutAux != 0; rutAux /= 10)
        //        {
        //            s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
        //        }
        //        if (dv == (char)(s != 0 ? s + 47 : 75))
        //        {
        //            validacion = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return validacion;
        //}

        //public string formatearRut(string rut)
        //{
        //    int cont = 0;
        //    string format;
        //    if (rut.Length == 0)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        rut = rut.Replace(".", "");
        //        rut = rut.Replace("-", "");
        //        format = "-" + rut.Substring(rut.Length - 1);
        //        for (int i = rut.Length - 2; i >= 0; i--)
        //        {
        //            format = rut.Substring(i, 1) + format;
        //            cont++;
        //            if (cont == 3 && i != 0)
        //            {
        //                format = "." + format;
        //                cont = 0;
        //            }
        //        }
        //        return format;
        //    }
        //}


        public DataSet cargarListaCarrera(string escuela)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();
            if (escuela.Equals("0"))
            {
                conexion.Conec1.IntruccioneSQL = "SELECT DISTINCT [Desc_Carrera] FROM [LK_Carrera] ORDER BY [Desc_Carrera]";
            }
            else
            {
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT DISTINCT [Desc_Carrera] FROM [LK_Carrera] WHERE Id_Escuela = {0} ORDER BY [Desc_Carrera]", escuela);
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }
    }
}

