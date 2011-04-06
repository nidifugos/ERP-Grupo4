<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.AgendamentoSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Cancelar agendamento
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cancelar agendamento</h2>
    <h3>Tem certeza disso?</h3>
    <b>Data e hora</b>: <%: Model.Datahora %><br /><br />
    <b>Descrição</b>: <%: Model.Descricao %><br /><br />
    <b>Estado</b>: <%: Model.Estado %><br /><br />  
    <b>Paciente [Cpf]</b>: <%: Model.PacienteSet.Nome + " [" + Model.PacienteSet.Cpf + "]"  %><br /><br />   
    <b>Especialidade</b>: <%: Model.Especialidade %><br /><br />
    <b>Médico</b>: <%: Model.Medico_Id %><br /><br />
           
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Remover" /> |
		    <%: Html.ActionLink("Voltar para lista", "Index") %>
        </p>
    <% } %>

</asp:Content>

