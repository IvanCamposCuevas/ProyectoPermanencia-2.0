using System;
using System.Web.UI.WebControls;



namespace ProyectoPermanencia.Presentacion
{
    public partial class VisionGlobal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void grvGlobal_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             *  row.Cells[1] = Rut
             *  row.Cells[2] = Nombre alumno
             *  row.Cells[3] = Nombre carrera
             *  row.Cells[4] = Telefono
             *  row.Cells[5] = Correo Institucional
             *  row.Cells[6] = Correo Particular
             *  row.Cells[7] = Nombre escuela
             *  row.Cells[8] = Nombre sede
             *  row.Cells[9] = Jornada
             *  row.Cells[10] = Score**/
            GridViewRow row = this.grvGlobal.SelectedRow;
            string[] info_alumnos = new string[] { row.Cells[1].Text,
                row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text,
                row.Cells[5].Text, row.Cells[7].Text, row.Cells[8].Text, row.Cells[9].Text };
            Session["Info Alumnos"] = info_alumnos;
            Response.Redirect("FichaAlumno.aspx");
        }

        protected void btoFiltrar_Click(object sender, EventArgs e)
        {
            if (txtRutNombre.Text != "")
            {
                Negocio.NegocioPaginaGlobal auxNegocio = new Negocio.NegocioPaginaGlobal();
                this.grvGlobal.DataSource = auxNegocio.consultaScorePorRutNombre(this.txtRutNombre.Text, ddlRutNom.SelectedValue);
                this.grvGlobal.DataBind();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ingrese la informacion dentro del campo de texto");
            }
           

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.NegocioPaginaGlobal auxNegocio = new Negocio.NegocioPaginaGlobal();
                System.Collections.Generic.List<String> listaCarreras = new System.Collections.Generic.List<string>();
                foreach (ListItem item in chkListaCarreras.Items)
                {
                    if (item.Selected == true)
                    {
                        listaCarreras.Add(item.Text);
                    }
                }
                this.grvGlobal.DataSource = auxNegocio.ConsultaScorePorFiltro(this.ddlSede.SelectedValue, this.ddlJornada.SelectedValue, this.ddlEscuelas.SelectedValue, listaCarreras);
                this.grvGlobal.DataBind();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message+";"+ex.InnerException);
            }
        }

        protected void ddlEscuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkListaCarreras.DataSource = new Negocio.NegocioPaginaGlobal().cargarListaCarrera(ddlEscuelas.SelectedValue);
            chkListaCarreras.DataTextField = "Desc_Carrera";
            chkListaCarreras.DataValueField = "Desc_Carrera";
            chkListaCarreras.DataBind();
            mpe.Show();
        }

        protected void grvGlobal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[4].Visible = false; //Ocultar fila "Telefono"
                e.Row.Cells[5].Visible = false; //Ocultar fila "Correo Institucional"
                e.Row.Cells[6].Visible = false; //Ocultar fila "Correo Privado"
            }
        }

        protected void sqlEscuela_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            ddlEscuelas.Items.Add(new ListItem("Todos", "0"));
        }
    }
}