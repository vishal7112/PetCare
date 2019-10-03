<%@ Page Title="Pet Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routines.aspx.cs" Inherits="BusyPet.PetControl" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>My Pets</h1>
        </div>
    </div>

    <div class="row">

        <div class="col-md-6">

            <p>Your pets' routines and records will be previewed here!</p>

            <!-- Routines-->
                <div class="row">
                    <div class="col-lg-12">
                        <h5>Routines</h5>
                    </div>
                </div>

                 <div class="row">
                <div class="col-lg-12">
                    Ener your Routine information
                    <input type="text" id="id_name" class="form-control" placeholder="Routine Name" runat="server" />
                </div>
            </div>

                 <div class="row">
                    <div class="col-lg-12">
                           <input type="text" id="routine" class="form-control" placeholder="Routine Description" runat="server"/>
                       </div>
                </div>

                <div class="row">
                <div class="col-lg-12">
                    Pick a date and time
                    <input type="date" id="id_date" class="form-control" placeholder="00/00/0000" runat="server" />
                    <input  type="time" id="id_time" class="form-control" runat="server">
                </div>
            </div>

                <div class="row">
                <div class="col-lg-12">
                    <button runat="server" class="btn btn-primary" value="Submit">Add another Routine</button>
                </div>
            </div>

            </div>

    </div>

</asp:Content>
