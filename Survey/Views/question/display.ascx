<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Survey.Models.QuestionModel>" %>
<%@ Import Namespace="Survey.Models" %>
<fieldset>
    <div class="display-field">
        <%: Model.Id %>.</div>
    <div class="display-field">
        <%: Model.Question %></div>
    <%foreach (var answer in AnswerModel.LoadByQuestion(Model.Id))
      {%>
    <%=Html.RadioButton(Model.Id.ToString(),answer.Id.ToString())%><%=answer.answer%>
    <%}%>
</fieldset>
