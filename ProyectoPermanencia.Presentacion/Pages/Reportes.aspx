<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Reportes" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="ContentHeadReportes" ContentPlaceHolderID="head" runat="server">
    <title>Reportes</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Reportes  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentReportes" ContentPlaceHolderID="ContentPlaceHolderReportes" runat="server">
    <div class="conteiner">
        <div class="row">
            <div class="col-md-2 jumbotron modal-content" style="margin:10px; margin-left:45px; border-radius:2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow:none;">
                <h4>Seleccione una opción para generar reporte</h4> 
                <br />
                <asp:CheckBoxList ID="chkb" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    <asp:ListItem Enabled="False">Sede</asp:ListItem>
                    <asp:ListItem Enabled="False">Escuela</asp:ListItem>
                    <asp:ListItem Enabled="False">Carrera</asp:ListItem>
                    <asp:ListItem Enabled="False">Jornada</asp:ListItem>                    
                </asp:CheckBoxList>
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#">Global</a></li>
                    <li><a href="ReportesSede.aspx">Sede</a></li>
                    <li><a href="ReportesEscuela.aspx">Escuela</a></li>
                    <li><a href="ReportesCarrera.aspx">Carrera</a></li>
                    <li><a href="ReportesJornada.aspx">Jornada</a></li>
                </ul>
                <br>
            </div>
            <div class="col-md-8 jumbotron modal-content" style="border:solid; margin:10px; padding-right: 0px"/>


                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" OnLoad="Chart1_Load" Width="400px">
                    <series>
                        <asp:Series ChartType="StackedColumn" Color="0, 192, 0" Name="Bajo" XValueMember="Desc_Escuela" YValueMembers="Bajo" Legend="Legend1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Color="Gold" Name="Medio" XValueMember="Desc_Escuela" YValueMembers="Medio" Legend="Legend1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Color="Red" Name="Alto" XValueMember="Desc_Escuela" YValueMembers="Alto" Legend="Legend1">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Porcentajes">
                            </AxisY>
                            <AxisX Title="Escuelas">
                            </AxisX>
                        </asp:ChartArea>
                    </chartareas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="Title1" Text="Reporte Escuela">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT (SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&lt;=0.4) Bajo, 
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT (SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&lt;=0.4) Bajo, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;=0.41 AND Score&lt;0.7) Medio, 
(SELECT (COUNT(*)*100)/(SELECT COUNT(*) FROM dbo.Score_Alumnos) FROM Score_Alumnos WHERE Score&gt;0.7) Alto,
e.Desc_Escuela 
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
e.Desc_Escuela;"></asp:SqlDataSource>
                <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="387px" Height="270px">
                    <Series>
                        <asp:Series ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" Name="Bajo" XValueMember="Desc_Carrera" YValueMembers="Bajo" ChartArea="ChartArea1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto">
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
                <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" Height="305px" Width="392px">
                    <Series>
                        <asp:Series ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" Name="Bajo" XValueMember="Desc_Jornada" YValueMembers="Bajo">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto">
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
            <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource4" Height="325px" Width="356px">
                <Series>
                    <asp:Series Name="Bajo" ChartType="StackedColumn" Color="0, 192, 0" Legend="Legend1" XValueMember="Desc_Sede" YValueMembers="Bajo"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Yellow" Legend="Legend1" Name="Medio">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="Red" Legend="Legend1" Name="Alto">
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
        </div>
    </div>




</asp:Content>
