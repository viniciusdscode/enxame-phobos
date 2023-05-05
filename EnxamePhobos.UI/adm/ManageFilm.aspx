<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageFilm.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageFilm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblMessage" runat="server" Text="Manage Film" class="txtAdm"></asp:Label>
    <%-- formulario --%>
    <div>
        <ul>
            <li>
                <asp:TextBox ID="txtId" runat="server" placeholder="Id" Width="90%" class="campoAdm" ></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo" Width="90%" class="campoAdm"></asp:TextBox>
                
            </li>
            <li>
                <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora" Width="90%" class="campoAdm"></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="txtUrl" runat="server" placeholder="UrlImg" MaxLength="6" Width="90%" class="campoAdm"></asp:TextBox>
            </li>
            
            <li>
                <asp:TextBox ID="txtSearchFilm" runat="server" placeholder="Search By Titulo:" CssClass="searchAdm"></asp:TextBox>
                <asp:Button ID="btnSearchFilm" runat="server" Text="Search" OnClick="btnSearchFilm_Click" CssClass="btnDefault"/>
                <asp:Label ID="lblSearchFilm" runat="server" Text=""></asp:Label>

            </li>
            

<%-- gridView --%>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Opção"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Código" runat="server"/>
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" runat="server"/>
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" runat="server"/>
            <asp:BoundField DataField="Genero_id" HeaderText="Genero" runat="server"/>
            <asp:BoundField DataField="Classificacao_id" HeaderText="Classificacao" runat="server"/>
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="110" ControlStyle-Height="110"/>

            </Columns>
    </asp:GridView>

</asp:Content>
