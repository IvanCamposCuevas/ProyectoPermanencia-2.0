using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    class NegocioConexionBD
    {
        private Conexion.Conexion conec1;

        public Conexion.Conexion Conec1
        {
            get { return conec1; }
            set { conec1 = value; }
        }

        public void configuraConexion()
        {
            this.Conec1 = new Conexion.Conexion();
            this.Conec1.NombreBaseDeDatos = "prueba";
            this.Conec1.NombreTabla = "clientes";
            this.Conec1.CadenaConexion = @"Data Source=DESKTOP-L975CUE\SQLEXPRESS;Initial Catalog=Permanencia_2;Integrated Security=True";
        }
    }
}
