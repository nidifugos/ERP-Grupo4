﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Consolidar agendamentos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Consolidar agendamentos</h2>
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
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Detalhes", "Details", new { id=item.Id })%> |
                <%: Html.ActionLink("Remover", "Delete", new { id=item.Id })%>
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
        </tr>
    
    <% } %>

    </table>
</asp:Content>
