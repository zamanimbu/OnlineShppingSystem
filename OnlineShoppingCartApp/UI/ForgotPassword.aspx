<%@ Page Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="OnlineShoppingCartApp.UI.ForgotPassword" %>


<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" ClientIDMode="Static" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Recover Password</h2>
            <hr />
            <h4>Please enter your email address, We will send you the instrutions to reset your password.</h4>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" CssClass="col-md-2 control-label" Text="Your Email"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="forgotPasswordButton" runat="server" CssClass="btn btn-default" Text="Send"  />
                    <asp:Label ID="lblPassRec" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="scriptContent" runat="server">
    <script>
        $("#form").validate({
            rules: {
                <%=emailTextBox.UniqueID %>: {
                    required: true,
                    email : true
                }       
            },

        messages: {
            <%=emailTextBox.UniqueID %>: {
                    required: "Please enter your  Email adress",
                    email : "Please enter valid email adress"
                }         
    }   
         
        });
    </script>
</asp:Content>
