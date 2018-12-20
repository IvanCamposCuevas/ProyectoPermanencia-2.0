<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="ReportesEscuela.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesEscuela" %>

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
                <a class="nav-link active" href="#">Escuela</a>
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
<asp:Content ID="ContentReportesEs" runat="server" ContentPlaceHolderID="ContentPlaceHolderReportesEs">
    <div class="conteiner">
        <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" OnLoad="Chart1_Load" Width="400px">
                <Series>
                    <asp:Series ChartType="StackedColumn100" Color="0, 192, 0" Name="Bajo" XValueMember="Escuela" YValueMembers="Resultado" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn100" Legend="Legend1" Name="Medio" XValueMember="Escuela" YValueMembers="Resultado">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn100" Legend="Legend1" Name="Alto" XValueMember="Escuela" YValueMembers="Resultado">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Porcentajes">
                        </AxisY>
                        <AxisX Title="Escuelas">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Name="Title1" Text="Reporte Escuela">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT desc_escuela as Escuela, rango as Rango, count (1) as Resultado  from( 
SELECT Score_Alumnos.id_alumno, LK_Escuela.Desc_Escuela ,score,
CASE WHEN
SCORE&gt;= -3 AND SCORE&lt;= 1 THEN 'Bajo' 
WHEN
Score&gt; 1 AND Score&lt;=2 THEN 'Medio'
WHEN
Score&gt;2 AND Score&lt;=3 THEN 'Alto'
END AS 'Rango'
FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno
inner join LK_Carrera on dbo.LK_Carrera.Id_Carrera = LK_Alumno.Id_Carrera 
inner join LK_Escuela on dbo.LK_Escuela.Id_Escuela = LK_Carrera.Id_Escuela ) a
group by desc_escuela, rango"></asp:SqlDataSource>


    </div>
</asp:Content>
