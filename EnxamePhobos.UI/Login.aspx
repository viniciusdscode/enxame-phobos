<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnxamePhobos.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" cssclass="htmlFundo">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%--meuCss--%>
    <link rel="stylesheet" href="resource/css/style.css" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="LoginPage">
            
            <ul>
                <li>
                    <h1>Login </h1>
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome: " MaxLenght="150">

                     </asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha: " MaxLenght="6">

                     </asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar"  OnClick="btnEntrar_Click" class="btnLogin"/>
                </li>
                <li class="txtLoginlbl">
                    <asp:Label ID="lblMessage" runat="server" Text="Label" >

                    </asp:Label>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
