using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ProyectoPermanencia.DTO;
namespace ProyectoPermanencia.Negocio
{
    //Clase que interactúa con la pagina que registra las interacciones. CRUD.
    public class NegocioRegistroInteraccion : NegocioConexionBD
    {
        //Metodo que carga DDL de cursos (ramo-sección) en los que está inscrito el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet CargarddlCurso(string rutAlumno)
        {
            //Instancia conexión

            //validar que rut no llegue vacío
            if (!String.IsNullOrEmpty(rutAlumno))
            {
                //Consulta
                Conexion.IntruccioneSQL = String.Format("SELECT DISTINCT ASI.Id_Asignatura, CONCAT(CU.[CODIGO ASIGNATURA],' - ', CU.SECCION) AS CURSO FROM Curso_STG CU, LK_Asignatura ASI WHERE [RUT ALUMNO] = '{0}' AND CU.[CODIGO ASIGNATURA] = ASI.Cod_Asignatura AND CU.SECCION = ASI.Seccion;", rutAlumno);
            }
            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }

        ////Metodo que carga DDL de tipo de caso que se puede abrir
        ////(return) "arreglo" DataSet con información de resultado de la query
        //public DataSet CargarddlTipoCaso()
        //{
        //    //Instancia conexión
        //    NegocioConexionBD conexion = new NegocioConexionBD();
        //    conexion.configuraConexion();

        //    conexion.Conec1.IntruccioneSQL = "SELECT Id_TipoCaso, Desc_TipoCaso FROM Tipo_Caso;";

        //    conexion.Conec1.EsSelect = true;
        //    conexion.Conec1.conectar();
        //    return conexion.Conec1.DbDat;
        //}

        ////Metodo que carga DDL de tipo de interaccion que se puede ingresar a los casos
        ////(return) "arreglo" DataSet con información de resultado de la query
        //public DataSet CargarddlTipoInteraccion()
        //{
        //    //Instancia conexión
        //    NegocioConexionBD conexion = new NegocioConexionBD();
        //    conexion.configuraConexion();

        //    conexion.Conec1.IntruccioneSQL = "SELECT Id_TipoInteraccion, Desc_TipoInteraccion FROM Tipo_Interaccion;";

        //    conexion.Conec1.EsSelect = true;
        //    conexion.Conec1.conectar();
        //    return conexion.Conec1.DbDat;
        //}

