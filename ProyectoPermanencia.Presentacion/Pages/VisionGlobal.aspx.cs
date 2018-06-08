using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace ProyectoPermanencia.Presentacion
{
    public partial class VisionGlobal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        private void CargarGrilla()
        {
            Negocio.Negocio auxNegocio = new Negocio.Negocio();
            this.grvGlobal.DataSource = auxNegocio.consultaScorePorRut(this.txtRut.Text);
            this.grvGlobal.DataBind();
        }

        protected void btoFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void grvGlobal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.grvGlobal.SelectedRow;
            string[] info_alumnos = new string[] { row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text, row.Cells[5].Text };
            Session["Info Alumnos"] = info_alumnos;
            Response.Redirect("FichaAlumno.aspx");

        }

        protected void btoFiltrar_Click1(object sender, EventArgs e)
        {
            Negocio.Negocio auxNegocio = new Negocio.Negocio();
            this.grvGlobal.DataSource = auxNegocio.consultaScorePorRut(this.txtRut.Text);
            this.grvGlobal.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Negocio.Negocio auxNegocio = new Negocio.Negocio();
            this.grvGlobal.DataSource = auxNegocio.consultaScore(this.txtRut.Text, this.ddlSede.SelectedValue, this.ddlJornada.SelectedValue, this.ddlEscuelas.SelectedValue, this.ddlCarrera.SelectedValue);
            this.grvGlobal.DataBind();
        }
    }
}