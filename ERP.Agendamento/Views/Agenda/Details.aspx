<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.AgendamentoSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agenda Médica
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <h2>Detalhes</h2>
    <b>Data e hora</b>: <%: String.Format("{0:g}", Model.Datahora) %><br /><br />
    <b>Descrição</b>: <%: Model.Descricao %><br /><br />
    <b>Estado</b>: <%: Model.Estado %><br /><br />
    <b>Paciente</b>: <%: Model.Paciente_Id %><br /><br />
    <b>Médico</b>: <%: Model.Medico_Id %><br /><br />
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Voltar para lista", "Index") %>
    </p>

</asp:Content>

