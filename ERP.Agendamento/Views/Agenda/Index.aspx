<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ERP.Agendamento.Models.AgendamentoSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agenda Médica
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Agenda Médica</h2>

    <table>
        <tr>
            <td>Lista de médicos</td>
            <td></td>
        </tr>
        <% foreach (var item in (List<IGrouping<int, ERP.Agendamento.Models.AgendamentoSet>>)ViewData["Medicos"]){%>

        <tr>
            <td><%: item.Key %></td>
            <td><%: Html.ActionLink("Ver Agenda", "Details", new { id=item.Key })%></td>
        </tr>

        <%} %>
    </table>

</asp:Content>

