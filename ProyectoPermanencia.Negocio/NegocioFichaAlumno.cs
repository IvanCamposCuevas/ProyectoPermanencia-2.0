using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    /// <summary>
    /// Clase que servira para la Pagina FichaAlumno.aspx, y que servira para consultar y traer la informacion
    /// de un Alumno en especifico y llenar las Grillas de la Pagina Web.
    /// </summary>
    public class NegocioFichaAlumno : NegocioConexionBD
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
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "'" +
                    "ORDER BY SIG.Cod_Asignatura ASC;";
                /*
				 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
				 * que incluye los las uniones y filtros correspondientes.
				 * */
                Conexion.IntruccioneSQL = "SELECT SIG.[Cod_Asignatura] AS 'Codigo Asignatura'," +
                                        "SIG.[Desc_Asignatura] AS 'Nombre Asignatura'," +
                                        "SC.[Cant_Asignaturas]AS 'N° Clases Asistidas'," +
                                        "ROUND(SI.[F_Asistencia] * 100, 2, 1) AS 'Porcentaje Asistencia'," +
                                        "SC.ScoreAsistencia AS 'Score' " + "\n" +
                                        "FROM " +
                                        "dbo.Score_Alumnos SC," +
                                        "dbo.[FT_Asistencia] SI," +
                                        "dbo.[LK_Asignatura] SIG," +
                                        "dbo.LK_Alumno AL" + "\n" +
                                        auxSQL;

                Conexion.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                Conexion.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.

            }
            return Conexion.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.
        }

        /// <summary>
        /// Metodo que servira para obtener los datos de las Notas de los alumnos dentro de la 
        /// Base de Datos. Retornara un DataSet con todos los datos consultados.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private System.Data.DataSet consultaNota(string rut)
        {

            if (!string.IsNullOrEmpty(rut))
            {
                /*
				 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
				 * en la base de datos con el ingresado en el parametro de entrada.
				 * */
                auxSQL += "WHERE [RUT ALUMNO] = '" + rut + "'" +
                          "ORDER BY [CODIGO ASIGNATURA] ASC;";
                /*
				 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
				 * que incluye los las uniones y filtros correspondientes.
				 * */
                Conexion.IntruccioneSQL = "SELECT [CODIGO ASIGNATURA] AS 'Codigo', "+
                                                   "[DESC ASIGNATURA] AS 'Asignatura', " +
                                                   "[SECCION] AS 'Sección', " +
                                                   "[AÑO] AS 'Año', " +
                                                   "[SEMESTRE] AS 'Semestre', " +
                                                   "[Nº NOTAS PARCIALES] AS 'N° de notas parciales', " +
                                                   "[Nº NOTAS EXAMEN] AS 'N° de notas de exámen', " +
                                                   "[PROMEDIO CATEDRA] AS 'Promedio Cátedra', " +
                                                   "[PROMEDIO EXAMEN] AS 'Promedio Exámen', " +
                                                   "[NOTA FINAL] AS 'Nota Final' " +                                                   
                                                   "\n" +
                                                   "FROM " +
                                                   "dbo.Curso_STG" + 
                                                   "\n" +
                                                   auxSQL;

                Conexion.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                Conexion.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
            }
            return Conexion.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.
        }

        /// <summary>
        /// Metodo que devuelve la situacion financiera actual de un Alumno en especifico.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
		private System.Data.DataSet consultaSituacionFinanciera(string rut)
        {
            /*
			 *  Se unen las tablas que deben ser usadas para efecuar la consulta
			 * */
            auxSQL = "WHERE AL.Desc_Rut_Alumno = MO.RUT AND AL.Id_Alumno = SC.Id_Alumno ";

            if (!string.IsNullOrEmpty(rut))
            {
                /*
				 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
				 * en la base de datos con el ingresado en el parametro de entrada.
				 * */

                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "' ORDER BY [Fecha de Vencimiento] DESC;";
                /*
				 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
				 * que incluye los las uniones y filtros correspondientes.
				 * */
                Conexion.IntruccioneSQL = "SELECT replace(convert(NVARCHAR, MO.[Fecha Vencimiento], 106), ' ', '/') " +
                                            "AS 'Fecha de Vencimiento', MO.[Cuota Vencida] AS 'Cuota Vencida', " +
                                            "MO.[Monto Adeudado] AS 'Monto Adeudado', MO.[BENEFICIO] AS 'Beneficio', " + 
                                            "SC.[ScoreDeuda] AS 'Score' "+"\n" +
                                            "FROM " +
                                            "dbo.Morosos_STG MO, " +
                                            "dbo.Score_Alumnos SC, " +
                                            "dbo.LK_Alumno AL " + "\n" +
                                            auxSQL;
                Conexion.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                Conexion.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
            }
            return Conexion.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.

        }

        //Metodo que trae el detalle de las notas por asignatura de un alumno
        //(param) rut
        //(return) "arreglo" DataSet con resultado de la consulta
        public System.Data.DataSet consultaDetNotas(string rut)
        {
            if (!string.IsNullOrEmpty(rut))
            {
                /*
				 * La consulta es filtrada segun las coincidencias que hay entre los Ruts encontrados 
				 * en la base de datos con el ingresado en el parametro de entrada.
				 * */

                auxSQL= "WHERE [RUT ALUMNO] = '" + rut + "' ORDER BY [CODIGO ASIGNATURA] ASC;";
                /*
				 * Se ingresa toda la Query para la consulta, incluyendo la variable auxSQL, 
				 * que incluye los las uniones y filtros correspondientes.
				 * */
                Conexion.IntruccioneSQL = "SELECT [CODIGO ASIGNATURA]," +
                                            "[DESC ASIGNATURA] AS 'NOMBRE ASIGNATURA', "+
                                            "[SEMESTRE], " +
                                            "[Nº NOTAS PARCIALES], " +
                                            "[Nº NOTAS EXAMEN], " +
                                            "[C1], " +
                                            "[C2], " +
                                            "[C3], " +
                                            "[C4], " +
                                            "[C5], " +
                                            "[C6], " +
                                            "[C7], " +
                                            "[C8], " +
                                            "[C9], " +
                                            "[C10], " +
                                            "[C11], " +
                                            "[C12], " +
                                            "[C13], " +
                                            "[C14], " +
                                            "[C15], " +
                                            "[C16], " +
                                            "[C17], " +
                                            "[C18], " +
                                            "[C19], " +
                                            "[C20], " +
                                            "[E1], " +
                                            "[E2], " +
                                            "[E3], " +
                                            "[PROMEDIO CATEDRA], " +
                                            "[PROMEDIO EXAMEN], " +
                                            "[NOTA FINAL]" +
                                            "\n" +
                                            "FROM " +
                                            "dbo.Curso_STG" +
                                            "\n" +
                                            auxSQL;
                Conexion.EsSelect = true; //Si la query consultada es una Consulta (SELECT...) se ingresa como TRUE.
                Conexion.conectar(); //Se ejecuta el metodo "conectar()" de la clase NegocioConexionBD.
            }
            return Conexion.DbDat; //Se retorna el DataSet generado luego de ser llenado por la consulta.

        }

        /// <summary>
        /// Metodo que actuara como rutina para los demas funciones de la misma clase. El metodo
        /// funcionara para consultar el historial tanto de las Notas, Las Asistencias y la situacion financiera de un
        /// alumno en particular.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="datosNotas"></param>
        /// <param name="datosAsistencia"></param>
        public void consultaGeneral(string rut, out System.Data.DataSet datosNotas, out System.Data.DataSet datosDetalleNotas, out System.Data.DataSet datosAsistencia, 
            out System.Data.DataSet datosMorosos, out System.Data.DataSet scores)
        {
            datosNotas = consultaNota(rut);
            datosDetalleNotas = consultaDetNotas(rut);
            datosAsistencia = consultaAsistencia(rut);
            datosMorosos = consultaSituacionFinanciera(rut);
            scores = scoresGrillas(rut);
        }

        //Cargar grilla con display de los casos que tiene activos el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet CargargrvCasos(string rutAlumno)
        {

            //validar que rut no llegue vacío
            if (!String.IsNullOrEmpty(rutAlumno))
            {
                //Consulta para traer el id del alumno por su rut
                Conexion.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rutAlumno);
                Conexion.EsSelect = true;
                Conexion.conectar();
                string idalumno = Conexion.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();


                //Consulta que trae información de los casos a desplegar
                Conexion.IntruccioneSQL = String.Format("SELECT DISTINCT CA.Id_Caso AS 'Id', CONVERT(nvarchar, CONVERT(date, CA.Fecha_Inicio), 103) AS 'Fecha Inicio', TC.Desc_TipoCaso AS 'Tipo de Caso', IIF((TC.Id_TipoCaso = 1) OR(TC.Id_TipoCaso = 3), CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion), 'No aplica') AS 'Curso', INTE.Id_Interaccion AS 'Id interaccion', CONCAT('Tipo: ', TI.Desc_TipoInteraccion, ', el día ', CONVERT(nvarchar, CONVERT(date, INTE.Fecha_Interaccion), 103)) AS 'Ultima Interacción', EC.Desc_Estado AS 'Estado del Caso', CA.Fecha_Termino AS 'Fecha Termino' FROM Caso CA, Tipo_Caso TC, LK_Asignatura ASI, Estado_Caso EC, Tipo_Interaccion TI INNER JOIN Interaccion INTE ON Id_Caso = INTE.Id_Caso WHERE CA.Id_Alumno = '{0}' AND CA.Id_TipoCaso = TC.Id_TipoCaso AND(CA.Id_Asignatura = ASI.Id_Asignatura OR CA.Id_Asignatura IS NULL) AND CA.Id_Estado = EC.Id_Estado AND INTE.Id_TipoInteraccion = TI.Id_TipoInteraccion AND INTE.Id_Interaccion = (SELECT MAX(Id_Interaccion) FROM Interaccion INTE WHERE INTE.Id_Caso = CA.Id_Caso) GROUP BY INTE.Id_Interaccion, CA.Id_Caso, CA.Fecha_Inicio, TC.Id_TipoCaso, TC.Desc_TipoCaso, ASI.Cod_Asignatura,	ASI.Seccion, EC.Desc_Estado, CA.Fecha_Termino, TI.Desc_TipoInteraccion, INTE.Fecha_Interaccion", idalumno);
                Conexion.EsSelect = true;
                Conexion.conectar();
            }

            return Conexion.DbDat;
        }


        public DataSet scoresGrillas(string rut)
        {
            if (!string.IsNullOrEmpty(rut))
            {

                /*auxSQL = "WHERE [Id_Alumno] = " + rut;


                Conexion.IntruccioneSQL = "SELECT [ScoreDeuda], " +
                                          "[ScoreNotas], " +
                                          "[ScoreAsistencia], " +
                                          "\n" +
                                          "FROM " +
                                          "dbo.Score_Alumnos" +
                                          "\n" +
                                          auxSQL;*/

                Conexion.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rut);
                Conexion.EsSelect = true;
                Conexion.conectar();
                string idalumno = Conexion.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();


                Conexion.IntruccioneSQL = String.Format("SELECT ScoreDeuda, ScoreAsistencia, ScoreNotas FROM dbo.Score_Alumnos WHERE Id_Alumno= '{0}'",idalumno);
                Conexion.EsSelect = true;
                Conexion.conectar();
            }
            return Conexion.DbDat;
        }
            




    }
}
