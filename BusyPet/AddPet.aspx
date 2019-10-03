<%@ Page Title="Add Pet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPet.aspx.cs" Inherits="BusyPet.AddPet" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Content wrapper -->
    <div class="row">

        <!-- Left-side content -->
        <div class="col-md-4">

            <!-- Page heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1>Add A Pet</h1>
                    <p>Please enter your pet's information.</p>
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <input type="text" id="id_petname" placeholder="Pet Name" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <select id="id_type" placeholder="Species" runat="server">
                        <option disabled="disabled" selected="selected">Species</option>
                        <option class="dropdown-option">Cat</option>
                        <option class="dropdown-option">Dog</option>
                    </select>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <select id="id_petSex" placeholder="Select Sex" runat="server">
                        <option disabled="disabled" selected="selected">Sex</option>
                        <option class="dropdown-option">Male</option>
                        <option class="dropdown-option">Female</option>
                    </select>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <input type="date" id="id_petDateOfBirth" placeholder="00/00/0000" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <br />
                    <label for="id_more_pets_checkbox">
                    <input runat="server" type="checkbox" id="id_more_pets_checkbox" value="Y_another_pet"/>&nbsp;I have another pet to add.</label>
                    <!--<p class="tiny">Checking this option will keep you on this page after submission so you can add the rest of your pets before exploring all that BusyPet has to offer</p>-->
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <button runat="server" class="btn btn-primary" value="Submit" onserverclick="NewPet_AddBtnClick">Submit</button>
                </div>
            </div>
        </div>

        <!-- Right side content -->
        <div class="col card">
            <div class="div-content">
                <h4>What can you do with BusyPet?</h4>
                <p>After entering your pet's basic information, you will unlock all of the site's features, including...</p>
                <br />
                <ul>
                    <li>Store your pet's personal records (veterinary, pet insurance, etc.)
                    </li>
                    <li>Create custom reminders to take your dog for a walk, to take your cat in for her annual vet checkup, to take your pet to the groomer, or for any of your pet's routines
                    </li>
                    <li>Email or print your stored flies from anywhere
                    </li>
                    <li>Easily access all of your pet's information all in one place anytime you need it
                    </li>
                </ul>
                <br />
                <p>Once you click submit, you can immediately explore these features!</p>
            </div>
        </div>

    </div>

</asp:Content>
