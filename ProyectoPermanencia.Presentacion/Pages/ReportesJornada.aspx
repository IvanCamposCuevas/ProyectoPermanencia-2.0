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
                <a class="nav-link" href="/Pages/Reporte Escuela2.aspx">Escuela</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Carrera</a>
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
            <asp:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" DataSourceID="SqlDataSource3" Palette="SeaGreen">
                <Series>
                    <asp:Series Name="Series1" XValueMember="Rango" YValueMembers="Resultado" IsValueShownAsLabel="True" IsXValueIndexed="True"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Cantidad Alumnos">
                        </AxisY>
                        <AxisX Title="Scores">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 9pt, style=Bold" Name="Jornada DIURNA" Text="Jornada DIURNA">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT Desc_Jornada Jornada, rango Rango, count (1) Resultado from( 
SELECT Score_Alumnos.id_alumno, LK_Jornada.Desc_Jornada ,score,
CASE WHEN
SCORE&gt;= -3 AND SCORE&lt;= 1 THEN 'Bajo' 
WHEN
Score&gt; 1 AND Score&lt;=2 THEN 'Medio'
WHEN
Score&gt;2 AND Score&lt;=3 THEN 'Alto'
END AS 'Rango'
FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno
inner join LK_Jornada on dbo.LK_Jornada.Id_Jornada = LK_Alumno.Id_Jornada ) a
where Desc_Jornada = 'Diurna'
group by Desc_Jornada, rango
order by Resultado desc"></asp:SqlDataSource>


    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderReportesCa" runat="server">
    <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
    <asp:Chart ID="Chart2" runat="server" BackColor="WhiteSmoke" DataSourceID="SqlDataSource1">
        <Series>
            <asp:Series Name="Series1" XValueMember="Rango" YValueMembers="Resultado" IsValueShownAsLabel="True" IsXValueIndexed="True"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY Title="Cantidad Alumnos">
                        </AxisY>
                        <AxisX Title="Scores">
                        </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Font="Microsoft Sans Serif, 9pt, style=Bold" Name="Jornada VESPERTINA" Text="Jornada VESPERTINA">
            </asp:Title>
        </Titles>
    </asp:Chart>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT Desc_Jornada Jornada, rango Rango, count (1) Resultado from( 
SELECT Score_Alumnos.id_alumno, LK_Jornada.Desc_Jornada ,score,
CASE WHEN
SCORE&gt;= -3 AND SCORE&lt;= 1 THEN 'Bajo' 
WHEN
Score&gt; 1 AND Score&lt;=2 THEN 'Medio'
WHEN
Score&gt;2 AND Score&lt;=3 THEN 'Alto'
END AS 'Rango'
FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno
inner join LK_Jornada on dbo.LK_Jornada.Id_Jornada = LK_Alumno.Id_Jornada ) a
where Desc_Jornada = 'Vespertina'
group by Desc_Jornada, rango
order by Resultado desc"></asp:SqlDataSource>
</asp:Content>
