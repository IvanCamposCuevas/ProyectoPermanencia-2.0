using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    /// <summary>
    /// Clase que servira para la Pagina FichaAlumno.aspx, y que servira para consultar y traer la informacion
    /// de un Alumno en especifico y llenar las Grillas de la Pagina Web.
    /// </summary>
    public class NegocioFichaAlumno
    {
        string auxSQL = ""; // variable string que servira para intruducir la Query en varios de los metodos dentro de esta clase
        /// <summary>
        /// Metodo que servira para obtener los datos  de la Asistencia de los alumnos dentro de la 
        /// Base de Datos. Retornara un DataSet con todos los datos consultados.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private System.Data.DataSet consultaAsistencia(string rut)
        {
            NegocioConexionBD con = new NegocioConexionBD(); //Instancia La Clase NegocioConexionBD
            con.configuraConexion();

            /*
             *  Se unen las tablas que deben ser usadas para efecuar la consulta
             * */
            auxSQL = "WHERE SI.Id_Asignatura = SIG.Id_Asignatura " +
                            "AND SI.Id_Alumno = SC.Id_Alumno " +
                            "AND SI.Id_Alumno = AL.Id_Alumno ";
            if (!string.IsNullOrEmpty(rut))
            {
                /*
                 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
                 * en la base de datos con el ingresado en el parametro de entrada.
                 * */
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "';";
                /*
                 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
                 * que incluye los las uniones y filtros correspondientes.
                 * */
                con.Conec1.IntruccioneSQL = "SELECT SIG.[Cod_Asignatura] AS 'Codigo Asignatura'," +
                                        "SIG.[Desc_Asignatura] AS 'Nombre Asignatura'," +
                                        "SC.[Cant_Asignaturas]AS 'N° Clases Asistidas'," +
                                        "ROUND(SI.[F_Asistencia] * 100, 2, 1) AS 'Porcentaje Asistencia'," +
                                        "SC.ScoreAsistencia AS 'Score' " + "\n" +
                                        "FROM " +
                                        "Permanencia_2.dbo.Score_Alumnos SC," +
                                        "Permanencia_2.dbo.[FT_Asistencia] SI," +
                                        "Permanencia_2.dbo.[LK_Asignatura] SIG," +
                                        "Permanencia_2.dbo.LK_Alumno AL" + "\n" +
                                        auxSQL;

                con.Conec1.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                con.Conec1.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
                
            }
            return con.Conec1.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.
        }

        /// <summary>
        /// Metodo que servira para obtener los datos de las Notas de los alumnos dentro de la 
        /// Base de Datos. Retornara un DataSet con todos los datos consultados.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>

        private System.Data.DataSet consultaNota(string rut)
        {
            NegocioConexionBD con = new NegocioConexionBD(); // Instancia La Clase NegocioConexionBD
            con.configuraConexion();

            /*
             *  Se unen las tablas que deben ser usadas para efecuar la consulta
             * */
            auxSQL = "WHERE NA.Id_Asignatura = SIG.Id_Asignatura " +
                            "AND NA.Id_Alumno = SC.Id_Alumno " +
                            "AND NA.Id_Alumno = AL.Id_Alumno ";


            if (!string.IsNullOrEmpty(rut))
            {
                /*
                 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
                 * en la base de datos con el ingresado en el parametro de entrada.
                 * */
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "';";
                /*
                 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
                 * que incluye los las uniones y filtros correspondientes.
                 * */
                con.Conec1.IntruccioneSQL = "SELECT SIG.[Cod_Asignatura] AS 'Codigo Asignatura'," +
                                             "SIG.[Desc_Asignatura] AS 'Nombre Asigantura'," +
                                             "NA.[F_Notas_Rendidas] AS 'Notas Rendidas'," +
                                             "ROUND(NA.[F_Promedio], 1) AS 'Promedio'," +
                                             "SC.ScoreNotas AS 'Score' " + "\n" +
                                             "FROM " +
                                             "Permanencia_2.dbo.Score_Alumnos SC," +
                                             "Permanencia_2.dbo.[FT_Nota_Asistencia] NA," +
                                             "Permanencia_2.dbo.[LK_Asignatura] SIG," +
                                             "Permanencia_2.dbo.LK_Alumno AL" + "\n" +
                                             auxSQL;

                con.Conec1.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                con.Conec1.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
            }
            return con.Conec1.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.
        }

        private System.Data.DataSet consultaSituacionFinanciera(string rut)
        {
            NegocioConexionBD con = new NegocioConexionBD(); // Instancia La Clase NegocioConexionBD
            con.configuraConexion();

            /*
             *  Se unen las tablas que deben ser usadas para efecuar la consulta
             * */
            auxSQL = " WHERE AL.Id_Alumno = SC.Id_Alumno ";


            if (!string.IsNullOrEmpty(rut))
            {
                /*
                 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
                 * en la base de datos con el ingresado en el parametro de entrada.
                 * */
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "';";
                /*
                 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
                 * que incluye los las uniones y filtros correspondientes.
                 * */
                con.Conec1.IntruccioneSQL = "SELECT AL.Desc_Rut_Alumno AS 'Rut',"+
       "AL.Desc_Alumno AS 'Nombre',"+
	   "SC.Monto_Deuda AS 'Monto Deuda',"+
	   "SC.Cant_Deuda AS 'Cantidad Deuda',"+
	   "SC.ScoreDeuda AS 'Score' "+

" FROM "+
     "Permanencia_2.dbo.Score_Alumnos SC,"+
     "Permanencia_2.dbo.LK_Alumno AL "+ auxSQL;

                con.Conec1.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                con.Conec1.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
            }
            return con.Conec1.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.

        }

        /// <summary>
        /// Metodo que actuara como rutina para los demas funciones de la misma clase. El metodo
        /// funcionara para consultar el historial tanto de las Notas, Las Asistencias y la situacion financiera de un
        /// alumno en particular.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="datosNotas"></param>
        /// <param name="datosAsistencia"></param>
        public void consultaGeneral(string rut, out System.Data.DataSet datosNotas, out System.Data.DataSet datosAsistencia ,out System.Data.DataSet datosMorosos) {
            datosNotas = consultaNota(rut);
            datosAsistencia = consultaAsistencia(rut);
            datosMorosos = consultaSituacionFinanciera(rut);
        }
    }
}
