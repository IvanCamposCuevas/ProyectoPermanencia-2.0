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
                auxSQL = string.Format(" AND C.Id_Caso = {0}",busqueda);
            }
            if (tipoBusqueda.Equals("2"))
            {
                auxSQL = string.Format(" AND A.Cod_Asignatura = {0}", busqueda);
            }
            if (tipoBusqueda.Equals("3"))
            {
                auxSQL = string.Format(" AND L.Desc_Rut_Alumno = {0}", busqueda);
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
                                            +"dbo.Caso C,"
                                            +"dbo.Tipo_Caso TC,"
                                            +"dbo.LK_Asignatura A,"
                                            +"dbo.LK_Alumno L,"
                                            +"dbo.Estado_Caso EC "
                                            +"WHERE "
                                            +"C.Id_TipoCaso = TC.Id_TipoCaso "
                                            +"AND "
                                            +"C.Id_Estado = EC.Id_Estado "
                                            +"AND "
                                            +"C.Id_Alumno = L.Id_Alumno "
                                            +"AND "
                                            +"C.Id_Asignatura = A.Id_Asignatura"+auxSQL;
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }
    }
}
