<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Survey.Models.AnswerModel>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                answer
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.answer %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


