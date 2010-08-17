<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Upload
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% if (ViewData.ContainsKey("imageFilename"))
   { %>
    <div class="displayImage">
    <img alt="Your Uploaded Image" src="<%= ViewData["imageFilename"] %>" />
    </div>
<% } %>

    <% using (Html.BeginForm("Save", "Image", FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
<fieldset>
    <legend>Upload Photo</legend>
    <input type="file" name="filename" />
    <p>
        <input type="submit" value="Save" />
    </p>
</fieldset>
<% } %>
</asp:Content>
