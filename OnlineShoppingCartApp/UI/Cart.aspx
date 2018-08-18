<%@ Page Language="C#" MasterPageFile="user.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="OnlineShoppingCartApp.UI.Cart" %>
<%@ MasterType VirtualPath="user.Master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="Server">
   <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />

    <div style="padding-top: 20px;">
        <div class="col-md-9">
            <h5 class="proNameViewCart" runat="server" id="h5NoItems"></h5>

            <asp:Repeater ID="rptrCartProducts" runat="server">
                <ItemTemplate>
                    <div class="media" style="border: 1px solid #eaeaec;">
                        <div class="media-left">
                            <a href="ProductView.aspx?ProductId=<%#Eval("ProductId") %>" target="_blank">
                                <img width="100px" class="media-object" src="../Image/ProductImages/<%#Eval("ProductId") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='images/noimage.jpg'">
                            </a>
                        </div>
                        <div class="media-body">
                            <h5 class="media-heading proNameViewCart"><%#Eval("ProductName") %></h5>
                            <p class="proPriceDiscountView">Size : <%#Eval("SizeName") %></p>
                            <span class="proPriceView"><%#Eval("SellingPrice","{0:c}") %></span>
                            <span class="proOgPriceView"><%#Eval("Price","{0:0,00}") %></span>
                            <p>
                                <asp:Button CommandArgument='<%#Eval("ProductId")+"-"+ Eval("SizeId")%>' ID="btnRemoveItem"  CssClass="removeButton" OnClick="btnRemoveItem_OnClick" runat="server" Text="REMOVE" />
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-3" runat="server" id="divPriceDetails">
            <div style="border-bottom: 1px solid #eaeaec;">
                <h5 class="proNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="pull-right priceGray" id="spanCartTotal" runat="server"></span>
                </div>
                <div>
                    <label>Cart Discount</label>
                    <span class="pull-right priceGreen" id="spanDiscount" runat="server"></span>
                </div>
            </div>
            <div>
                <div class="proPriceView">
                    <label>Total</label>
                    <span class="pull-right" id="spanTotal" runat="server"></span>
                </div>
                <div>
                    <asp:Button ID="btnBuyNow"  CssClass="buyNowBtn" runat="server" OnClick="btnBuyNow_OnClick" Text="BUY NOW" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


