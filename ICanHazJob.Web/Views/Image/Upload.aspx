<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ICanHazJob.Web.ViewModels.ImageViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    <% using (Html.BeginForm("Save", "Image", FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
<fieldset>
    <legend>Create Album</legend>
    <%= Html.EditorFor(x => x) %>
    <input type="file" name="filename" />
    <p>
        <input type="submit" value="Save" />
    </p>
</fieldset>
<% } %>

</asp:Content>
