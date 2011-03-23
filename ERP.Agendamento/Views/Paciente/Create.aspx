<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.PacienteSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cadastro de paciente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cadastro de paciente</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>        
                        
            <b>Nome</b>:
            <%: Html.TextBoxFor(model => model.Nome) %>
            <%: Html.ValidationMessageFor(model => model.Nome) %><br /><br />
            
            <b>Rg</b>:
            <%: Html.TextBoxFor(model => model.Rg) %>
            <%: Html.ValidationMessageFor(model => model.Rg) %><br /><br />

            <b>Cpf</b>:
            <%: Html.TextBoxFor(model => model.Cpf) %>
            <%: Html.ValidationMessageFor(model => model.Cpf) %><br /><br />
            
            <b>Sexo</b>:
            <%: Html.TextBoxFor(model => model.Sexo) %>
            <%: Html.ValidationMessageFor(model => model.Sexo) %><br /><br />
            
            <b>Data de nascimento</b>:
            <%: Html.TextBoxFor(model => model.DataNascimento) %>
            <%: Html.ValidationMessageFor(model => model.DataNascimento) %><br /><br />
            
            <b>Peso (kg)</b>:
            <%: Html.TextBoxFor(model => model.Peso) %>
            <%: Html.ValidationMessageFor(model => model.Peso) %><br /><br />
            
            <b>Altura (cm)</b>:
            <%: Html.TextBoxFor(model => model.Altura) %>
            <%: Html.ValidationMessageFor(model => model.Altura) %><br /><br />
            
            <b>Tipo sanguíneo</b>:
            <%: Html.TextBoxFor(model => model.TipoSanguineo) %>
            <%: Html.ValidationMessageFor(model => model.TipoSanguineo) %><br /><br />
            
            <b>Nome do pai</b>:
            <%: Html.TextBoxFor(model => model.AfiliacaoPai) %>
            <%: Html.ValidationMessageFor(model => model.AfiliacaoPai) %><br /><br />
            
            <b>Nome da mãe</b>:
            <%: Html.TextBoxFor(model => model.AfiliacaoMae) %>
            <%: Html.ValidationMessageFor(model => model.AfiliacaoMae) %><br /><br />
            
            <b>Endereço residencial</b>:
            <%: Html.TextBoxFor(model => model.EnderecoResidencial) %>
            <%: Html.ValidationMessageFor(model => model.EnderecoResidencial) %><br /><br />
            
            <b>Telefone residencial</b>:
            <%: Html.TextBoxFor(model => model.TelefoneResidencial) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneResidencial) %><br /><br />
            
            <b>Endereço comercial</b>:
            <%: Html.TextBoxFor(model => model.EnderecoComercial) %>
            <%: Html.ValidationMessageFor(model => model.EnderecoComercial) %><br /><br />
            
            <b>Telefone celular</b>:
            <%: Html.TextBoxFor(model => model.TelefoneComercial) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneComercial) %><br /><br />
            
            <b>Telefone celular</b>:
            <%: Html.TextBoxFor(model => model.TelefoneCelular) %>
            <%: Html.ValidationMessageFor(model => model.TelefoneCelular) %><br /><br />
            
            <b>Convênio</b>:
            <%: Html.TextBoxFor(model => model.Convenio) %>
            <%: Html.ValidationMessageFor(model => model.Convenio) %><br /><br />
            
            <br />
            <p>
                <input type="submit" value="Create" />
            </p>        

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar para lista", "Index") %>
    </div>

</asp:Content>

