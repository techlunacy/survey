<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Survey.Models.QuestionModel>" %>
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
    <%
        if (Model.Answers != null || Model.Answers.Count > 0)%>
    <%{
            foreach (var item in Model.Answers)
            {%>
    <tr>
        <td>
            <%:item.Id%>
        </td>
        <td>
            <%:item.answer%>
</td>
    </tr>

    <%
            }
        }
    %>
</table>
<p>
    <%: Html.ActionLink("Create New", "Create","Answer") %>
</p>
