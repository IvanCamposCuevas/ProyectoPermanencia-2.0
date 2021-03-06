﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroInteraccion.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.RegistroInteraccion" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Registrar Interacción </h3>
    </asp:Label>
</asp:Content>
<asp:Content runat="server" ID="ContentRegistroInter" ContentPlaceHolderID="ContentPlaceHolderRegistroInter">
    <div class="container" style="font-size: small">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="container" style="padding: 5px">
                <div class="card card-primary">
                    <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Información del Alumno</div>
                    <div class="row card-body pt-1 pb-1">
                        <div class="col-md-3">
                            <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                            <asp:Label ID="lblRut" runat="server"></asp:Label>

                            <br />
                            <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-4">
                            <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                            <asp:Label ID="lblCarrera" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                            <asp:Label ID="lblEscuela" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <asp:Label runat="server" Font-Bold="true">Jornada:</asp:Label>
                            <asp:Label ID="lblJornada" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                            <asp:Label ID="lblSede" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-3" style="border-left-style: solid; border-left-width: 1px; border-left-color: rgb(7, 47, 115);">
                            <asp:Label runat="server" Font-Bold="true">Telefono:</asp:Label>
                            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Correo:</asp:Label>
                            <asp:Label ID="lblMail" runat="server"></asp:Label>
                            <br />
                        </div>

                    </div>

                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="updateCasoInter" runat="server">
            <ContentTemplate>
                <div class="row jumbotron" style="margin-top: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px;">
                    <fieldset id="fdsCaso" class="col-md-4 card-group p-1">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">1. A qué caso corresponde?</div>
                            <div class="card-body">
                                <div class="row d-flex align-content-center">
                                    <div class="col-md-4 pl-0 mb-4">
                                        <asp:RadioButton runat="server" ID="rbtnExistentes" GroupName="corresponde" AutoPostBack="true" Text="Existente" CssClass="radio-inline form-control-sm" OnCheckedChanged="rbtnExistentes_CheckedChanged" Checked="True" />
                                    </div>
                                    <div class="col-md-8 container m-0 p-0">
                                        <asp:DropDownList runat="server" ID="ddlCasos" CssClass="form-control form-control-sm" Font-Size="Smaller">
                                            <asp:ListItem>Seleccione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row d-flex align-content-center mb-0 pt-0">
                                    <div class="col-md-6 pl-0">
                                        <asp:RadioButton runat="server" ID="rbtnNuevo" GroupName="corresponde" AutoPostBack="true" Text="Nuevo Caso" CssClass="radio-inline form-control-sm" OnCheckedChanged="rbtnNuevo_CheckedChanged" />
                                    </div>
                                </div>
                                <div class="row d-flex align-content-end mb-2">
                                    <div class="col-md-3" style="align-content: center; text-align: end;">
                                        <div class="row pl-5">
                                            <asp:Label runat="server" ID="lblTipoCaso" Text="Tipo: " />
                                        </div>
                                    </div>
                                    <div class="col-md-7" style="padding-right: 0px; justify-content: flex-end;">
                                        <asp:DropDownList runat="server" ID="ddlTipoCaso" AutoPostBack="True" CssClass="form-control form-control-sm ml-3" AppendDataBoundItems="True" Enabled="False" OnSelectedIndexChanged="ddlTipoCaso_SelectedIndexChanged" DataSourceID="sqlTipoCaso" DataTextField="Desc_TipoCaso" DataValueField="Id_TipoCaso">
                                            <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sqlTipoCaso" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT * FROM [Tipo_Caso]"></asp:SqlDataSource>
                                    </div>
                                </div>
                                <div class="row mb-5" style="align-content: flex-end;">
                                    <div class="col-md-3" style="align-content: center; text-align: end;">
                                        <div class="row pl-5">
                                            <asp:Label runat="server" ID="lblCurso" Text="Curso: " />
                                        </div>
                                    </div>
                                    <div class="col-md-7" style="padding-right: 0px; justify-content: flex-end;">
                                        <asp:DropDownList runat="server" ID="ddlCurso" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control form-control-sm ml-3" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row container mt-5">
                                    <asp:LinkButton runat="server" ID="lbtnVolver" CssClass="btn btn-warning btn-sm" OnClick="lbtnVolver_Click"><i class="glyphicon glyphicon-circle-arrow-left"></i> Volver</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </fieldset>

                    <fieldset id="fdsInteraccion" runat="server" class="col-md-8 card-group p-1">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">2. Interacción</div>
                            <div class="card-body" style="padding-right: 35px">
                                <div class="row container">
                                    <div class="col-4">
                                        <div class="row">
                                            <div class="row container pb-2">
                                                <asp:Label runat="server" Font-Bold="true">Tipo de Intervención :</asp:Label>
                                            </div>
                                            <div class="row container dropdown dropdown-toggle disabled">
                                                <asp:DropDownList runat="server" ID="ddlTipoInteraccion" AppendDataBoundItems="True" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm ml-2" OnSelectedIndexChanged="ddlTipoInteraccion_SelectedIndexChanged"
                                                    DataSourceID="sqlTipoInteraccion" DataTextField="Desc_TipoInteraccion" DataValueField="Id_TipoInteraccion">
                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlTipoInteraccion" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT * FROM [Tipo_Interaccion]"></asp:SqlDataSource>
                                            </div>
                                        </div>

                                        <div class="row mt-4">
                                            <div class="row container pb-2">
                                                <asp:Label runat="server" Font-Bold="true">Área de derivación :</asp:Label>
                                            </div>
                                            <div class="row container dropdown dropdown-toggle">
                                                <asp:DropDownList runat="server" ID="ddlArederiv" Enabled="False" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm ml-2" DataSourceID="sqlAreaDerivacion" DataTextField="Desc_AreaDerivacion"
                                                    DataValueField="Id_AreaDerivacion">
                                                    <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlAreaDerivacion" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT * FROM [Area_Derivacion]"></asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 pl-3">
                                        <asp:Label runat="server" Font-Bold="true">Participa(n) :</asp:Label>
                                        <asp:CheckBoxList runat="server" ID="ckblParticipan" CssClass="checkbox mt-2 ml-1 form-control form-control-sm" DataSourceID="sqlParticipantes" DataTextField="Desc_Participante" DataValueField="Id_Participante">
                                        </asp:CheckBoxList>
                                        <asp:SqlDataSource ID="sqlParticipantes" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT * FROM [Participante]"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="row">
                                            <div class="row container mb-2">
                                                <asp:Label runat="server" Font-Bold="true">Subir archivo (opcional):</asp:Label>
                                            </div>
                                            <div class="row container ml-1">

                                                <asp:FileUpload runat="server" ID="flInteraccion" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row container mt-1">
                                    <div class="row container d-flex justify-content-start">
                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label>
                                    </div>
                                    <div class="row container d-flex justify-content-center mt-2">
                                        <div class="col-md-11">
                                            <asp:TextBox runat="server" ID="tbComentarios" CssClass="form-control" Rows="6" MaxLength="1000" Height="100px" TextMode="MultiLine"></asp:TextBox>

                                            <asp:CheckBox ID="chkFinalizarCaso" runat="server" Text="|   ¿Desea finalizar el caso con esta interacción?" CssClass="form-control form-control-sm " />
                                            <br />

                                        </div>
                                        <div class="col-md-1">
                                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success btn-sm" OnClick="btnGuardar_Click" OnClientClick="return confirm('¿Esta seguro que quiere guardar el Caso?');" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </fieldset>

                </div>

            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rbtnExistentes" />
                <asp:PostBackTrigger ControlID="btnGuardar" />
            </Triggers>

        </asp:UpdatePanel>



    </div>

</asp:Content>
