<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Agendamento.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Registro
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Criar uma nova conta</h2>
    <p>
        Preencha o formulário a seguir para criar sua conta.
    </p>    

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "A conta não pôde ser criada.") %>
        <div>
            <fieldset>
                <legend>Informações sobre a conta</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>                                
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>                
                <p>
                    <input type="submit" value="Registrar" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
