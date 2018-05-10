using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioFichaAlumno
    {
        string auxSQL = "";
        private System.Data.DataSet consultaAsistencia(string rut)
        {
            NegocioConexionBD con = new NegocioConexionBD();
            con.configuraConexion();

            auxSQL = "WHERE SI.Id_Asignatura = SIG.Id_Asignatura " +
                            "AND SI.Id_Alumno = SC.Id_Alumno " +
                            "AND SI.Id_Alumno = AL.Id_Alumno ";
            if (!string.IsNullOrEmpty(rut))
            {
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "';";
                con.Conec1.IntruccioneSQL = "SELECT SIG.[Cod_Asignatura] AS Cod_Asignatura," +
                                        "SIG.[Desc_Asignatura] AS Nombre_Asigantura," +
                                        "SC.[Cant_Asignaturas]AS Num_Clases_Asistidas," +
                                        "ROUND(SI.[F_Asistencia] * 100, 2, 1) AS Porc_Asistencia," +
                                        "SC.ScoreAsistencia AS Score " + "\n" +
                                        "FROM " +
                                        "Permanencia_2.dbo.Score_Alumnos SC," +
                                        "Permanencia_2.dbo.[FT_Asistencia] SI," +
                                        "Permanencia_2.dbo.[LK_Asignatura] SIG," +
                                        "Permanencia_2.dbo.LK_Alumno AL" + "\n" +
                                        auxSQL;

                con.Conec1.EsSelect = true;
                con.Conec1.conectar();

            }
            return con.Conec1.DbDat;
        }

        private System.Data.DataSet consultaNota(string rut)
        {
            NegocioConexionBD con = new NegocioConexionBD();
            con.configuraConexion();

            auxSQL = "WHERE NA.Id_Asignatura = SIG.Id_Asignatura " +
                            "AND NA.Id_Alumno = SC.Id_Alumno " +
                            "AND NA.Id_Alumno = AL.Id_Alumno ";

            if (!string.IsNullOrEmpty(rut))
            {
                auxSQL += "AND AL.Desc_Rut_Alumno = '" + rut + "';";
                con.Conec1.IntruccioneSQL = "SELECT SIG.[Cod_Asignatura] AS Cod_Asignatura," +
                                             "SIG.[Desc_Asignatura] AS Nombre_Asigantura," +
                                             "NA.[F_Notas_Rendidas] AS Notas_Rendidas," +
                                             "ROUND(NA.[F_Promedio], 1) AS Promedio," +
                                             "SC.ScoreNotas AS Score " + "\n" +
                                             "FROM " +
                                             "Permanencia_2.dbo.Score_Alumnos SC," +
                                             "Permanencia_2.dbo.[FT_Nota_Asistencia] NA," +
                                             "Permanencia_2.dbo.[LK_Asignatura] SIG," +
                                             "Permanencia_2.dbo.LK_Alumno AL" + "\n" +
                                             auxSQL;

                con.Conec1.EsSelect = true;
                con.Conec1.conectar();
            }
            return con.Conec1.DbDat;
        }

        public void consultaGeneral(string rut, out System.Data.DataSet datosNotas, out System.Data.DataSet datosAsistencia) {
            datosNotas = consultaNota(rut);
            datosAsistencia = consultaAsistencia(rut);
        }
    }
}
