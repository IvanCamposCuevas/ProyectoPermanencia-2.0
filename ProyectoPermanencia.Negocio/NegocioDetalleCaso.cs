using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioDetalleCaso : NegocioConexionBD
    {
        private string consultaDetalleCaso() {

            string query = "SELECT I.Desc_Comentario AS 'Comentario',"
                            + "I.Fecha_Interaccion AS 'Fecha Interaccion', "
                            + "TI.Desc_TipoInteraccion AS 'Tipo Interaccion',"
                            + "A.Desc_AreaDerivacion AS 'Area Derivacion',"
                            + "STUFF ((SELECT ',' + P.Desc_Participante "
                            + "FROM Participante P "
                            + "LEFT JOIN "
                            + "Participante_Interaccion PI "
                            + "ON "
                            + "PI.Id_Participante = P.Id_Participante "
                            + "WHERE "
                            + "PI.Id_Interaccion = I.Id_Interaccion FOR XML PATH('')),1,1,'') AS 'Participantes', "
                            + "I.Id_Interaccion AS 'ID', "
                            + "I.Desc_Ruta_Archivo AS 'Ruta Archivo' "
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

            Conexion.IntruccioneSQL = consultaDetalleCaso() +
                            " WHERE I.Id_Caso = "+idCaso+
                            " ORDER BY ID DESC";

            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }


        public bool finalizaCaso(string idCaso)
        {

            if (!String.IsNullOrEmpty(idCaso))
            {
                Conexion.IntruccioneSQL = "prc_FinalizarCasoInteraccion";
                Conexion.conectarProcFinalizarCasoInteraccion(int.Parse(idCaso));
                return true;
            }

            return false;
        }

    }
}
