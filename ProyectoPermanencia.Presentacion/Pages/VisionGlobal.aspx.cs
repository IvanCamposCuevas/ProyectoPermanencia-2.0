using System;
using System.Data;
using System.Web.UI.WebControls;
using ProyectoPermanencia.Negocio;
using System.Web.UI;

namespace ProyectoPermanencia.Presentacion
{
    public partial class VisionGlobal : System.Web.UI.Page, IMensajeAlerta
    {
        static NegocioPaginaGlobal negocio = new NegocioPaginaGlobal();

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

            int charLocation = row.Cells[10].Text.IndexOf("<", StringComparison.Ordinal);//codigo para que me saque el score hasta que encuentre el '<' del tag
            string score = row.Cells[10].Text.Substring(0, charLocation); //continuacion
            //row.Cells[10].Style.Add = ("width","20px");

            string[] info_alumnos = new string[] { row.Cells[1].Text,
                row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text,
                row.Cells[5].Text, row.Cells[7].Text, row.Cells[8].Text, row.Cells[9].Text, score};
            Session["Info Alumnos"] = info_alumnos;
            Response.Redirect("FichaAlumno.aspx");
        }

        protected void btoFiltrar_Click(object sender, EventArgs e)
        {
            if (txtRutNombre.Text != "")
            {
                NegocioPaginaGlobal auxNegocio = new NegocioPaginaGlobal();
                this.grvGlobal.DataSource = auxNegocio.consultaScorePorRutNombre(this.txtRutNombre.Text, ddlRutNom.SelectedValue);
                this.grvGlobal.DataBind();
                
                foreach (GridViewRow gvr in this.grvGlobal.Rows)
                {
                    //gvr.Cells[10].Text += "<i class=fa fa-star; style=font-size:20px;color:red;></i>";
                    gvr.Cells[1].Width = new Unit("7%");
                    gvr.Cells[10].Text += auxNegocio.colorScore(Decimal.Parse(gvr.Cells[10].Text));

                    gvr.Height = new Unit("5%");
                    gvr.Cells[10].Width = new Unit("8%"); //hola
                }
            }
            else
            {
                mostrarAlerta("Ingrese la informacion dentro del campo de texto");
            }


        }
        //AGREGARLE FOREACH ACA TB
        protected void LinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                /*System.Collections.Generic.List<String> listaCarreras = new System.Collections.Generic.List<string>();
                foreach (ListItem item in chkListaCarreras.Items)
                {
                    if (item.Selected == true)
                    {
                        listaCarreras.Add(item.Text);
                    }
                }*/
                this.grvGlobal.DataSource = negocio.ConsultaScorePorFiltro(this.ddlSede.SelectedValue, this.ddlJornada.SelectedValue, this.ddlEscuelas.SelectedValue, this.ddlCarreras.SelectedValue);
                this.grvGlobal.DataBind();

                foreach (GridViewRow gvr in this.grvGlobal.Rows)
                {
                    //gvr.Cells[10].Text += "<i class=fa fa-star; style=font-size:20px;color:red;></i>";
                    gvr.Cells[1].Width = new Unit("11%");
                    gvr.Cells[10].Text += negocio.colorScore(Decimal.Parse(gvr.Cells[10].Text));

                    gvr.Height = new Unit("5%");
                    gvr.Cells[10].Width = new Unit("10%");
                }



            }
            catch (Exception ex)
            {
                mostrarAlerta(ex.Message+ " , "+ex.InnerException);
            }
        }

        /*private void cargarCheckboxs(DataView listaCarrera)
        {
            if (!ddlEscuelas.SelectedValue.Equals("0"))
            {
                listaCarrera.RowFilter = "Id_Escuela = " + ddlEscuelas.SelectedValue;
            }
            chkListaCarreras.DataSource = listaCarrera;
            chkListaCarreras.DataTextField = "Desc_Carrera";
            chkListaCarreras.DataValueField = "Id_Escuela";
            chkListaCarreras.DataBind();
            listaCarrera.RowFilter = "";
            mpe.Show();
        }*/


        /*private void cargarCarreras(DataView listaCarrera)
    {
        if (!ddlEscuelas.SelectedValue.Equals("0"))
        {
            listaCarrera.RowFilter = "Id_Escuela = " + ddlEscuelas.SelectedValue;
        }
        ddlCarreras.DataSource = listaCarrera;
            ddlCarreras.DataTextField = "Desc_Carrera";
            ddlCarreras.DataValueField = "Id_Escuela";
            ddlCarreras.DataBind();
        //listaCarrera.RowFilter = "";
        //mpe.Show();
    }*/

        protected void ddlEscuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlEscuelas.SelectedValue.Equals("0"))
            {
                ddlCarreras.Items.Clear();
                ddlCarreras.Items.Insert(0, new ListItem("Seleccione la carrera", "0"));
                int idescuela = int.Parse(ddlEscuelas.SelectedValue);

                ddlCarreras.DataSource = negocio.cargarListaCarrera(idescuela);
                ddlCarreras.DataTextField = "Desc_Carrera";
                ddlCarreras.DataValueField = "Id_Carrera";
                ddlCarreras.DataBind();

                
            }
            else
            {
                ddlCarreras.Items.Clear();
            }

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

        public void mostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", string.Format("alert('{0}');", mensaje), true);
        }
    }
}