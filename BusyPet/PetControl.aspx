<%@ Page Title="Pet Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PetControl.aspx.cs" Inherits="BusyPet.PetControl" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>My Pets</h1>
            <br />
        </div>
    </div>

    <div class="row">

        <!-- Pet tiles -->
        <div class="col-md-6">
            <div class="row">

                <!-- FOREACH -->
                <%if (Master.GetSiteUser() != null && Master.GetSiteUser().pets != null)
                    { %>
                <%foreach (BusyPet.Classes.Pet pet in Master.GetSiteUser().pets.Values)
                    { %>
                <div class="col-md-6">
                    <a href="PetDetails.aspx?p=success&task=petdetails&id=<%=pet.petId%>">
                        <div class="div-content jumbo pet-tile">
                            <br />
                            <h3><%=pet.petName%></h3>
                        </div>
                    </a>
                </div>
                <%}%>
                <%}%>

                <!-- ADD PET TILE -->
                <div class="col-md-6">
                    <a href="AddPet.aspx">
                        <div class="div-content jumbo pet-tile">
                            <br />
                            <h1>+</h1>
                            <label>Add Pet</label>
                        </div>
                    </a>
                </div>
            </div>

        </div>

        <!-- Side information -->
        <div class="col-md-6">
            <div class="div-content" style="margin-left: 20px;">
                <h3>Tools</h3>
                <p>Your pets' routines and records will be previewed here!</p>
                <br />
                <a href="Routines.aspx">Routines</a>
                <br />
                <a href="Records.aspx">Records</a>
                <br />
                <p>More coming soon!</p>
            </div>
        </div>

    </div>

</asp:Content>
