<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Survey.Models.QuestionModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Id
            </th>
            <th>
                Question
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Ajax.ActionLink("Answers", "details","Question", new { id=item.Id },new AjaxOptions(){InsertionMode = InsertionMode.InsertAfter,UpdateTargetId = ("AnswerList"+item.Id.ToString())})%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Value %>
                <div id="<%=("AnswerList"+item.Id.ToString()) %>">
                </div>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
