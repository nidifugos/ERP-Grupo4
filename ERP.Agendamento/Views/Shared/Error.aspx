<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Erro
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>        
        <%: ERP.Agendamento.Controllers.HomeController.ErrorMessage %>
        <br /><br />
        <%: Html.ActionLink("Home", "Index", "Home")%>
    </h3>
</asp:Content>
