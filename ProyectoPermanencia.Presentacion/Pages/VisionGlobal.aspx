<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VisionGlobal.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.VisionGlobal" %>

<asp:Content ID="ContentHeadGlobal" ContentPlaceHolderID="head" runat="server">
    <title>Vision Global</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../css/VisionGlobalStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Vision Global  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentGlobal" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <!-- BUSQUEDA Y FILTROS -->
                <div class="jumbotron modal-content" style="height: 250px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                    <!-- Buscar por rut o nombre -->
                    <div class="row filtrobox input-group" style="height: 100px; padding-left: 20px;">
                        <h4>Buscar Alumno:</h4>
                        <asp:DropDownList ID="ddlRutNom" runat="server" Width="138px" Height="30px">
                            <asp:ListItem Value="1" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                            <asp:ListItem Value="2">Nombre Alumno</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" CssClass="”form-control”" Width="115px" Height="30px" ID="txtRutNombre"></asp:TextBox>
                        <asp:Button runat="server" Text="Buscar" ID="btoFiltrar" CssClass="btn btn-info" OnClick="btoFiltrar_Click" />
                    </div>

                    <!-- FILTROS DE BUSQUEDA -->
                    <div class="row" style="height: 90px">
                        <div class="col-sm-2 filtrobox" style="padding-left: 20px; height: 90px">
                            <!-- Filtrar por Sede -->
                            <div id="Sede" class="form-row align-items-center" style="width: 150px;">
                                <h4>Sede: </h4>
                                <asp:DropDownList ID="ddlSede" runat="server" Width="120px">
                                    <asp:ListItem Value="">Todas</asp:ListItem>
                                    <asp:ListItem Value="3">Antonio Varas</asp:ListItem>
                                    <asp:ListItem Value="4">San Carlos</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-sm-2 filtrobox" style="padding-left: 20px; height: 90px; top: 0px; left: 0px;">
                            <!-- Filtrar por jornada -->
                            <div id="Jornada" class="form-row align-items-center" style="width: 100px;">
                                <h4>Jornada: </h4>
                                <asp:DropDownList ID="ddlJornada" runat="server" Width="120px">
                                    <asp:ListItem Value="">Ambas</asp:ListItem>
                                    <asp:ListItem Value="D">Diurno</asp:ListItem>
                                    <asp:ListItem Value="V">Vespertino</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-4 filtrobox" style="height: 90px">
                            <!-- Filtrar por escuela -->
                            <div id="Escuela" style="width: 100px; align-self: center;">
                                <h4>Escuela: </h4>
                                <asp:DropDownList ID="ddlEscuelas" runat="server" DataSourceID="sqlEscuela" DataTextField="Desc_Escuela" DataValueField="Id_Escuela" OnSelectedIndexChanged="ddlEscuelas_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlEscuela" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2ConnectionString3 %>" SelectCommand="SELECT DISTINCT * FROM [LK_Escuela] ORDER BY [Desc_Escuela]"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="col-sm-4 filtrobox" style="margin-left: 0px; padding-left: 0px; height: 90px">
                            <!-- Filtrar por carrera -->
                            <div id="Carrera" style="width: 100px;">
                                <h4>Carrera: </h4>
                                <asp:DropDownList ID="ddlCarrera" runat="server" DataTextField="Desc_Carrera" DataValueField="Desc_Carrera">
                                    <asp:ListItem>--Escoja Una Escuela--</asp:ListItem>
                                </asp:DropDownList>
                                <!--<asp:SqlDataSource ID="sqlCarrera" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2ConnectionString2 %>" SelectCommand="SELECT DISTINCT [Desc_Carrera] FROM [LK_Carrera] ORDER BY [Desc_Carrera]"></asp:SqlDataSource>-->
                            </div>
                        </div>
                        <!-- Filtrar resultados -->
                        <div class="col-md-1" style="float: right; height: 50px;">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Filtrar" OnClick="LinkButton_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>

                <h3>Scores</h3>
                <div class="row" style="margin: 0px">
                    <div id="ScoreGlobal" class="ScoreGlobal">
                        <asp:GridView ID="grvGlobal" CssClass="col-md-12 table table-bordered bs-table table-hover table-condensed table-responsive" 
                            Font-Size="12px" runat="server" BorderStyle="Solid" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" OnSelectedIndexChanged="grvGlobal_SelectedIndexChanged" Width="1200px" OnRowDataBound="grvGlobal_RowDataBound">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info btn-sm" SelectText="Ver detalle">
                                    <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <!-- GRILLA PRINCIPAL -->

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
