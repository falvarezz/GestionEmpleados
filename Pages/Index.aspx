<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GestionEmpleados.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Lista de Empleados</h2>
        </div>
        <br />
        <div class="container">
        <div class="row">
            <div class="col-md-4 d-flex align-items-end justify-content-end text-right ">
                <asp:TextBox runat="server" ID="TxtSearch" CssClass="form-control" placeholder="Buscar por nombre"></asp:TextBox>
                <asp:Button runat="server" ID="BtnSearch" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnSearch_Click" />
            </div>
            <div class="col-md-4 d-flex align-items-end justify-content-end text-left">
                <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" text="Agregar" OnClick="BtnCreate_Click" />
            </div>
        </div>
        </div>
        <br />
        <div class="container-center mx-auto row">
            <div class="table">
                <asp:GridView runat="server" ID="TbEmpleados" class="table table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Ver" CssClass="btn form-control-sm btn-info" ID="BtnRead" OnClick="BtnRead_Click"/>
                                <asp:Button runat="server" Text="Editar" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Borrar" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
