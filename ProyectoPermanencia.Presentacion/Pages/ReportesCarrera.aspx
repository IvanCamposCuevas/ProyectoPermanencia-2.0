<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="ReportesCarrera.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesCarrera" %>

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
                <a class="nav-link active" href="#">Carrera</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesJornada.aspx">Jornada</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="ContentCarrera" runat="server" ContentPlaceHolderID="ContentPlaceHolderReportesCa">
    <div class="conteiner">
        <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="750px" Height="500px">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Color="LimeGreen" Legend="Legend1" Name="Bajo" XValueMember="Carrera" YValueMembers="Resultado">
                    </asp:Series>
                    <asp:Series ChartType="StackedColumn" Color="Yellow" Legend="Legend1" Name="Medio" ChartArea="ChartArea1">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Color="Red" Legend="Legend1" Name="Alto" XValueMember="Carrera" YValueMembers="Resultado">
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
        </div>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT DISTINCT Desc_Carrera Carrera, rango Rango, count (1) Resultado from( 
SELECT Score_Alumnos.id_alumno, LK_Carrera.Desc_Carrera ,score,
CASE WHEN
SCORE&gt;= -3 AND SCORE&lt;= 1 THEN 'Bajo' 
WHEN
Score&gt; 1 AND Score&lt;=2 THEN 'Medio'
WHEN
Score&gt;2 AND Score&lt;=3 THEN 'Alto'
END AS 'Rango'
FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno
inner join LK_Carrera on dbo.LK_Carrera.Id_Carrera = LK_Alumno.Id_Carrera ) a
group by Desc_Carrera, rango"></asp:SqlDataSource>
        
    </div>

</asp:Content>