        //Cargar DDL casos que tiene activos el alumno
        //(param) string con el rut del alumno
        //(return) "arreglo" DataSet con información de resultado de la query
        public DataSet CargarddlCasos(string rutAlumno)
        {

            if (!String.IsNullOrEmpty(rutAlumno))
            {
                Conexion.IntruccioneSQL =
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
            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }

        //Método que crea el caso, sin asignarle una intervención aún
        //(param) rut del alumno, tipo de caso y id del curso
        public bool CreaCaso(string rutalumno, string tipo, string idcurso)
        {
            //Si el rut viene con información
            if (!String.IsNullOrEmpty(rutalumno))
            {

                //Consulta para traer el id del alumno por su rut
                Conexion.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rutalumno);

                Conexion.EsSelect = true;
                Conexion.conectar();
                string idalumno = Conexion.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();

                //Insert de caso Asistencia/Noas 
                if ((!String.IsNullOrEmpty(tipo)) && (!String.IsNullOrEmpty(idcurso)))
                {
                    Conexion.IntruccioneSQL = String.Format("INSERT INTO Caso (Fecha_Inicio, Id_Alumno, Id_Asignatura, Id_TipoCaso, Id_Estado) VALUES (SYSDATETIME(), {0}, {1}, {2}, 1)", idalumno, idcurso, tipo);
                    Conexion.EsSelect = false;
                    Conexion.conectar();
                    return true;
                }
                //Insert de caso finanzas
                else if ((!String.IsNullOrEmpty(tipo)) && (String.IsNullOrEmpty(idcurso)))
                {
                    Conexion.IntruccioneSQL = String.Format("INSERT INTO Caso (Fecha_Inicio, Id_Alumno, Id_TipoCaso, Id_Estado) VALUES (SYSDATETIME(), {0}, {1}, 1)", idalumno, tipo);
                    Conexion.EsSelect = false;
                    Conexion.conectar();
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

        //Metodo que cambia el estado del caso de pendiente a en curso
        //(param) id del caso a iniciar
        private bool iniciarCaso(string idCaso)
        {
            if (!String.IsNullOrEmpty(idCaso))
            {

                //Query cambia id_estadoCaso, no elimina el caso.
                Conexion.IntruccioneSQL = String.Format("UPDATE Caso SET Id_Estado = '2' WHERE Id_Caso = '{0}'", idCaso);

                Conexion.EsSelect = false;
                Conexion.conectar();
                return true;
            }

            return false;
        }
        //Método que crea la interaccion asociada al caso elegido anteriormente
        //(param) rut del alumno y el id del caso
        public bool AgregaInteraccion(string rutAlumno, string idCaso, string tipoInter, string idArea, string comentarios, DataTable participantes, DateTime fecha, string ruta)
        {
            try
            {

                Conexion.IntruccioneSQL = "prc_InsertarInteraccion";
                DTOInteraccion datosInteraccion = new DTOInteraccion();
                datosInteraccion.rutAlumno = rutAlumno;
                datosInteraccion.tipoInteraccion = int.Parse(tipoInter);
                datosInteraccion.idCaso = int.Parse(idCaso);
                if (idArea != null)
                {
                    datosInteraccion.idArea = int.Parse(idArea);
                }
                datosInteraccion.comentarios = comentarios;
                datosInteraccion.participantes = participantes;
                datosInteraccion.fechaInteraccion = fecha;
                if (ruta != "")
                {
                    datosInteraccion.rutaArchivo = ruta;
                }else
                {
                    datosInteraccion.rutaArchivo = string.Empty;
                }
                Conexion.conectarProcInsertarInteraccion(datosInteraccion);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error, mensaje: ",ex);
            }

        }

        //Metodo que carga Check Box List con Participantes de una interaccion
        //(return) "arreglo" DataSet con información de resultado de la query
        //public DataSet cargarckbxParticipante()
        //{
        //    //Instancia conexión
        //    NegocioConexionBD conexion = new NegocioConexionBD();
        //    conexion.configuraConexion();

        //    conexion.Conec1.IntruccioneSQL = "SELECT Id_Participante, Desc_Participante FROM Participante ORDER BY Desc_Participante ASC;";

        //    conexion.Conec1.EsSelect = true;
        //    conexion.Conec1.conectar();
        //    return conexion.Conec1.DbDat;
        //}
        
        public void EnviarMail(MailMessage mensaje)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("permanenciamail@gmail.com", "perma123.nencia456");
            client.Send(mensaje);
        }

        public string UltimoCaso(string rutalumno)
        {

            //Consulta para traer el id del alumno por su rut
            Conexion.IntruccioneSQL = String.Format("SELECT Id_Alumno FROM LK_Alumno WHERE Desc_Rut_Alumno = '{0}';", rutalumno);
            Conexion.EsSelect = true;
            Conexion.conectar();
            string idalumno = Conexion.DbDat.Tables[0].Rows[0]["Id_Alumno"].ToString();

            //Consulta para traer el ultimo Id_Caso agregado para el alumno
            Conexion.IntruccioneSQL = String.Format("SELECT MAX(Id_Caso) AS 'Id_Caso' FROM Caso WHERE Id_Alumno = '{0}'", idalumno);            
            Conexion.EsSelect = true;
            Conexion.conectar();
            string idcaso = Conexion.DbDat.Tables[0].Rows[0]["Id_Caso"].ToString();

            return idcaso;
        }

    }
}
