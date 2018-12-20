<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="Reporte Escuela2.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Reporte_Escuela2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTabsReportes" runat="server">
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
                <a class="nav-link" href="#">Carrera</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/ReportesJornada.aspx">Jornada</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderReportes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderReportesSe" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderReportesEs" runat="server">
    <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" BackColor="WhiteSmoke" Palette="None" PaletteCustomColors="0, 192, 0" RightToLeft="Yes">
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
            <asp:Title Name="Escuela TURISMO" Font="Microsoft Sans Serif, 9pt, style=Bold" Text="Escuela TURISMO">
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
where desc_escuela = 'Turismo' 
group by desc_escuela, rango 
order by Resultado desc"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderReportesCa" runat="server">
    <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" BackColor="WhiteSmoke" Palette="None">
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
            <asp:Title Font="Microsoft Sans Serif, 9pt, style=Bold" Name="Escuela INFORMATICA Y TELECOMUNICACIONES" Text="Escuela INFORMATICA Y TELECOMUNICACIONES">
            </asp:Title>
        </Titles>
    </asp:Chart>
        </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT desc_escuela as Escuela, rango as Rango, count (1) as Resultado  from( 
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
where desc_escuela = 'INFORMATICA Y TELECOMUNICACIONES'
group by desc_escuela, rango 
order by Resultado desc"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderReportesJo" runat="server">
    <div class="row container m-1 modal-content" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" BackColor="WhiteSmoke" Palette="EarthTones">
        <Series>
            <asp:Series Name="Series1" XValueMember="Rango" YValueMembers="Resultado" Legend="Legend1" IsValueShownAsLabel="True" IsXValueIndexed="True"></asp:Series>
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
            <asp:Title Font="Microsoft Sans Serif, 9pt, style=Bold" Name="Escuela ADMINISTRACION Y NEGOCIOS" Text="Escuela ADMINISTRACION Y NEGOCIOS">
            </asp:Title>
        </Titles>
    </asp:Chart>
        </div>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT desc_escuela as Escuela, rango as Rango, count (1) as Resultado  from( 
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
where desc_escuela = 'ADMINISTRACION Y NEGOCIOS'
group by desc_escuela, rango 
order by Resultado desc"></asp:SqlDataSource>
</asp:Content>
