using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class Interacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] info = (string[])Session["Info Alumnos"];
            this.lblRut.Text = info[0];
            //grvCasos.DataSource = new Negocio.NegocioFichaAlumno().CargargrvCasos(lblRut.Text);
            //grvCasos.DataBind();



        }

        protected void btnNuevaInteraccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/RegistroInteraccion.aspx");
        }

        protected void grvCasos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvCasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* [0] Id Caso
             * [1] Fecha Inicio
             * [2] Tipo Caso
             * [3] Curso
             * [4] Id interaccion
             * [5] Ultima interaccion
             * [6] Estado del caso
             * [7] Fecha termino
             * 
             */
            GridViewRow row = this.grvCasos.SelectedRow;
            string[] info_caso = new string[] {row.Cells[0].Text, row.Cells[1].Text,
                row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text,
                row.Cells[5].Text, row.Cells[7].Text };
            Session["Info Caso"] = info_caso;
            Session["Proveniencia"] = "ficha";
            Response.Redirect("/Pages/DetalleCaso.aspx");
        }

        /*protected void btnDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/DetalleCaso.aspx");
        }*/
    }
}