<%@ Page Language="C#" MasterPageFile="AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSize.aspx.cs" Inherits="OnlineShoppingCartApp.UI.AddSize" %>

<%@ MasterType VirtualPath="AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />

    <div class="form-horizontal">
        <h2>Add Size</h2>
        <hr />
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Size Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="sizeNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="brandDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="categoryDropDownList" OnSelectedIndexChanged="categoryDropDownList_OnSelectedIndexChanged" AutoPostBack="True" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Sub Category"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="subCategoryDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Gender"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="genderDropDOwnList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="addButton" runat="server" Text="Add" CssClass="btn btn-default" OnClick="addButton_OnClick" />
            </div>
        </div>
        <asp:Label ID="messageLabel" runat="server" CssClass="col-md-2 control-label"></asp:Label>

    </div>
    <div class="container">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Size</div>

            <asp:Repeater ID="repeaterSIze" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name</th>
                                <th>Brand</th>
                                <th>Category</th>
                                <th>Sub Category</th>
                                <th>Gender</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("SizeId") %></th>
                        <th><%# Eval("SizeName") %></th>
                        <th><%# Eval("BrandName") %></th>
                        <th><%# Eval("CategoryName") %></th>
                        <td><%# Eval("SubCategoryName") %></td>
                        <td><%# Eval("GenderName") %></td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
               
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>

