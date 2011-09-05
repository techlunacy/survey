<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Survey.Models.QuestionModel>" %>
<table>
    <tr>
        <th>
        </th>
        <th>
            Answer
        </th>
    </tr>
    <%
        if (Model.Answers != null || Model.Answers.Count > 0)%>
    <%{
          foreach (var item in Model.Answers)
          {%>
    <tr>
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
    <%: Html.ActionLink("Create New", "Create","Answer",new {question_id=Model.Id},new{}) %>
</p>
