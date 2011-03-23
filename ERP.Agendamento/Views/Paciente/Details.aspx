<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhes</h2>        
    <b>Nome</b>: <%: Model.Nome %><br /><br />
    <b>Rg</b>: <%: Model.Rg %><br /><br />
    <b>Cpf</b>: <%: Model.Cpf %><br /><br />
    <b>Sexo</b>: <%: Model.Sexo %><br /><br />
    <b>Data de nascimento</b>: <%: String.Format("{0:g}", Model.DataNascimento) %><br /><br />
    <b>Peso</b>: <%: Model.Peso %><br /><br />
    <b>Altura</b>: <%: Model.Altura %><br /><br />
    <b>Tipo sanguíneo</b>: <%: Model.TipoSanguineo %><br /><br />
    <b>Pai</b>: <%: Model.AfiliacaoPai %><br /><br />
    <b>Mãe</b>: <%: Model.AfiliacaoMae %><br /><br />
    <b>Endereço residencial</b>: <%: Model.EnderecoResidencial %><br /><br />
    <b>Telefone residencial</b>: <%: Model.TelefoneResidencial %><br /><br />
    <b>Endereço comercial</b>: <%: Model.EnderecoComercial %><br /><br />
    <b>Telefone comercial</b>: <%: Model.TelefoneComercial %><br /><br />
    <b>Telefone celular</b>: <%: Model.TelefoneCelular %><br /><br />
    <b>Convênio</b>: <%: Model.Convenio%><br /><br />       
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Remover", "Delete", new { id=Model.Id })%>
        <%: Html.ActionLink("Voltar à lista", "Index") %>
    </p>

</asp:Content>

