<%@ Page Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="OnlineShoppingCartApp.UI.SignUp" %>

<asp:Content ContentPlaceHolderID="headCOntentPlaceHolder" runat="server">

    <style>
        label.error {
            color: #800000;
            font-style: italic;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" runat="server" ClientIDMode="Static">
    <div class="center-page">

        <label class="col-xs-11">Username</label>
        <div class="col-xs-11">
            <asp:TextBox ID="textBoxUserName" runat="server" Class="form-control" placeholder="Username"></asp:TextBox>
        </div>
        <label class="col-xs-11">Password</label>
        <div class="col-xs-11">
            <asp:TextBox ID="textBoxPassword" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>

        <label class="col-xs-11">Confirm Password</label>
        <div class="col-xs-11">
            <asp:TextBox ID="textBoxConfirmPassword" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
        </div>

        <label class="col-xs-11">Name</label>
        <div class="col-xs-11">
            <asp:TextBox ID="textBoxName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
        </div>

        <label class="col-xs-11">Email</label>
        <div class="col-xs-11">
            <asp:TextBox ID="textBoxEmail" runat="server" Class="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
        </div>

        <div class="col-xs-11 space-vert">
            <asp:Button ID="buttonSignup" runat="server" Class="btn btn-success" Text="Sign Up" OnClick="buttonSignup_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scriptContent" runat="server" ClientIDMode="Static">
    <script>
        $('#signOutButtonMasterPage').hide();
        $("#form").validate({
            rules: {
                <%=textBoxUserName.UniqueID %>: {
                    required: true
                },
                <%=textBoxPassword.UniqueID %>: {
                    required: true              
                },

                <%=textBoxConfirmPassword.UniqueID %>: {
                    required: true,
                    equalTo: "#textBoxPassword"
                    
                },
                <%=textBoxName.UniqueID %>: {
                    required: true          
                },
                <%=textBoxEmail.UniqueID %>: {
                    required: true,
                    email: true
                   
                }

            },

            messages: {
                <%=textBoxUserName.UniqueID %>: {
                    required: "Please enter your User Name"
                },
                <%=textBoxPassword.UniqueID %>: {
                    required: "Please enter password"
                },

                <%=textBoxConfirmPassword.UniqueID %>: {
                    required: "Please re-enter password ",
                    equalTo : "Password is not matched"
                },
                <%=textBoxName.UniqueID %>: {
                    required: "Please enter your name"
                },
                <%=textBoxEmail.UniqueID %>: {
                    required: "Please enter email",
                    email: "Please enter a valid email adress "
                }   
            }
        });
    </script>
</asp:Content>


