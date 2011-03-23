<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Remover paciente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Remover paciente</h2>
    <h3>Tem certeza que deseja remover este paciente?</h3>
    <b>Nome</b>: <%: Model.Nome %><br /><br />
    <b>Rg</b>: <%: Model.Rg %><br /><br />
    <b>Cpf</b>: <%: Model.Cpf %><br /><br />
    <b>Sexo</b>: <%: Model.Sexo %><br /><br />
    <b>Data de nascimento</b>: <%: String.Format("{0:g}", Model.DataNascimento) %><br /><br />

    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Remover" /> |
		    <%: Html.ActionLink("Voltar para lista", "Index") %>
        </p>
    <% } %>

</asp:Content>

