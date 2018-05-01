using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPermanencia.Conexion;
namespace ProyectoPermanencia.Negocio
{
    public class NegocioConexion
    {
        private ConexionBDPermanencia conexionBd;

        public ConexionBDPermanencia ConexionBd
        {
            get { return conexionBd; }
            set { conexionBd = value; }
        }

        public void ConfigurarConexion() => ConexionBd = new ConexionBDPermanencia
        {
            NombreBaseDeDatos = "Permanencia_2",
            CadenaConexion = "Data Source=(local);Initial Catalog=Permanencia_2;Integrated Security=True"
        };

    }
}
