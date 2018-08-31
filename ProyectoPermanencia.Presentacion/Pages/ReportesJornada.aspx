<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="ReportesJornada.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesJornada" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTabsReportes" runat="server">
    <div class="container" style="font-size: small">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Reportes.aspx">Global</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesSede.aspx">Sede</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesEscuela.aspx">Escuela</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesCarrera.aspx">Carrera</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="#">Jornada</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="ContentReportesJo" ContentPlaceHolderID="ContentPlaceHolderReportesJo" runat="server">
    <div class="conteiner">
        <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" Height="305px" Width="392px">
                <Series>
                    <asp:Series ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" Name="Bajo" XValueMember="Desc_Jornada" YValueMembers="Bajo">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio" ChartType="StackedColumn">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto" ChartType="StackedColumn">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Porcentaje">
                        </AxisY>
                        <AxisX Title="Jornadas">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Name="Title1" Text="Reporte Jornada">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT (SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&lt;=0.4) Bajo, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;=0.41 AND Score&lt;0.7) Medio, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;0.7) Alto,
j.Desc_Jornada 
FROM 
Permanencia_2.dbo.Score_Alumnos s, 
Permanencia_2.dbo.LK_Alumno a , 
Permanencia_2.dbo.LK_Carrera c,
Permanencia_2.dbo.LK_Escuela e,
Permanencia_2.dbo.LK_Jornada j 
WHERE 
s.Id_Alumno = a.Id_Alumno 
AND 
a.Id_Carrera = c.Id_Carrera 
AND 
c.Id_Escuela = e.Id_Escuela
AND
a.Id_Jornada = j.Id_Jornada
GROUP BY
j.Desc_Jornada;"></asp:SqlDataSource>


    </div>
</asp:Content>
