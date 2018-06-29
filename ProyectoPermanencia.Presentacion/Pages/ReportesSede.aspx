<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReportesSede.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesSede" %>

<asp:Content ID="ContentHeadReportesSe" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="ContentReportesSe" ContentPlaceHolderID="ContentPlaceHolderReportesSe" runat="server">
    <div class="conteiner">
        <div class="row">
            <div class="col-md-2 jumbotron modal-content" style="margin: 10px; margin-left: 45px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                <h4>Seleccione una opción para generar reporte</h4>
                <br />
                
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li><a href="Reportes.aspx">Global</a></li>
                    <li class="active"><a href="#">Sede</a></li>
                    <li><a href="ReportesEscuela.aspx">Escuela</a></li>
                    <li><a href="ReportesCarrera.aspx">Carrera</a></li>
                    <li><a href="ReportesJornada.aspx">Jornada</a></li>

                </ul>
                <br>
            </div>
            <div class="col-md-8 jumbotron modal-content" style="border: solid; margin: 10px; padding-right: 0px" />
            <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource4" Height="325px" Width="356px">
                <Series>
                    <asp:Series Name="Bajo" ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" XValueMember="Desc_Sede" YValueMembers="Bajo"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio" ChartType="StackedColumn">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto" ChartType="StackedColumn">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Porcentajes">
                        </AxisY>
                        <AxisX Title="Sedes">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Name="Title1" Text="Reporte Sedes">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT (SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&lt;=0.4) Bajo, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;=0.41 AND Score&lt;0.7) Medio, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;0.7) Alto,
se.Desc_Sede
FROM 
Permanencia_2.dbo.Score_Alumnos s, 
Permanencia_2.dbo.LK_Alumno a , 
Permanencia_2.dbo.LK_Carrera c,
Permanencia_2.dbo.LK_Escuela e,
Permanencia_2.dbo.LK_Jornada j,
Permanencia_2.dbo.LK_Sede se 
WHERE 
s.Id_Alumno = a.Id_Alumno 
AND 
a.Id_Carrera = c.Id_Carrera 
AND 
c.Id_Escuela = e.Id_Escuela
AND
a.Id_Jornada = j.Id_Jornada
AND
a.Id_Sede = se.Id_Sede
GROUP BY
se.Desc_Sede;"></asp:SqlDataSource>
        </div>

    </div>
</asp:Content>
