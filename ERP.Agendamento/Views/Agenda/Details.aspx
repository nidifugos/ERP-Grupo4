<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.AgendamentoSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agenda Médica
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <% foreach (KeyValuePair<int, List<ERP.Agendamento.Models.AgendamentoSet>> agendamentosMes in (List<KeyValuePair<int, List<ERP.Agendamento.Models.AgendamentoSet>>>)ViewData["Agendamentos"]){%>

        <h2><%: agendamentosMes.Key %></h2>
        <table>
            <tr>
                <td><b>Data e Hora</b></td>
                <td><b>Paciente</b></td>
                <td><b>Especialidade</b></td>
                <td><b>Estado</b></td>
            </tr>
            <% foreach(ERP.Agendamento.Models.AgendamentoSet agendamento in agendamentosMes.Value){%>
            
            <tr>
                <td><%: agendamento.Datahora%></td>
                <td><%: agendamento.PacienteSet.Nome%></td>
                <td><%: agendamento.Especialidade%></td>
                <td><%: agendamento.Estado%></td>
            </tr>
        <%} %>
        
        </table>
    <%} %>

</asp:Content>

