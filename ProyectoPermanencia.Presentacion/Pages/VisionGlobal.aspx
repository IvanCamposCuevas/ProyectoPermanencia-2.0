<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VisionGlobal.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.VisionGlobal" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Visión Global  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentGlobal" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="font-size: small">
                <div class="row">
                    <!-- BUSQUEDA Y FILTROS -->
                    <div class="jumbotron modal-content col-md-4" style="height: 150px; padding: 5px; padding-right: 0px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                        <!-- Buscar por rut o nombre -->
                        <div class="row filtrobox input-group" style="height: 100px; padding: 20px;">
                            <div class="row container">
                                <h5>Buscar Alumno:</h5>
                                <br />
                            </div>
                            <div class="row container">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-5" style="padding-left: 0px">
                                    <asp:DropDownList ID="ddlRutNom" runat="server" Width="100px" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value="1" Text="Rut">Rut</asp:ListItem>
                                        <asp:ListItem Value="2" Text="Nombre">Nombre</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-5" style="padding-left: 0px">
                                    <asp:TextBox runat="server" CssClass="form-control" Width="170px" Height="30px" ID="txtRutNombre"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row container " style="flex-direction: row; padding: 0px;">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-4 p-0" style="font-size: smaller;">
                                    <label class="col-form-label">(Ej: XXXXXXXX-X) </label>
                                </div>
                                <div class="col-md-2" style="flex-direction: row-reverse;">
                                    <asp:Button runat="server" Text="Buscar" ID="btoFiltrar" CssClass="btn btn-info btn-sm" OnClick="btoFiltrar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="jumbotron modal-content col-md-8" style="height: 150px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                        <!-- FILTROS DE BUSQUEDA -->
                        <div class="row filtrobox input-group" style="height: 100px; padding: 20px;">
                            <!-- Filtrar por Sede -->
                            <div id="Sede" class="col-md-3" style="padding-left: 20px;">
                                <div class="form row align-items-center">
                                    <h5>Sede: </h5>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlSede" runat="server" Width="130px" CssClass="form-control form-control-sm ">
                                        <asp:ListItem Value="">Todas</asp:ListItem>
                                        <asp:ListItem Value="3">Antonio Varas</asp:ListItem>
                                        <asp:ListItem Value="4">San Carlos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- Filtrar por jornada-->
                            <div id="Jornada" class="col-md-3" style="padding-left: 20px;">
                                <div class="form row align-items-center">
                                    <h5>Jornada: </h5>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlJornada" runat="server" Width="130px" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value="">Ambas</asp:ListItem>
                                        <asp:ListItem Value="D">Diurno</asp:ListItem>
                                        <asp:ListItem Value="V">Vespertino</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="EscuelaCarrera pl-1" class="col-md-4" >
                                <div class="form row align-items-center">
                                    <h5>Escuela y Carrera: </h5>
                                    <asp:Button ID="btnBuscarCarreras" runat="server" Text="Seleccionar" Font-Size="Small" CssClass="btn btn-sm btn-warning ml-4" OnClientClick="ddlEscuelas_SelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="col-md-1 p-0">
                                <!-- Filtrar resultados -->
                                <div class="row container">
                                    <h5> . </h5>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sm btn-info" Text="Filtrar" OnClick="LinkButton_Click"></asp:LinkButton>

                                </div>


                            </div>
                            <!-- START Pop up -->
                            <div id="popupCarreras" class="justify-content-center" style="max-height: 500px;">
                                <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="800px" Height="400px" CssClass="modal-content p-0" ScrollBars="Vertical" HorizontalAlign="Justify">
                                    <div class="row container pt-3">
                                        <div class="col-md-5">
                                            <!-- Filtrar por escuela -->
                                            <div id="Escuela" class="col-sm-4">
                                                <h5>Escuela: </h5>
                                                <div style="width: 100px; align-self: center;">
                                                    <asp:DropDownList ID="ddlEscuelas" runat="server" Width="280px" CssClass="form-control form-control-sm pl-0" DataSourceID="sqlEscuela" DataTextField="Desc_Escuela" DataValueField="Id_Escuela" OnSelectedIndexChanged="ddlEscuelas_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="sqlEscuela" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT DISTINCT * FROM [LK_Escuela] ORDER BY [Desc_Escuela]" OnSelected="sqlEscuela_Selected"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                            <div class="row container d-flex align-bottom justify-content-end pr-0 pt-5">
                                                <div class="d-flex">
                                                    <asp:Button ID="OKButton" CssClass="btn btn-sm btn-success" Height="30px" runat="server" Text="Cerrar" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-7" style="border-left: solid; border-left-width: 1px; border-left-color: cadetblue">
                                            <h5>Elige una (o más) carrera(s): </h5>
                                            <div id="Carrera" class="card pt-0" style="padding: 20px">
                                                <asp:CheckBoxList ID="chkListaCarreras" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>


                            </div>
                            <ajaxToolkit:ModalPopupExtender ID="mpe" BehaviorID="mpeID" runat="server" TargetControlID="btnBuscarCarreras"
                                PopupControlID="Panel1" OkControlID="OKButton" />
                            <!-- FIN Pop up -->
                        </div>
                    </div>


                    <h3>Scores</h3>
                    <div class="row container-fluid" style="margin: 0px">
                        <div id="ScoreGlobal" class="ScoreGlobal">
                            <asp:GridView ID="grvGlobal" GridLines="None" CssClass="col-md-12 table table-sm table-hover table-responsive"
                                Font-Size="12px" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros"
                                OnSelectedIndexChanged="grvGlobal_SelectedIndexChanged" OnRowDataBound="grvGlobal_RowDataBound">
                                <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-info" SelectText="Ver detalle">
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
