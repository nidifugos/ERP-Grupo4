<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ERP.Agendamento.Models.PacienteSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pacientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pacientes</h2>

    <p>
        <%: Html.ActionLink("Cadastrar novo", "Create") %>
    </p>
    <table>
        <tr>
            <th></th>            
            <th>
                Nome
            </th>
            <th>
                Rg
            </th>
            <th>
                Cpf
            </th>
            <th>
                Sexo
            </th>
            <th>
                Data de nascimento
            </th>            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Detalhes", "Details", new { id=item.Id })%> |
                <%: Html.ActionLink("Remover", "Delete", new { id=item.Id })%>
            </td>            
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.Rg %>
            </td>
            <td>
                <%: item.Cpf %>
            </td>
            <td>
                <%: item.Sexo %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DataNascimento) %>
            </td>            
        </tr>
    
    <% } %>

    </table>
    

</asp:Content>

