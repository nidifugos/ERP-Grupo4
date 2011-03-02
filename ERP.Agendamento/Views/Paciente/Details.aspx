<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Nome</div>
        <div class="display-field"><%: Model.Nome %></div>
        
        <div class="display-label">Rg</div>
        <div class="display-field"><%: Model.Rg %></div>
        
        <div class="display-label">Cpf</div>
        <div class="display-field"><%: Model.Cpf %></div>
        
        <div class="display-label">Sexo</div>
        <div class="display-field"><%: Model.Sexo %></div>
        
        <div class="display-label">DataNascimento</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.DataNascimento) %></div>
        
        <div class="display-label">Peso</div>
        <div class="display-field"><%: Model.Peso %></div>
        
        <div class="display-label">Altura</div>
        <div class="display-field"><%: Model.Altura %></div>
        
        <div class="display-label">TipoSanguineo</div>
        <div class="display-field"><%: Model.TipoSanguineo %></div>
        
        <div class="display-label">AfiliacaoPai</div>
        <div class="display-field"><%: Model.AfiliacaoPai %></div>
        
        <div class="display-label">AfiliacaoMae</div>
        <div class="display-field"><%: Model.AfiliacaoMae %></div>
        
        <div class="display-label">EnderecoResidencial</div>
        <div class="display-field"><%: Model.EnderecoResidencial %></div>
        
        <div class="display-label">TelefoneResidencial</div>
        <div class="display-field"><%: Model.TelefoneResidencial %></div>
        
        <div class="display-label">EnderecoComercial</div>
        <div class="display-field"><%: Model.EnderecoComercial %></div>
        
        <div class="display-label">TelefoneComercial</div>
        <div class="display-field"><%: Model.TelefoneComercial %></div>
        
        <div class="display-label">TelefoneCelular</div>
        <div class="display-field"><%: Model.TelefoneCelular %></div>
        
        <div class="display-label">Convenio</div>
        <div class="display-field"><%: Model.Convenio %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

