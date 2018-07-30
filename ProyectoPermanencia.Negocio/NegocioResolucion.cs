using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioResolucion
    {
        /// <summary>
        /// Retorna la parte principal de la consulta
        /// </summary>
        /// <returns></returns>
        private String consulta() {

            string instruccionSQL = "SELECT * FROM "
                                    + "("
                                    + "SELECT C.Id_Caso AS 'ID',"
                                    + "TC.Desc_TipoCaso AS 'Caso',"
                                    + "A.Cod_Asignatura AS 'Curso',"
                                    + "L.Desc_Rut_Alumno AS 'Rut Alumno',"
                                    + "L.Desc_Alumno AS 'Nombre Alumno',"
                                    + "L.Desc_Correo_Inst AS 'Correo',"
                                    + "L.Desc_Telefono_Alumno AS 'Telefono',"
                                    + "CA.Desc_Carrera AS 'Carrera',"
                                    + "E.Desc_Escuela AS 'Escuela',"
                                    + "J.Desc_Jornada AS 'Jornada',"
                                    + "S.Desc_Sede AS 'Sede',"
                                    + "(SELECT TOP(1) TI.Desc_TipoInteraccion "
                                    + "FROM "
                                    + "dbo.Interaccion I,"
                                    + "dbo.Tipo_Interaccion TI "
                                    + "WHERE "
                                    + "I.Id_TipoInteraccion = TI.Id_TipoInteraccion "
                                    + "AND "
                                    + "C.Id_Caso = I.Id_Caso "
                                    + "ORDER BY I.Id_Interaccion DESC) AS 'Ultima Intervencion',"
                                    + "CAST (C.Fecha_Inicio AS date) AS 'Fecha inicio',"
                                    + "CAST (C.Fecha_Termino AS date) AS 'Fecha Termino',"
                                    + "EC.Desc_Estado AS 'Estado' "
                                    + "FROM "
                                    + "dbo.Caso C "
                                    + "LEFT JOIN "
                                    + "dbo.Tipo_Caso TC "
                                    + "ON "
                                    + "C.Id_TipoCaso = TC.Id_TipoCaso "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Asignatura A "
                                    + "ON "
                                    + "C.Id_Asignatura = A.Id_Asignatura "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Alumno L "
                                    + "ON "
                                    + "C.Id_Alumno = L.Id_Alumno "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Carrera CA "
                                    + "ON "
                                    + "L.Id_Carrera = CA.Id_Carrera "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Escuela E "
                                    + "ON "
                                    + "CA.Id_Escuela = E.Id_Escuela "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Jornada J "
                                    + "ON "
                                    + "L.Id_Jornada = J.Id_Jornada "
                                    + "LEFT JOIN "
                                    + "dbo.LK_Sede S "
                                    + "ON "
                                    + "L.Id_Sede = S.Id_Sede "
                                    + "LEFT JOIN "
                                    + "dbo.Estado_Caso EC "
                                    + "ON "
                                    + "C.Id_Estado = EC.Id_Estado) base"
                                    + " WHERE ";

            return instruccionSQL;
        }

        /// <summary>
        /// Metodo que retorna una consulta, segun el tipo de busqueda elegido
        /// por el usuario en la pagina.
        /// 
        /// </summary>
        /// <param name="tipoBusqueda"></param>
        /// <param name="busqueda"></param>
        /// <returns></returns>

        public DataSet buscarCasoSinFiltro(string tipoBusqueda, string busqueda) {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();
            string auxSQL ="";
            /**
             * TipoBusqueda = 1; busca por ID
             * TipoBusqueda = 2; busca por el codigo del Curso.
             * TipoBusqueda = 3; busca por el rut de un alumno.
             * */
            if (tipoBusqueda.Equals("1"))
            {
                auxSQL = string.Format(" base.ID = {0}", busqueda);
            }
            if (tipoBusqueda.Equals("2"))
            {
                auxSQL = string.Format(" base.Curso = '{0}'", busqueda);
            }
            if (tipoBusqueda.Equals("3"))
            {
                auxSQL = string.Format(" base.[Rut Alumno] = '{0}'", busqueda);
            }


            conexion.Conec1.IntruccioneSQL = consulta() + auxSQL;
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        /// <summary>
        /// Consulta que retorna una consulta de casos, segun los filtros que alla
        /// elegido la persona en la pagina.
        /// </summary>
        /// <param name="listaCasos"></param>
        /// <param name="listaInvertenciones"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaTermino"></param>
        /// <returns></returns>

        public DataSet buscarCasoConFiltro(List<string> listaCasos, List<string> listaInvertenciones, DateTime fechaInicio, DateTime fechaTermino)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();
            string auxSQL = "";

            #region Filtros
            //Filtro de casos.
            if (listaCasos != null)
            {
                foreach (string item in listaCasos)
                {
                    if (auxSQL == "") //Si el string es vacio, la secuencia comenzara sin un OR o AND,
                                     //de lo contrario, se antepondra esos operadores.
                    {
                        auxSQL += string.Format(" base.Caso = '{0}'", item);
                    }
                    else
                    {
                        auxSQL += string.Format(" OR base.Caso = '{0}'", item);
                    }
                }
            }

            // Filtro del tipo de intervenciones
            if (listaInvertenciones != null)
            {
                foreach (string item in listaInvertenciones)
                {
                    if (auxSQL == "")
                    {
                        auxSQL += string.Format(" base.[Ultima Intervencion] = '{0}'", item);
                    }
                    else
                    {
                        auxSQL += string.Format(" AND base.[Ultima Intervencion] = '{0}'", item);
                    }
                }
            }

            //Filtro de un rango de fechas
            if (!fechaInicio.Equals(new DateTime()) && !fechaTermino.Equals(new DateTime())) //Si los objetos referentes a la fecha de inicio y termino,
                                                                                            //son iguales a los que se instancian por defecto, entonces no seran
                                                                                           //en cuenta para el filtro
            {
                if (auxSQL == "")
                {
                    auxSQL += string.Format(" CONVERT (date, base.[Fecha inicio]) >= '{0}'", fechaInicio);

                    auxSQL += string.Format(" AND CONVERT (date, base.[Fecha Termino]) <= '{0}'", fechaTermino);
                }
                else
                {
                    auxSQL += string.Format(" AND CONVERT (date, base.[Fecha inicio]) >= '{0}'", fechaInicio);

                    auxSQL += string.Format(" AND CONVERT (date, base.[Fecha Termino]) <= '{0}'", fechaTermino);
                }
            }

            #endregion

            conexion.Conec1.IntruccioneSQL = consulta() + auxSQL;
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }
    }
}
