<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="Survey.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %></h2>
    <% using (Html.BeginForm("create", "home"))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <%: Html.ValidationSummary(true) %>
        <p>
            <div class="editor-label">
                Name:
            </div>
            <div class="editor-field">
                <%: Html.TextBox("Name") %>
            </div>
            <div class="editor-label">
                Phone:
            </div>
            <div class="editor-field">
                <%: Html.TextBox("Phone") %>
            </div>
        </p>
        <%foreach (var question in QuestionModel.GetAll())
          {
              Html.RenderPartial("QuestionRadioButton", question);
          } %>
        <input type="submit" value="Create" />
    </fieldset>
    <% } %>
</asp:Content>
