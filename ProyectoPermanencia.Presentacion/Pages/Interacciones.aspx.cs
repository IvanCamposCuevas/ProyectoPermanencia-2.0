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
            grvCasos.DataSource = new Negocio.NegocioResolucion().buscarCasoPorRut(info[0]);
            grvCasos.DataBind();

        }

        protected void btnNuevaInteraccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroInteraccion.aspx");
        }

        protected void grvCasos_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = this.grvCasos.SelectedRow;
            string[] info_caso = new string[] {row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text,
                                               row.Cells[4].Text, row.Cells[5].Text, row.Cells[6].Text,
                                               row.Cells[7].Text, row.Cells[8].Text, row.Cells[9].Text,
                                               row.Cells[10].Text, row.Cells[11].Text, row.Cells[15].Text};
            Session["info_caso"] = info_caso;
            Response.Redirect("DetalleCaso.aspx");
        }

        protected void grvCasos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[5].Visible = false; //Oculta la fila "Nombre Alumno"
                e.Row.Cells[6].Visible = false; //Oculta la fila "Correo"
                e.Row.Cells[7].Visible = false; //Oculta la fila "Telefono"
                e.Row.Cells[8].Visible = false; //Oculta la fila "Carrera"
                e.Row.Cells[9].Visible = false; //Oculta la fila "Escuela"
                e.Row.Cells[10].Visible = false;//Oculta la fila "Jornada"
                e.Row.Cells[11].Visible = false;//Oculta la fila "Sede"
            }
        }
    }
}