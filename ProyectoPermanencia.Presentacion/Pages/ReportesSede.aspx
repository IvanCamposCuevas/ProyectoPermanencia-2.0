<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="ReportesSede.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesSede" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTabsReportes" runat="server">
    <div class="container" style="font-size: small">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Reportes.aspx">Global</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="#">Sede</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesEscuela.aspx">Escuela</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesCarrera.aspx">Carrera</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesJornada.aspx">Jornada</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="ContentReportesSe" ContentPlaceHolderID="ContentPlaceHolderReportesSe" runat="server">
    <div class="container">
        <div class="row modal-content m-1" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
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
        </div>

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
</asp:Content>
