<%@ Page Language="C#" MasterPageFile="AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="OnlineShoppingCartApp.UI.Admin" %>
<%@MasterType VirtualPath="AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <asp:Label ID="lblSuccess" runat="server" Text="<h2> Welcome Admin </h2>" CssClass="text-success"></asp:Label>
    <asp:Button ID="SignOutButton"  runat="server" Text="Log Out" OnClick="signOutButton_Click" />
    
</asp:Content>
