<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ICanHazJob.Web.ViewModels.ImageViewModel>" %>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Filename) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Filename) %>
                <%= Html.ValidationMessageFor(model => model.Filename) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>


