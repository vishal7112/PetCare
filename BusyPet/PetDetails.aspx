<%@ Page Title="Pet's Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PetDetails.aspx.cs" Inherits="BusyPet.PetDetails" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>View Pet Information</h1>
            <br />
        </div>
    </div>

    <!-- Content wrapper -->
    <div class="row">

        <!-- Left-side content -->
        <div class="col-md-6">
            <img src="Images/Background-Blue.png" style="max-height: 200px; max-width: 200px;" />
        </div>

        <!-- Right side content -->
        <div class="col-md-6">

            <!-- Page heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h2 id="id_pet_name_header" runat="server"></h2>
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <label>Type: </label>
                    <p id="id_pet_type" runat="server"></p>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <label>Sex: </label>
                    <p id="id_pet_sex" runat="server"></p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <label>Date of Birth: </label>
                    <p id="id_dob" runat="server"></p>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <button runat="server" class="btn btn-primary" value="Edit" onserverclick="PetDetails_EditBtnClick">Change Info</button>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
