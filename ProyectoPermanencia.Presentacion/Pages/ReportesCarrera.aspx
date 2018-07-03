<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReportesCarrera.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesCarrera" %>
<asp:Content ID="ContentHeadReportesCa" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="ContentCarrera" runat="server" ContentPlaceHolderID="ContentPlaceHolderReportesCa">
    <div class="conteiner">
        <div class="row">
            <div class="col-md-2 jumbotron modal-content" style="margin: 10px; margin-left: 45px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                <h4>Seleccione una opción para generar reporte</h4>
                <br />
                
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li><a href="Reportes.aspx">Global</a></li>
                    <li><a href="ReportesSede.aspx">Sede</a></li>
                    <li><a href="ReportesEscuela.aspx">Escuela</a></li>
                    <li class="active"><a href="#">Carrera</a></li>
                    <li><a href="ReportesJornada.aspx">Jornada</a></li>

                </ul>
                <br>
            </div>
            <div class="col-md-8 jumbotron modal-content" style="border: solid; margin: 10px; padding-right: 0px" />

            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="387px" Height="270px">
                    <Series>
                        <asp:Series ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" Name="Bajo" XValueMember="Desc_Carrera" YValueMembers="Bajo" ChartArea="ChartArea1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio" ChartType="StackedColumn">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto" ChartType="StackedColumn">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Porcentaje ">
                            </AxisY>
                            <AxisX Title="Carreras">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="Title1" Text="Reporte Carreras">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2ConnectionString %>" SelectCommand="SELECT (SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&lt;=0.4) Bajo, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;=0.41 AND Score&lt;0.7) Medio, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;0.7) Alto,
c.Desc_Carrera
FROM 
Permanencia_2.dbo.Score_Alumnos s, 
Permanencia_2.dbo.LK_Alumno a , 
Permanencia_2.dbo.LK_Carrera c,
Permanencia_2.dbo.LK_Escuela e 
WHERE 
s.Id_Alumno = a.Id_Alumno 
AND 
a.Id_Carrera = c.Id_Carrera 
AND 
c.Id_Escuela = e.Id_Escuela
GROUP BY
c.Desc_Carrera;"></asp:SqlDataSource>

        </div>

    </div>

</asp:Content>