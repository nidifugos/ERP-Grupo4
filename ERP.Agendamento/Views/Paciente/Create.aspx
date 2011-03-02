<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nome) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nome) %>
                <%: Html.ValidationMessageFor(model => model.Nome) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Rg) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Rg) %>
                <%: Html.ValidationMessageFor(model => model.Rg) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Cpf) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Cpf) %>
                <%: Html.ValidationMessageFor(model => model.Cpf) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sexo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sexo) %>
                <%: Html.ValidationMessageFor(model => model.Sexo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DataNascimento) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DataNascimento) %>
                <%: Html.ValidationMessageFor(model => model.DataNascimento) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Peso) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Peso) %>
                <%: Html.ValidationMessageFor(model => model.Peso) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Altura) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Altura) %>
                <%: Html.ValidationMessageFor(model => model.Altura) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TipoSanguineo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TipoSanguineo) %>
                <%: Html.ValidationMessageFor(model => model.TipoSanguineo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AfiliacaoPai) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AfiliacaoPai) %>
                <%: Html.ValidationMessageFor(model => model.AfiliacaoPai) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AfiliacaoMae) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AfiliacaoMae) %>
                <%: Html.ValidationMessageFor(model => model.AfiliacaoMae) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EnderecoResidencial) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EnderecoResidencial) %>
                <%: Html.ValidationMessageFor(model => model.EnderecoResidencial) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TelefoneResidencial) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TelefoneResidencial) %>
                <%: Html.ValidationMessageFor(model => model.TelefoneResidencial) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EnderecoComercial) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EnderecoComercial) %>
                <%: Html.ValidationMessageFor(model => model.EnderecoComercial) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TelefoneComercial) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TelefoneComercial) %>
                <%: Html.ValidationMessageFor(model => model.TelefoneComercial) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TelefoneCelular) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TelefoneCelular) %>
                <%: Html.ValidationMessageFor(model => model.TelefoneCelular) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Convenio) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Convenio) %>
                <%: Html.ValidationMessageFor(model => model.Convenio) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

