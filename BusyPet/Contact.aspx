<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BusyPet.Contact" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br />
    <h3>We don't bite!</h3>
    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
    </address>
</asp:Content>
