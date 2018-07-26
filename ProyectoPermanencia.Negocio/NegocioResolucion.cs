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

        public DataSet buscarCasoSinFiltro(string tipoBusqueda, string busqueda) {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();
            string auxSQL ="";
            if (tipoBusqueda.Equals("1"))
            {
                auxSQL = string.Format(" C.Id_Caso = {0}",busqueda);
            }
            if (tipoBusqueda.Equals("2"))
            {
                auxSQL = string.Format(" A.Cod_Asignatura = '{0}'", busqueda);
            }
            if (tipoBusqueda.Equals("3"))
            {
                auxSQL = string.Format(" L.Desc_Rut_Alumno = '{0}'", busqueda);
            }


            conexion.Conec1.IntruccioneSQL = "SELECT C.Id_Caso AS 'ID',"
                                            +"TC.Desc_TipoCaso AS 'Caso'," 
                                            +"A.Cod_Asignatura AS 'Curso'," 
                                            +"L.Desc_Rut_Alumno AS 'Rut Alumno',"
                                            +"(SELECT TOP(1) TI.Desc_TipoInteraccion "
                                            +"FROM "
                                            +"dbo.Interaccion I,"
                                            +"dbo.Tipo_Interaccion TI "
                                            +"WHERE "
                                            +"I.Id_TipoInteraccion = TI.Id_TipoInteraccion "
                                            +"AND "
                                            +"C.Id_Caso = I.Id_Caso "
                                            +"ORDER BY I.Id_Interaccion DESC) AS 'Ultima Intervencion',"
                                            +"C.Fecha_Inicio AS 'Fecha inicio',"
                                            +"C.Fecha_Termino AS 'Fecha Termino',"
                                            +"EC.Desc_Estado AS 'Estado' "
                                            +"FROM "
                                            +"dbo.Caso C "
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
                                            + "dbo.Estado_Caso EC "
                                            + "ON " 
                                            + "C.Id_Estado = EC.Id_Estado WHERE " + auxSQL;
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        public DataSet buscarCasoConFiltro(List<string> listaCasos, List<string> listaInvertenciones, DateTime fechaInicio, DateTime fechaTermino)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();
            string auxSQL = "";
            if (listaCasos != null)
            {
                foreach (string item in listaCasos)
                {
                    if (auxSQL == "")
                    {
                        auxSQL += string.Format(" base.Caso = '{0}'", item);
                    }
                    else
                    {
                        auxSQL += string.Format(" OR base.Caso = '{0}'", item);
                    }
                }
            }
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

            if (!fechaInicio.Equals(new DateTime()) && !fechaTermino.Equals(new DateTime()))
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

            

            conexion.Conec1.IntruccioneSQL = "SELECT * FROM "
                                            +"("
                                            + "SELECT C.Id_Caso AS 'ID',"
                                            + "TC.Desc_TipoCaso AS 'Caso',"
                                            + "A.Cod_Asignatura AS 'Curso',"
                                            + "L.Desc_Rut_Alumno AS 'Rut Alumno',"
                                            + "(SELECT TOP(1) TI.Desc_TipoInteraccion "
                                            + "FROM "
                                            + "dbo.Interaccion I,"
                                            + "dbo.Tipo_Interaccion TI "
                                            + "WHERE "
                                            + "I.Id_TipoInteraccion = TI.Id_TipoInteraccion "
                                            + "AND "
                                            + "C.Id_Caso = I.Id_Caso "
                                            + "ORDER BY I.Id_Interaccion DESC) AS 'Ultima Intervencion',"
                                            + "C.Fecha_Inicio AS 'Fecha inicio',"
                                            + "C.Fecha_Termino AS 'Fecha Termino',"
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
                                            + "dbo.Estado_Caso EC "
                                            + "ON "
                                            + "C.Id_Estado = EC.Id_Estado) base" 
                                            +" WHERE " + auxSQL;
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }
    }
}
