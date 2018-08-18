<%@ Page Language="C#" MasterPageFile="user.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="OnlineShoppingCartApp.UI.ProductView" %>

<%@ MasterType VirtualPath="user.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <div style="padding-top: 50px">
        <div class="col-md-5">
            <div style="max-width: 480px" class="thumbnail">
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="4"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <asp:Repeater ID="rptrImages" runat="server">
                            <ItemTemplate>
                                <div class="item <%# GetActiveClass(Container.ItemIndex) %>">
                                    <img src="../Image/ProductImages/<%#Eval("ProductId") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='Image/noimage.jpg'">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <asp:Repeater ID="rptrProductDetails" OnItemDataBound="rptrProductDetails_ItemDataBound" runat="server">
                <ItemTemplate>
                    <div class="divDet1">
                        <h1 class="proNameView"><%#Eval("ProductName") %></h1>
                        <span class="proOgPriceView"><%#Eval("Price") %></span><span class="proPriceDiscountView"> <%# string.Format("{0}",Convert.ToInt64(Eval("Price"))-Convert.ToInt64(Eval("SellingPrice"))) %> OFF</span>
                        <p class="proPriceView"><%#Eval("SellingPrice") %></p>
                    </div>
                    <div>
                        <h5 class="h5Size">SIZE</h5>
                        <div>
                            <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divDet1">
                        <asp:Button ID="btnAddToCart" CssClass="mainButton" runat="server" OnClick="btnAddToCart_OnClick" Text="ADD TO CART" />
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="divDet1">
                        <h5 class="h5Size">Description</h5>
                        <p>
                            <%#Eval("Description") %>
                        </p>
                        <h5 class="h5Size">Product Details</h5>
                        <p>
                            <%#Eval("Details") %>
                        </p>
                        <h5 class="h5Size">Material & Care</h5>
                        <p>
                            <%#Eval("MaterialCare") %>
                        </p>
                    </div>
                    <div>
                        <p><%# ((int)Eval("FreeDelivery")==1)?"Free Delivery":"" %></p>
                        <p><%# ((int)Eval("DaysReturn")==1)?"30 Days Returns":"" %></p>
                        <p><%# ((int)Eval("Cod")==1)?"Cash on Delivery":"" %></p>
                    </div>

                    <asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryId") %>' runat="server" />
                    <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("SubCategoryId") %>' runat="server" />
                    <asp:HiddenField ID="hfGenderID" Value='<%# Eval("GenderId") %>' runat="server" />
                    <asp:HiddenField ID="hfBrandID" Value='<%# Eval("BrandId") %>' runat="server" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
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
