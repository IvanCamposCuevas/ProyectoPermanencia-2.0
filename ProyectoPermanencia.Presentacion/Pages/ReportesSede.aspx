﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true" CodeBehind="ReportesSede.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesSede" %>

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
                <a class="nav-link" href="/Pages/Reporte Escuela2.aspx">Escuela</a>
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
<asp:Content ID="ContentReportesSe" ContentPlaceHolderID="ContentPlaceHolderReportesSe" runat="server">
    <div class="container">
        <div class="row modal-content m-1" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <asp:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" DataSourceID="SqlDataSource4" Palette="None" PaletteCustomColors="Navy">
                <Series>
                    <asp:Series Name="Series1" XValueMember="Rango" YValueMembers="Resultado"></asp:Series>
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
                    <asp:Title Font="Microsoft Sans Serif, 9pt, style=Bold" Name="Sede ANTONIO VARAS" Text="Sede ANTONIO VARAS">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>

        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT Desc_Sede Sede, rango Rango, count (1) Resultado from( 
SELECT Score_Alumnos.id_alumno, LK_Sede.Desc_Sede ,score,
CASE WHEN
SCORE&gt;= -3 AND SCORE&lt;= 1 THEN 'Bajo' 
WHEN
Score&gt; 1 AND Score&lt;=2 THEN 'Medio'
WHEN
Score&gt;2 AND Score&lt;=3 THEN 'Alto'
END AS 'Rango'
FROM dbo.Score_Alumnos inner join LK_Alumno on dbo.Score_Alumnos.Id_Alumno = LK_Alumno.Id_Alumno
inner join LK_Sede on dbo.LK_Sede.Id_Sede = LK_Alumno.Id_Sede ) a
group by Desc_Sede, rango
order by Resultado desc"></asp:SqlDataSource>


    </div>
</asp:Content>
