<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Survey.Models.UserModel>" %>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Name) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Name) %>
    <%: Html.ValidationMessageFor(model => model.Name) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Phone) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Phone) %>
    <%: Html.ValidationMessageFor(model => model.Phone) %>
</div>
