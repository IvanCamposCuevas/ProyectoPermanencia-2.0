using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class Reporte_Escuela2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*  if (!this.IsPostBack)
              {
                  //Fetch the Statistical data from database.
                  string query = " SELECT desc_escuela as Escuela, rango as Rango, count(1) as Resultado " +
                      " from(SELECT Score_Alumnos.id_alumno, LK_Escuela.Desc_Escuela, score, " +
                      " CASE WHEN SCORE >= -3 AND SCORE <= 1 THEN 'Bajo' WHEN Score > 1 AND Score <= 2 THEN 'Medio' " +
                      " WHEN Score > 2 AND Score <= 3 THEN 'Alto' END AS 'Rango' ";


                  query += " FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno " +
                           " inner join LK_Carrera on dbo.LK_Carrera.Id_Carrera = LK_Alumno.Id_Carrera inner join LK_Escuela on dbo.LK_Escuela.Id_Escuela = LK_Carrera.Id_Escuela) a";
                  query += " GROUP BY desc_escuela, rango";
                  DataTable dt = GetData(query);

                  //Get the DISTINCT desc_escuela.
                  List<string> rango = (from p in dt.AsEnumerable()
                                            select p.Field<string>("rango")).Distinct().ToList();

                  //Loop through the Countries.
                  foreach (string rango_ in rango)
                  {

                      //Get the Year for each Country.
                      int[] x = (from p in dt.AsEnumerable()
                                 where p.Field<string>("Rango") == rango_
                                 orderby p.Field<int>("Resultado") ascending
                                 select p.Field<int>("Resultado")).ToArray();

                      //Get the Total of Orders for each Country.
                      int[] y = (from p in dt.AsEnumerable()
                                 where p.Field<string>("Rango") == rango_
                                 orderby p.Field<int>("desc_escuela") ascending
                                 select p.Field<int>("Resultado")).ToArray();

                      //Add Series to the Chart.
                      Chart1.Series.Add(new Series(rango_));
                      Chart1.Series[rango_].IsValueShownAsLabel = true;
                      Chart1.Series[rango_].ChartType = SeriesChartType.StackedColumn;
                      Chart1.Series[rango_].Points.DataBindXY(x, y);
                  }

                  Chart1.Legends[0].Enabled = true;
              }
          }

          private static DataTable GetData(string query)
          {
              string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
              using (SqlConnection con = new SqlConnection(constr))
              {
                  using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                  {
                      DataTable dt = new DataTable();
                      sda.Fill(dt);
                      return dt;
                  }
              }*/

        }
    }
}