<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cadastro de paciente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cadastro de paciente</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Informações</legend>                        
                        
            <b><%: Html.LabelFor(model => model.Nome) %></b>:
            <%: Html.TextBoxFor(model => model.Nome) %>
            <%: Html.ValidationMessageFor(model => model.Nome) %><br />       
            
            <b><%: Html.LabelFor(model => model.Rg) %></b>:
            <%: Html.TextBoxFor(model => model.Rg) %>
            <%: Html.ValidationMessageFor(model => model.Rg) %><br />

            <b><%: Html.LabelFor(model => model.Cpf) %></b>:
            <%: Html.TextBoxFor(model => model.Cpf) %>
            <%: Html.ValidationMessageFor(model => model.Cpf) %><br />
            
            <b><%: Html.LabelFor(model => model.Sexo) %></b>:
            <%: Html.TextBoxFor(model => model.Sexo) %>
            <%: Html.ValidationMessageFor(model => model.Sexo) %><br />
            
            <b><%: Html.LabelFor(model => model.DataNascimento) %></b>:
            <%: Html.TextBoxFor(model => model.DataNascimento) %>
            <%: Html.ValidationMessageFor(model => model.DataNascimento) %><br />
            
            <b><%: Html.LabelFor(model => model.Peso) %></b>:
            <%: Html.TextBoxFor(model => model.Peso) %>
            <%: Html.ValidationMessageFor(model => model.Peso) %><br />
            
            <b><%: Html.LabelFor(model => model.Altura) %></b>:
            <%: Html.TextBoxFor(model => model.Altura) %>
            <%: Html.ValidationMessageFor(model => model.Altura) %><br />
            
            <b><%: Html.LabelFor(model => model.TipoSanguineo) %></b>:
            <%: Html.TextBoxFor(model => model.TipoSanguineo) %>
            <%: Html.ValidationMessageFor(model => model.TipoSanguineo) %><br />
            
            <b><%: Html.LabelFor(model => model.AfiliacaoPai) %></b>:
            <%: Html.TextBoxFor(model => model.AfiliacaoPai) %>
            <%: Html.ValidationMessageFor(model => model.AfiliacaoPai) %><br />
            
            <b><%: Html.LabelFor(model => model.AfiliacaoMae) %></b>:
            <%: Html.TextBoxFor(model => model.AfiliacaoMae) %>
            <%: Html.ValidationMessageFor(model => model.AfiliacaoMae) %><br />
            
            <b><%: Html.LabelFor(model => model.EnderecoResidencial) %></b>:
            <%: Html.TextBoxFor(model => model.EnderecoResidencial) %>
            <%: Html.ValidationMessageFor(model => model.EnderecoResidencial) %><br />
            
            <b><%: Html.LabelFor(model => model.TelefoneResidencial) %></b>:
            <%: Html.TextBoxFor(model => model.TelefoneResidencial) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneResidencial) %><br />
            
            <b><%: Html.LabelFor(model => model.EnderecoComercial) %></b>:
            <%: Html.TextBoxFor(model => model.EnderecoComercial) %>
            <%: Html.ValidationMessageFor(model => model.EnderecoComercial) %><br />
            
            <b><%: Html.LabelFor(model => model.TelefoneComercial) %></b>:
            <%: Html.TextBoxFor(model => model.TelefoneComercial) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneComercial) %><br />
            
            <b><%: Html.LabelFor(model => model.TelefoneCelular) %></b>:
            <%: Html.TextBoxFor(model => model.TelefoneCelular) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneCelular) %><br />
            
            <b><%: Html.LabelFor(model => model.Convenio) %></b>:
            <%: Html.TextBoxFor(model => model.Convenio) %>
            <%: Html.ValidationMessageFor(model => model.Convenio) %><br />
            
            <br />
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar para lista", "Index") %>
    </div>

</asp:Content>

