<%@ Page Language="C#" MasterPageFile="user.Master" AutoEventWireup="true" CodeBehind="HomeProduct.aspx.cs" Inherits="OnlineShoppingCartApp.UI.HomeProduct" %>
<%@ MasterType VirtualPath="user.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />
    <div class="row" style="padding-top: 50px">
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
                <div class="col-sm-3 col-md-3">
                    <a style="text-decoration:none;" href="ProductView.aspx?ProductId=<%#Eval("ProductId") %>">
                        <div class="thumbnail">
                            <img src="../Image/ProductImages/<%#Eval("ProductId") %>/<%#Eval("ImageName") %><%#Eval("Extention") %>" alt="<%#Eval("ImageName") %>">
                            <div class="caption">
                                <div class="probrand"><%#Eval("BrandName") %></div>
                                <div class="proName"><%#Eval("ProductName") %></div>
                                <div class="proPrice"><span class="proOgPrice"><%#Eval("Price") %></span> <%#Eval("SellingPrice") %> <span class="proPriceDiscount">(<%#Eval("DiscountAmount") %>  Off)</span></div>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="scriptContent">
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
