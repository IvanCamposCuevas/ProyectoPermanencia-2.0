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
            /*
            try
            {
                if (!IsPostBack)
                {
                    CargarGrilla();
                }
                else
                {
                    //lblMensaje.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Ocurrio un error inesperado favor contactese con el administrado";
            }*/
        }

       

        private void CargarGrilla()
        {
            //var objetoNegocio = new Negocio();
            //grvGlobal.DataSource = objetoNegocio.consultaScore();
            //grvGlobal.DataBind();
        }

        protected void btoFiltrar_Click(object sender, EventArgs e)
        {
           
        }
        
        protected void grvGlobal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.grvGlobal.SelectedRow;

            String auxRut = row.Cells[1].Text;
            String auxNombre = row.Cells[2].Text;
            String auxCarrera = row.Cells[3].Text;
            String auxSede = row.Cells[4].Text;

            Response.Redirect("FichaAlumno.aspx?auxRut=" +  auxRut+"&auxNombre="+ auxNombre + "&auxCarrera="+ auxCarrera + "&auxSede="+auxSede);

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
            this.grvGlobal.DataSource = auxNegocio.consultaScore(this.txtRut.Text, this.ddlJornada.SelectedValue, this.ddlCarrera.SelectedValue);
            this.grvGlobal.DataBind();
        }
    }
}