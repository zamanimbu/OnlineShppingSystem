<%@ Page Language="C#" MasterPageFile="AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="OnlineShoppingCartApp.UI.AddCategory" %>

<%@ MasterType VirtualPath="AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />

    <div class="form-horizontal">
        <h2>Add Category</h2>
        <hr />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Category Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="categoryNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="addCategoryButton" runat="server" Text="Add" CssClass="btn btn-default" OnClick="addCategoryButton_OnClick" />
            </div>
        </div>
        <asp:Label ID="messageLabel" runat="server" CssClass="col-md-2 control-label" ></asp:Label>

    </div>
    <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Categories</div>

            <asp:Repeater ID="repeaterCategory" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Category</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("CategoryId") %></th>
                        <td><%# Eval("CategoryName") %></td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
</asp:Content>


