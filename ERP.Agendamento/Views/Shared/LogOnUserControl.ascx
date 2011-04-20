<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    if (Session["logged"] != "")
    {
%>
<b>
<%: 
        Session["logged"]
%>
        </b><br />
<%:     
        Html.ActionLink("Logoff", "LogOff", "Account")
%>
<%        
    }
    else
    {
%>
<%:     Html.ActionLink("Login", "LogOn", "Account")%>
<%
    }
%>