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
            CargarDDLS();
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

        private void CargarDDLS()
        {
            var objNegocio = new ProyectoPermanencia.Negocio.Negocio();
            ListItem elementoInicial = new ListItem() { Text = "Seleccione", Value = "-1" };
            ddlCarrera.Items.Insert(0, elementoInicial);
            ddlCarrera.SelectedIndex = 0;

            ListItem carrera1 = new ListItem() { Text = "GASTRONOMIA INTERNACIONAL", Value = "1" };
            ListItem carrera2 = new ListItem() { Text = "ECOTURISMO", Value = "2" };
            ListItem carrera3 = new ListItem() { Text = "TURISMO AVENTURA", Value = "3" };
            ListItem carrera4 = new ListItem() { Text = "AUDITORIA", Value = "4" };
            ListItem carrera5 = new ListItem() { Text = "COMERCIO EXTERIOR", Value = "5" };
            ListItem carrera6 = new ListItem() { Text = "INGENIERIA EN ADMINISTRACION", Value = "6" };
            ListItem carrera7 = new ListItem() { Text = "INGENIERIA EN NEGOCIOS INTERNACIONALES", Value = "7" };
            ListItem carrera8 = new ListItem() { Text = "INGENIERIA EN INFORMATICA", Value = "8" };
            ListItem carrera9 = new ListItem() { Text = "INGENIERIA EN CONECTIVIDAD Y REDES", Value = "9" };
            ListItem carrera10 = new ListItem() { Text = "ADMINISTRACION DE REDES COMPUTACIONALES", Value = "10" };
            ListItem carrera11 = new ListItem() { Text = "INGENIERIA EN MARKETING", Value = "11" };
            ListItem carrera12 = new ListItem() { Text = "ADMINISTRACION DE RRHH", Value = "12" };
            ListItem carrera13 = new ListItem() { Text = "INGENIERIA EN GESTION LOGISTICA", Value = "13" };
            ListItem carrera14 = new ListItem() { Text = "ADMNISTRACION TURISTICA", Value = "14" };
            ListItem carrera15 = new ListItem() { Text = "TECNICO EN TELECOMUNICACIONES", Value = "15" };
            ListItem carrera16 = new ListItem() { Text = "TURISMO Y HOTELERIA", Value = "16" };


            ddlCarrera.Items.Add(carrera1);
            ddlCarrera.Items.Add(carrera2);
            ddlCarrera.Items.Add(carrera3);
            ddlCarrera.Items.Add(carrera4);
            ddlCarrera.Items.Add(carrera5);
            ddlCarrera.Items.Add(carrera6);
            ddlCarrera.Items.Add(carrera7);
            ddlCarrera.Items.Add(carrera8);
            ddlCarrera.Items.Add(carrera9);
            ddlCarrera.Items.Add(carrera10);
            ddlCarrera.Items.Add(carrera11);
            ddlCarrera.Items.Add(carrera12);
            ddlCarrera.Items.Add(carrera13);
            ddlCarrera.Items.Add(carrera14);
            ddlCarrera.Items.Add(carrera15);
            ddlCarrera.Items.Add(carrera16);            
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

            Response.Redirect("FichaAlumno.aspx?auxRut=" + auxRut+"&auxNombre="+ auxNombre+"&auxCarrera="+auxCarrera+"&auxSede="+auxSede);
        }

        protected void btoFiltrarPorRut_Click(object sender, EventArgs e)
        {
            ProyectoPermanencia.Negocio.Negocio auxNegocio = new ProyectoPermanencia.Negocio.Negocio();

            //this.GridViewScore.DataMember =
            this.grvGlobal.DataSource = auxNegocio.consultaScore(this.txtRut.Text);
            this.grvGlobal.DataBind();
        }
    }
}