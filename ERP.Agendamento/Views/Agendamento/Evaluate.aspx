<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Confirmar agendamentos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmar agendamentos</h2>
    
    <table>
        <tr>
            <th></th>            
            <th>
                Data e hora
            </th>
            <th>
                Descrição
            </th>
            <th>
                Estado
            </th>
            <th>
                Paciente
            </th>
            <th>
                Especialidade
            </th>
            <th>
                Medico
            </th>
            <th>
                Sala
            </th>
            <th>
                Telefone Residencial
            </th>
            <th>
                Telefone Comercial
            </th>
            <th>
                Celular
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Confirmar", "Confirm", new { id=item.Id }) %> |
                <%: Html.ActionLink("Cancelar", "Cancel", new { id=item.Id })%>
            </td>            
            <td>
                <%: String.Format("{0:g}", item.Datahora) %>
            </td>
            <td>
                <%: item.Descricao %>
            </td>
            <td>
                <%: item.Estado %>
            </td>
            <td>                                
                <%: item.PacienteSet.Nome + " [" + item.PacienteSet.Cpf + "]" %>                
            </td>
            <td>
                <%: item.Especialidade %>
            </td>
            <td>
                <%: item.Medico_Nome %>
            </td>
            <td>
                <%: item.Sala_Id %>
            </td>
            
            <td>
                <%: item.PacienteSet.TelefoneResidencial %>
            </td>
            <td>
                <%: item.PacienteSet.TelefoneComercial %>
            </td>
            <td>
                <%: item.PacienteSet.TelefoneCelular %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>
