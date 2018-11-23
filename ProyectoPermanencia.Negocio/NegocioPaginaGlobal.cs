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
                            + "SC.Score AS Score "
                            + "\n"
                            + " FROM "
                            + "dbo.Score_Alumnos SC,"
                            + "dbo.LK_Alumno AL,"
                            + "dbo.LK_Carrera CA,"
                            + "dbo.LK_Escuela ES,"
                            + "dbo.LK_Sede SE,"
                           // + "dbo.LK_Beneficio BE,"
                           // + "dbo.FT_Deuda DE,"
                            + "dbo.LK_Jornada JO" + "\n"
                            + " WHERE "
                            + "AL.Id_Alumno = SC.Id_Alumno"
                            + " AND "
                            + "AL.Id_Carrera = cast(round(CA.Id_Carrera,0) as varchar(100))"
                            + " AND "
                            + "CA.Id_Escuela = ES.Id_Escuela"
                            + " AND "
                            + "AL.Id_Sede = SE.Id_Sede"
                            + " AND "
                            + "AL.Id_Jornada = JO.Id_Jornada";
                           // + " AND "
                           // + "AL.Id_Alumno = DE.Id_Alumno"
                           // + " AND "
                           // + "DE.Id_Beneficio = BE.Id_Beneficio";

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
        public DataSet ConsultaScorePorFiltro(String sede, String jornada, String escuela, String carrera)
        {
            String auxSQL = String.Empty;
            //Aplicar Filtros
            if (!String.IsNullOrEmpty(sede))
                auxSQL = auxSQL + " AND AL.Id_Sede = '" + sede + "'";
            if (!String.IsNullOrEmpty(jornada))
                auxSQL = auxSQL + " AND AL.Id_Jornada = '" + jornada + "'";
            if (!String.IsNullOrEmpty(escuela) && int.Parse(escuela) >= 1)
                auxSQL = auxSQL + " AND CA.Id_Escuela = '" + escuela + "'";
            if (!String.IsNullOrEmpty(carrera) && int.Parse(carrera) >= 1)
            {
                auxSQL = auxSQL + " AND CA.Id_Carrera = '" + carrera + "'";
            }

            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            Conexion.IntruccioneSQL = consulta() + auxSQL + " ORDER BY Score DESC, Nombre ASC";

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
            Conexion.IntruccioneSQL = consulta() + auxSQL + " ORDER BY Score DESC, Nombre ASC";

            Conexion.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            Conexion.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return Conexion.DbDat; //Se retornan los datos en un DataSet.
        } // Fin metodo entrega


        

        public DataSet cargarListaCarrera(int idescuela)
        {
            Conexion.IntruccioneSQL = "SELECT DISTINCT [Desc_Carrera], [Id_Carrera] FROM [LK_Carrera] WHERE [Id_Escuela] = '" + idescuela + "' ORDER BY [Desc_Carrera] "; //cambio id escuela por id carrera
            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }

        public string colorScore(decimal score)
        {
            string color = "&nbsp &nbsp<p style=color:green;display:inline-block;font-size:30px;><b>•</b></p>";
            if (score >= 0)
            {
                if (score <= 1)
                {
                    color = "&nbsp &nbsp &nbsp<p style=color:green;display:inline-block;font-size:30px;><b>•</b></p>";
                }
                else if(score >1 && score <= 2)
                {
                    color = "&nbsp &nbsp &nbsp<p style=color:#f4e80c;display:inline-block;font-size:30px;><b>•</b></p>";
                }
                else if( score>2 && score <=3)
                {
                    color = "&nbsp &nbsp &nbsp<p style=color:red;display:inline-block;font-size:30px;><b>•</b></p>";
                }
            }
            return color;
        }
    }
}

