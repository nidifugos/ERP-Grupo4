<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ERP.Agendamento.Models.PacienteSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pacientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pacientes</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
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
                DataNascimento
            </th>
            <th>
                Peso
            </th>
            <th>
                Altura
            </th>
            <th>
                TipoSanguineo
            </th>
            <th>
                AfiliacaoPai
            </th>
            <th>
                AfiliacaoMae
            </th>
            <th>
                EnderecoResidencial
            </th>
            <th>
                TelefoneResidencial
            </th>
            <th>
                EnderecoComercial
            </th>
            <th>
                TelefoneComercial
            </th>
            <th>
                TelefoneCelular
            </th>
            <th>
                Convenio
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
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
            <td>
                <%: item.Peso %>
            </td>
            <td>
                <%: item.Altura %>
            </td>
            <td>
                <%: item.TipoSanguineo %>
            </td>
            <td>
                <%: item.AfiliacaoPai %>
            </td>
            <td>
                <%: item.AfiliacaoMae %>
            </td>
            <td>
                <%: item.EnderecoResidencial %>
            </td>
            <td>
                <%: item.TelefoneResidencial %>
            </td>
            <td>
                <%: item.EnderecoComercial %>
            </td>
            <td>
                <%: item.TelefoneComercial %>
            </td>
            <td>
                <%: item.TelefoneCelular %>
            </td>
            <td>
                <%: item.Convenio %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

