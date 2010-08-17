<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ICanHazJob.Web.ViewModels.ImageViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% if (ViewData.ContainsKey("imageFilename"))
   { %>
    <img alt="Your Uploaded Image" src="<%= ViewData["imageFilename"] %>" />
<% } %>


    <h2>Create</h2>
    <% using (Html.BeginForm("Save", "Image", FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
<fieldset>
    <legend>Uploade Photo</legend>
    <input type="file" name="filename" />
    <p>
        <input type="submit" value="Save" />
    </p>
</fieldset>
<% } %>

</asp:Content>
