<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageFilm.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageFilm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblMessage" runat="server" Text="Manage Film" class="txtAdm"></asp:Label>
    <%-- formulario --%>
    <div>
        <ul>
            <li>
                <asp:TextBox ID="txtId" runat="server" placeholder="Id" Width="90%" class="campoAdm"></asp:TextBox>

            </li>
            <li>
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem" />
                <asp:Label ID="lblfUp1" runat="server" Text=""></asp:Label>
            </li>

            <li>
                <asp:RadioButtonList ID="rbl1" runat="server">
                    <asp:ListItem Value="1" Text="Livre" />
                    <asp:ListItem Value="2" Text="+14" />
                    <asp:ListItem Value="3" Text="+18" />
                </asp:RadioButtonList>
                <asp:Label ID="lblClassificacao_Id" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:DropDownList
                    ID="ddl1"
                    runat="server"
                    Width="160px"
                    Height="27px"
                    AutoPostBack="false"
                    DataValueField="Id"
                    DataTextField="DescricaoGenero">
                </asp:DropDownList>
                <asp:Label ID="lblddl1" runat="server" Text="Label"></asp:Label>
            </li>
            <li>
                <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" CssClass="btnDefault" />

                <asp:Button ID="btnLimpar" runat="server" Text="Clear" OnClick="btnLimpar_Click" CssClass="btnDefault" />

                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja mesmo eliminar este registro?'))return false" CssClass="btnDefault" />
            </li>

            <asp:TextBox ID="txtSearchFilm" runat="server" placeholder="Search By Titulo:" CssClass="searchAdm"></asp:TextBox>
            <asp:Button ID="btnSearchFilm" runat="server" Text="Search" OnClick="btnSearchFilm_Click" CssClass="btnDefault" />
            <asp:Label ID="lblSearchFilm" runat="server" Text=""></asp:Label>

            <asp:TextBox ID="txtFiltro" runat="server" placeholder="Filter By Genre:" AutoCompleteType="Disabled" CssClass="searchAdm"></asp:TextBox>
            <asp:Button ID="btnFiltro" runat="server" Text="Search" OnClick="btnFiltro_Click" CssClass="btnDefault" />
            <asp:Label ID="lblFiltro" runat="server" Text=""></asp:Label>

        </ul>
    </div>


    <%-- gridView --%>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gv1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Opção"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Código" runat="server" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" runat="server" />
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" runat="server" />
            <asp:BoundField DataField="Genero_id" HeaderText="Genero" runat="server" />
            <asp:BoundField DataField="Classificacao_id" HeaderText="Classificacao" runat="server" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="110" ControlStyle-Height="110" />

        </Columns>
    </asp:GridView>
</asp:Content>
