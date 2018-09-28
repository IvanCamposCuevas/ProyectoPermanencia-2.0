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
    public class NegocioPaginaGlobal : NegocioConexionBD
    {
        /// <summary>
        /// Metodo que devualve una consulta en forma de cadena de caracteres, 
        /// y que sera utilizada en los demas metodos de esta clase.
        /// </summary>
        /// <returns></returns>
        private string consulta() {
            string consulta = "SELECT AL.Desc_Rut_Alumno AS Rut,"
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
                            + " WHERE "
                            + "AL.Id_Alumno = SC.Id_Alumno"
                            + " AND "
                            + "AL.Id_Carrera = CA.Id_Carrera"
                            + " AND "
                            + "CA.Id_Escuela = ES.Id_Escuela"
                            + " AND "
                            + "AL.Id_Sede = SE.Id_Sede"
                            + " AND "
                            + "AL.Id_Jornada = JO.Id_Jornada";

            return consulta;

        }

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
            String auxSQL = String.Empty;
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
            Conexion.IntruccioneSQL = consulta() + auxSQL + " ORDER BY Score, Nombre ASC";

            Conexion.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            Conexion.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return Conexion.DbDat; //Se retornan los datos en un DataSet.
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
            String auxSQL = String.Empty;

            //Aplicar Filtros
            if (!String.IsNullOrEmpty(rn) && valorTipo.Equals("1"))
                auxSQL = auxSQL + " AND AL.Desc_Rut_Alumno = '" + rn + "'";
            else
            {
                auxSQL = auxSQL + " AND AL.Desc_Alumno COLLATE Latin1_General_CI_AI LIKE '%" + rn + "%' COLLATE Latin1_General_CI_AI";
            }
            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            Conexion.IntruccioneSQL = consulta() + auxSQL + " ORDER BY Score, Nombre ASC";

            Conexion.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            Conexion.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return Conexion.DbDat; //Se retornan los datos en un DataSet.
        } // Fin metodo entrega


        

        public DataSet cargarListaCarrera()
        {
            Conexion.IntruccioneSQL = "SELECT DISTINCT [Desc_Carrera], [Id_Escuela] FROM [LK_Carrera] ORDER BY [Desc_Carrera]";
            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }
    }
}

