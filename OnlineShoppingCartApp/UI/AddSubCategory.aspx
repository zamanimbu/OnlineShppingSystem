<%@ Page Language="C#" MasterPageFile="AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="OnlineShoppingCartApp.UI.AddSubCategory" %>

<%@ MasterType VirtualPath="AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <asp:Button ID="SignOutButton" runat="server" Text="Log Out" OnClick="signOutButton_Click" />
    <div class="form-horizontal">
        <h2>Add Sub Category</h2>
        <hr />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Main Category"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="categoryDropDownList"  CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Sub Category"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="subCategoryNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="addButton" runat="server" Text="Add" CssClass="btn btn-default" OnClick="addButton_OnClick" />
            </div>
        </div>
        <asp:Label ID="messageLabel" runat="server" CssClass="col-md-2 control-label" ></asp:Label>

    </div>
    <hr/>
    <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Sub Categories</div>

            <asp:Repeater ID="categoryRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Sub Category</th>
                                <th>Category</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("SubCategoryId") %></th>
                        <td><%# Eval("SubCategoryName") %></td>
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

