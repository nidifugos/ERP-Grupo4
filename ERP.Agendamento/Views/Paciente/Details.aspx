<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhes</h2>        
    <b>Nome</b>: <%: Model.Nome %><br />
    <b>Rg</b>: <%: Model.Rg %><br />
    <b>Cpf</b>: <%: Model.Cpf %><br />
    <b>Sexo</b>: <%: Model.Sexo %><br />
    <b>Data de nascimento</b>: <%: String.Format("{0:g}", Model.DataNascimento) %><br />
    <b>Peso</b>: <%: Model.Peso %><br />
    <b>Altura</b>: <%: Model.Altura %><br />
    <b>Tipo sanguíneo</b>: <%: Model.TipoSanguineo %><br />
    <b>Pai</b>: <%: Model.AfiliacaoPai %><br />
    <b>Mãe</b>: <%: Model.AfiliacaoMae %><br />
    <b>Endereço residencial</b>: <%: Model.EnderecoResidencial %><br />
    <b>Telefone residencial</b>: <%: Model.TelefoneResidencial %><br />                
    <b>Endereço comercial</b>: <%: Model.EnderecoComercial %><br />
    <b>Telefone comercial</b>: <%: Model.TelefoneComercial %><br />
    <b>Telefone celular</b>: <%: Model.TelefoneCelular %><br />
    <b>Convênio</b>: <%: Model.Convenio%><br />                             
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Remover", "Delete", new { id=Model.Id })%>
        <%: Html.ActionLink("Voltar à lista", "Index") %>
    </p>

</asp:Content>

