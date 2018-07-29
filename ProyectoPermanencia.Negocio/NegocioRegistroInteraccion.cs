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
        public DataSet CargarddlCurso(string rutAlumno)
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            //validar que rut no llegue vacío
            if (!String.IsNullOrEmpty(rutAlumno))
            {
                //Consulta
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT DISTINCT ASI.Id_Asignatura, CONCAT(CU.[CODIGO ASIGNATURA],' - ', CU.SECCION) AS CURSO FROM Curso_STG CU, LK_Asignatura ASI WHERE [RUT ALUMNO] = '{0}' AND CU.[CODIGO ASIGNATURA] = ASI.Cod_Asignatura AND CU.SECCION = ASI.Seccion;", rutAlumno);
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        //Metodo que carga DDL de tipo de caso que se puede abrir
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet CargarddlTipoCaso()
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
        public DataSet CargarddlTipoInteraccion()
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
        public DataSet CargarddlCasos(string rutAlumno)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            if (!String.IsNullOrEmpty(rutAlumno))
            {
                conexion.Conec1.IntruccioneSQL =
                    String.Format("SELECT DISTINCT CA.Id_Caso, " +
                                                   "CA.Fecha_Inicio AS 'Fecha'," +
                                                   "CONCAT (CONVERT (nvarchar ,CONVERT(date, CA.Fecha_Inicio)), ' - ', " +
                                                       "TC.Desc_TipoCaso, ' - ', " +
                                                       "IIF ((TC.Id_TipoCaso = 1) OR (TC.Id_TipoCaso = 3), " +
                                                       "CONCAT(ASI.Cod_Asignatura, '-', ASI.Seccion), 'No aplica')) " +
                                                   "AS CASO " + "\n" +

                                "FROM Caso CA, " +
                                      "LK_Alumno AL, " +
                                      "LK_Asignatura ASI, " +
                                      "Tipo_Caso TC, " +
                                      "Estado_Caso EC " + "\n" +

                                "WHERE CA.Id_Alumno = AL.Id_Alumno " +
                                       "AND CA.Id_TipoCaso = TC.Id_TipoCaso " +
                                       "AND CA.Id_Estado = EC.Id_Estado " +
                                       "AND (CA.Id_Asignatura = ASI.Id_Asignatura OR CA.Id_Asignatura IS NULL) " +
                                       "AND AL.Desc_Rut_Alumno = '{0}' " +
                                       "ORDER BY Fecha DESC;", rutAlumno);
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        //Método que crea el caso, sin asignarle una intervención aún
        //(param) rut del alumno, tipo de caso y id del curso
        public bool CreaCaso(string rutalumno, string tipo, string idcurso)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();


            //Si el rut viene con información
            if (!String.IsNullOrEmpty(rutalumno))
            {

                //Consulta para traer el id del alumno por su rut
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rutalumno);

                conexion.Conec1.EsSelect = true;
                conexion.Conec1.conectar();
                string idalumno = conexion.Conec1.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();

                //Insert de caso Asistencia/Noas 
                if ((!String.IsNullOrEmpty(tipo)) && (!String.IsNullOrEmpty(idcurso)))
                {
                    conexion.Conec1.IntruccioneSQL = String.Format("INSERT INTO Caso (Fecha_Inicio, Id_Alumno, Id_Asignatura, Id_TipoCaso, Id_Estado) VALUES (SYSDATETIME(), {0}, {1}, {2}, 1)", idalumno, idcurso, tipo);
                    conexion.Conec1.EsSelect = false;
                    conexion.Conec1.conectar();
                    return true;
                }
                //Insert de caso finanzas
                else if ((!String.IsNullOrEmpty(tipo)) && (String.IsNullOrEmpty(idcurso)))
                {
                    conexion.Conec1.IntruccioneSQL = String.Format("INSERT INTO Caso (Fecha_Inicio, Id_Alumno, Id_TipoCaso, Id_Estado) VALUES (SYSDATETIME(), {0}, {1}, 1)", idalumno, tipo);
                    conexion.Conec1.EsSelect = false;
                    conexion.Conec1.conectar();
                    return true;
                }
                else
                {
                    return false;
                    throw new ArgumentNullException(nameof(tipo));
                    throw new ArgumentNullException(nameof(idcurso));
                }
            }
            else
            {
                return false;
                throw new ArgumentNullException(nameof(rutalumno));
            }
        }

        //Método que crea la interaccion asociada al caso elegido anteriormente
        //(param) rut del alumno y el id del caso
        public bool AgregaInteraccion(string rutalumno, string idcaso, string tipointer, string idarea, string comentarios, string participantes)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();


            //Si el rut viene con información
            if (!String.IsNullOrEmpty(rutalumno))
            {

                //Consulta para traer el id del alumno por su rut
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rutalumno);
                conexion.Conec1.EsSelect = true;
                conexion.Conec1.conectar();
                string idalumno = conexion.Conec1.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();

                //Insert de interaccion derivacion 
                if ((!String.IsNullOrEmpty(idcaso)) && (!String.IsNullOrEmpty(tipointer)) && (!String.IsNullOrEmpty(idarea)) && (!String.IsNullOrEmpty(comentarios)) && (!String.IsNullOrEmpty(participantes)))
                {
                    conexion.Conec1.IntruccioneSQL = String.Format("INSERT INTO Interaccion (Fecha_Interaccion, Desc_Comentario, Participantes, Id_Caso, Id_AreaDerivacion, Id_TipoInteraccion, Id_EstadoInteraccion, Id_Alumno) " +
                                                                                    "VALUES(SYSDATETIME(), '{0}', '{1}', {2}, {3}, {4}, 1, {5})", comentarios, participantes, idcaso, idarea, tipointer, idalumno);
                    conexion.Conec1.EsSelect = false;
                    conexion.Conec1.conectar();
                    return true;
                }
                //Insert de interaccion no derivacion
                else if ((!String.IsNullOrEmpty(idcaso)) && (!String.IsNullOrEmpty(tipointer)) && (String.IsNullOrEmpty(idarea)) && (!String.IsNullOrEmpty(comentarios)) && (!String.IsNullOrEmpty(participantes)))
                {
                    conexion.Conec1.IntruccioneSQL = String.Format("INSERT INTO Interaccion (Fecha_Interaccion, Desc_Comentario, Participantes, Id_Caso, Id_TipoInteraccion, Id_EstadoInteraccion, Id_Alumno) " +
                                                                                    "VALUES(SYSDATETIME(), '{0}', '{1}', {2}, {3}, 1, {4})", comentarios, participantes, idcaso, tipointer, idalumno);
                    conexion.Conec1.EsSelect = false;
                    conexion.Conec1.conectar();
                    return true;
                }
                else
                {
                    return false;
                    throw new ArgumentNullException(nameof(idcaso));
                    throw new ArgumentNullException(nameof(tipointer));
                    throw new ArgumentNullException(nameof(comentarios));

                }
            }
            else
            {
                throw new ArgumentNullException(nameof(rutalumno));
            }
        }

        //Metodo que carga Check Box List con Participantes de una interaccion
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet cargarckbxParticipante()
        {
            //Instancia conexión
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            conexion.Conec1.IntruccioneSQL = "SELECT Id_Participante, Desc_Participante FROM Participante ORDER BY Desc_Participante ASC;";

            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }


    }
}
