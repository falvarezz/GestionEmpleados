<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GestionEmpleados.Pages.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 400px">
        <asp:Label runat="server" CssClass="h2" ID="lbtitulo"></asp:Label>
    </div>
    <br />
    <form runat="server" class="col-md-6 offset-md-3 d-flex align-items-center justify-content-center border rounded p-4" style="border: 2px solid #ccc;">
        <div>
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TbNombre" placeholder="Nombre del Empleado"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TbNombre" InitialValue="" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" />
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TbApellido" placeholder="Apellido del Empleado"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TbApellido" InitialValue="" ErrorMessage="El apellido es obligatorio" CssClass="text-danger" />
        </div>
        <div class="mb-3">
            <label class="form-label">Correo Electronico</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TbEmail" placeholder="Correo del Empleado"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TbEmail" InitialValue="" ErrorMessage="El correo es obligatorio" CssClass="text-danger" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="TbEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Formato de correo inválido" CssClass="text-danger" />
        </div>
        <div class="mb-3">
            <label class="form-label">Salario</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TbSalario" placeholder="Salario del Empleado" type="number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TbSalario" InitialValue="" ErrorMessage="El salario es obligatorio" CssClass="text-danger" />
        </div>
        <asp:Button runat="server" CssClass="btn btn-primary btn-info" ID="BtnCreate" Text="Crear" Visible="false" Onclick="BtnCreate_Click" CausesValidation="true" />
        <asp:Button runat="server" CssClass="btn btn-primary btn-warning" ID="BtnUpdate" Text="Editar" Visible="false" Onclick="BtnUpdate_Click" CausesValidation="true"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="BtnDelete" Text="Borrar" Visible="false" Onclick="BtnDelete_Click"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="true" Onclick="BtnVolver_Click"/>
        </div>    
    </form>
</asp:Content>
