using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioDetalleCaso
    {
        private string consultaDetalleCaso() {

            string query = "SELECT I.Desc_Comentario AS 'Comentario',"
                            + "I.Fecha_Interaccion AS 'Fecha Interaccion', "
                            + "TI.Desc_TipoInteraccion AS 'Tipo Interaccion',"
                            + "A.Desc_AreaDerivacion AS 'Area Derivacion',"
                            + "STUFF ((SELECT ',' + P.Desc_Participante "
                            + "FROM Participante P "
                            + "LEFT JOIN "
                            + "Paricipante_Interaccion PI "
                            + "ON "
                            + "PI.Id_Participante = P.Id_Participante "
                            + "WHERE "
                            + "PI.Id_Interaccion = I.Id_Interaccion FOR XML PATH('')),1,1,'') AS 'Participantes' "
                            + "FROM Interaccion I "
                            + "LEFT JOIN "
                            + "Tipo_Interaccion TI "
                            + "ON "
                            + "I.Id_TipoInteraccion = TI.Id_TipoInteraccion "
                            + "LEFT JOIN "
                            + "Area_Derivacion A "
                            + "ON "
                            + "I.Id_AreaDerivacion = A.Id_AreaDerivacion ";

            return query;

        }

        public System.Data.DataSet obtenerDetalleInteraccion(int idCaso)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            conexion.Conec1.IntruccioneSQL = consultaDetalleCaso() +
                            " WHERE I.Id_Caso = "+idCaso;

            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }


        public bool finalizaCaso(string idCaso)
        {
            if (!String.IsNullOrEmpty(idCaso))
            {
                NegocioConexionBD conexion = new NegocioConexionBD();
                conexion.configuraConexion();

                //Query cambia id_estadoCaso, para pasar de pendiente a finalizado, no elimina el caso.
                conexion.Conec1.IntruccioneSQL = String.Format("UPDATE Caso SET Id_Estado = '3' WHERE Id_Caso = '{0}'", idCaso);

                conexion.Conec1.EsSelect = false;
                conexion.Conec1.conectar();
                return true;
            }

            return false;
        }

    }
}
