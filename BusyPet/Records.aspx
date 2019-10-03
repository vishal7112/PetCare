<%@ Page Title="Pet Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="BusyPet.PetControl" %>

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

            <!-- Records-->

            <br />

            <div class="row">
                <div class="col-lg-12">
                    <h5>Records</h5>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    Pet Name
                    <input type="text" name="Pet Name" id="id_petname" class="form-control" disabled="disabled" runat="server" />
                    Record Type
                    <input type="text" name="Record Type" id="Text1" class="form-control" placeholder="Record type" runat="server" />
                </div>

            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="file-upload-wrapper">
                        <input type="file" id="input-file-now" class="file-upload" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <input type="button" id="view_files" class="btn btn-primary btn-sm" value="View Files" />
                </div>
            </div>

        </div>
</asp:Content>
