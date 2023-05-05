<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Label ID="lblMessage" runat="server" Text="Manage User" class="txtAdm"></asp:Label>
    <%-- formulario --%>
    <div>
        <ul>
            <li>
                <asp:TextBox ID="txtId" runat="server" placeholder="Id" Width="90%" class="campoAdm" ></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblNome" runat="server" Text="" ></asp:Label>
            </li>
            <li>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" MaxLength="6" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:TextBox ID="txtDtNasc" runat="server" placeholder="Data de Nascimento" onkeypress="$(this).mask('00/00/0000')" Width="90%" class="campoAdm"></asp:TextBox>
                <asp:Label ID="lblDtNasc" runat="server" Text=""></asp:Label>
            </li>
            <li> 
                <asp:DropDownList 
                    ID="ddl1" 
                    runat="server"
                    width="160px"
                    height="27px"
                    AutoPostBack="false"
                    DataValueField="Id"
                    DataTextField="Descricao"
                    class="campoAdm2">

                </asp:DropDownList>
            </li>
            <li>
                <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" CssClass="btnDefault"/>

                <asp:Button ID="btnLimpar" runat="server" Text="Clear" OnClick="btnLimpar_Click" CssClass="btnDefault"/>

                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja mesmo eliminar este registro?'))return false" CssClass="btnDefault"/>
            </li>
            <li>
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search By Name:" CssClass="searchAdm"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnDefault"/>
                <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>

            </li>
        </ul>
    </div>
    
    
    <%-- gridView --%>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gv1_SelectedIndexChanged"  GridLines="None">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Opção"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Senha" HeaderText="Senha" />
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="TipoUsuario_id" HeaderText="Permissão" />

            </Columns>
    </asp:GridView>



</asp:Content>