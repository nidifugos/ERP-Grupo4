<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.AgendamentoSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar agendamento
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar agendamento</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>                            
                                          
            <b>Data e hora</b>:
            <%: Html.TextBoxFor(model => model.Datahora) %>
            <%: Html.ValidationMessageFor(model => model.Datahora) %><br /><br />            

            <b>Descrição</b>:
            <%: Html.TextBoxFor(model => model.Descricao) %>
            <%: Html.ValidationMessageFor(model => model.Descricao) %><br /><br />            
            
            <b>Estado</b>:
            <%: Html.TextBoxFor(model => model.Estado) %>
            <%: Html.ValidationMessageFor(model => model.Estado) %><br /><br />        
            
            <b>Paciente [Cpf]</b>:
            <%: Html.DropDownListFor(model => model.Paciente_Id, ViewData["Paciente_Id"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Paciente_Id) %><br /><br />                        
            
            <b>Especialidade</b>:
            <%: Html.DropDownListFor(model => model.Especialidade, ViewData["Especialidade"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Especialidade) %><br /><br />        

            <b>Médico</b>:
            <%: Html.DropDownListFor(model => model.Medico_Nome, ViewData["Medico_Nome"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Medico_Id) %><br /><br />
            
            <b>Sala</b>:
            <%: Html.TextBoxFor(model => model.Sala_Id) %>
            <%: Html.ValidationMessageFor(model => model.Sala_Id) %><br /><br />

            <p>
                <input type="submit" value="Salvar alterações" />
            </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar à lista", "Index") %>
    </div>

</asp:Content>

