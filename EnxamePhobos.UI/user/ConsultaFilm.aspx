<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilm.aspx.cs" Inherits="EnxamePhobos.UI.user.ConsultaFilm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false"  >
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
            <asp:BoundField DataField="Genero_id" HeaderText="Genero" />
            <asp:BoundField DataField="Classificacao_id" HeaderText="Classificacao" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="110" ControlStyle-Height="110"/>


            </Columns>
    </asp:GridView>
</asp:Content>
