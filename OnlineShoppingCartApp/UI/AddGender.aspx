<%@ Page Language="C#" MasterPageFile="AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddGender.aspx.cs" Inherits="OnlineShoppingCartApp.UI.AddGender" %>

<%@ MasterType VirtualPath="AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />
    <div class="form-horizontal">
        <h2>Add Gender</h2>
        <hr />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Gender Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtGenderName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtGenderName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click" />
            </div>
        </div>
    </div>
</asp:Content>
