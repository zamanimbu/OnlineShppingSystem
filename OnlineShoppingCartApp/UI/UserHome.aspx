<%@ Page Language="C#" MasterPageFile="user.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="OnlineShoppingCartApp.UI.UserHome" %>

<%@ MasterType VirtualPath="user.Master" %>

<asp:Content ContentPlaceHolderID="headCOntentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <div class="container">
        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>
    </div>
    <asp:Button ID="signOutButton" OnClick="signOutButton_Click" runat="server" Text="Log Out" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="productContentPlaceHolder">
    <a href="HomeProduct.aspx"></a>
</asp:Content>
<asp:Content ContentPlaceHolderID="scriptContent" runat="server">

    <% if (Session["USERNAME"] == null)
        {%>
    <script>
        $('#signIn').show();
        $('#signUp').show();
    </script>
    <%  }
    else
    {%>
    <script>
        $('#signIn').hide();
        $('#signUp').hide();
    </script>
    <%  }%>
</asp:Content>
