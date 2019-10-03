<%@ Page Title="Pet's Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPet.aspx.cs" Inherits="BusyPet.EditPet" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>Change Pet Information</h1>
            <br />
        </div>
    </div>

    <!-- Content wrapper -->
    <div class="row">

        <!-- Left-side content -->
        <div class="col-md-6">

            <div class="row">
                <div class="col-md-12">
                    <img src="Images/Background-Blue.png" style="max-height: 200px; max-width: 200px;" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <br />
                    <asp:FileUpload runat="server" />
                </div>
            </div>

        </div>

        <!-- Right side content -->
        <div class="col-md-6">

            <!-- Page heading -->
            <div class="row">
                <div class="col-lg-12">
                    <label>Name: </label>
                    <input type="text" id="id_pet_name" runat="server" />
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <label>Type: </label>
                    <input type="text" id="id_pet_type" runat="server" />
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <label>Sex: </label>
                    <input type="text" id="id_pet_sex" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <label>Date of Birth: </label>
                    <input type="text" id="id_pet_dob" runat="server" />
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <button runat="server" class="btn btn-primary" value="Save" onserverclick="EditPet_SaveBtnClick">Save</button>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
