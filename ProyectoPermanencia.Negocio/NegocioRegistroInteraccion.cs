using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    //Clase que interactúa con la pagina que registra las interacciones. CRUD.
    public class NegocioRegistroInteraccion
    {
        //Metodo que carga DDL de cursos (ramo-sección) en los que está inscrito el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet cargarddlCurso(string rutAlumno)
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            //validar que rut no llegue vacío
            if (!String.IsNullOrEmpty(rutAlumno))
            {
                //Consulta
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT DISTINCT CONCAT([CODIGO ASIGNATURA],' - ', SECCION) AS CURSO FROM Curso_STG WHERE [RUT ALUMNO] = '{0}';", rutAlumno);
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        //Metodo que carga DDL de tipo de caso que se puede abrir
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet cargarddlTipoCaso()
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            conexion.Conec1.IntruccioneSQL = "SELECT Id_TipoCaso, Desc_TipoCaso FROM Tipo_Caso;";
            
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        //Metodo que carga DDL de tipo de interaccion que se puede ingresar a los casos
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet cargarddlTipoInteraccion()
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            conexion.Conec1.IntruccioneSQL = "SELECT Id_TipoInteraccion, Desc_TipoInteraccion FROM Tipo_Interaccion;";

            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }


        //Cargar DDL casos que tiene activos el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        //--- QUERY MALA, ERROR DE SINTAXIS ---
        /*
        public DataSet cargarddlCasos(string rutAlumno)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            if (!String.IsNullOrEmpty(rutAlumno))
            {
                conexion.Conec1.IntruccioneSQL = 
                    String.Format("SELECT DISTINCT" 
                                    + "CONCAT (CONVERT (nvarchar ,CONVERT(date, CA.Fecha_Inicio), 103), ' - ' ," 
                                            + "TC.Desc_TipoCaso, ' - '," 
                                            + "CASE TC.Id_TipoCaso" 
                                                + "WHEN '1' THEN CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion)" 
                                                + "WHEN '3' THEN CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion)" 
                                                + "ELSE 'No aplica'" 
                                            + "END) AS 'CASO'" + "\n"

                                + "FROM Caso CA," 
                                    + "LK_Alumno AL," 
                                    + "LK_Asignatura ASI," 
                                    + "Tipo_Caso TC," 
                                    + "Estado_Caso EC" + "\n"
                                
                                + "WHERE CA.Id_Alumno = AL.Id_Alumno" 
                                    + "AND CA.Id_TipoCaso = TC.Id_TipoCaso" 
                                    + "AND CA.Id_Estado = EC.Id_Estado" 
                                    + "AND(CA.Id_Asignatura = ASI.Id_Asignatura OR CA.Id_Asignatura IS NULL)"
                                    + "AL.Desc_Rut_Alumno = '{0}';", rutAlumno);
            }
            conexion.Conec1.EsSelect = false;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }
        */

        //Cargar grv de prueba con casos que tiene activos el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        //--- QUERY MALA, ERROR DE SINTAXIS ---
        public DataSet cargarddlCasos(string rutAlumno)
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            //validar que rut no llegue vacío
            if (!String.IsNullOrEmpty(rutAlumno))
            {
                //Consulta
                conexion.Conec1.IntruccioneSQL = 
                    String.Format("SELECT DISTINCT CONCAT(CONVERT(nvarchar, CONVERT(date, CA.Fecha_Inicio), 103), ' - '," +
                                                        "TC.Desc_TipoCaso, ' - '," +
                                                        "CASE TC.Id_TipoCaso" +
                                                            "WHEN '1' THEN CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion)" +
                                                            "WHEN '3' THEN CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion)" +
                                                            "ELSE 'No aplica'" +
                                                        "END) AS 'CASO'" + "\n" +
                                    "FROM Caso CA," +
                                            "LK_Alumno AL," +
                                            "LK_Asignatura ASI," +
                                            "Tipo_Caso TC," +
                                            "Estado_Caso EC" + "\n" +
                                    "WHERE CA.Id_Alumno = AL.Id_Alumno" +
                                            "AND CA.Id_TipoCaso = TC.Id_TipoCaso" +
                                            "AND CA.Id_Estado = EC.Id_Estado" +
                                            "AND(CA.Id_Asignatura = ASI.Id_Asignatura OR CA.Id_Asignatura IS NULL)" +
                                            "AND AL.Desc_Rut_Alumno = '{0}'; ", rutAlumno);
            
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }


    }
}
