<%@ Page Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="OnlineShoppingCartApp.UI.SignIn" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headCOntentPlaceHolder" runat="server">

    <style>
        label.error {
            color: #800000;
            font-style: italic;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server" ClientIDMode="Static">
    <div class="container">
        <div class="form-horizontal">
            <h2>Login</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="userNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="passwordTextBox" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:CheckBox ID="rememberCheckBox" runat="server" />
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="logInButton" runat="server" Text="Login" CssClass="btn btn-default" OnClick="logInButton_Click" />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" PostBackUrl="SIgnUp.aspx">Sign Up</asp:LinkButton>
                </div>
            </div>
             <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:LinkButton ID="forgotPassword" runat="server" PostBackUrl="ForgotPassword.aspx">Forgot Password !</asp:LinkButton>
                    </div>
                </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scriptContent" runat="server">
    <script>
        $('#signUp').hide();
        $('#signOutButtonMasterPage').hide();
    </script>
    <script>
        $("#form").validate({
            rules: {
                <%=userNameTextBox.UniqueID %>: {
                    required: true
                },
                <%=passwordTextBox.UniqueID %>: {
                    required: true              
                }
                   
                
            },

            messages: {
                <%=userNameTextBox.UniqueID %>: {
                    required: "Please enter your User Name"
                },
                <%=passwordTextBox.UniqueID %>: {
                 required: "Please enter password"
             }
              
            }   
         
        });
    </script>
</asp:Content>
