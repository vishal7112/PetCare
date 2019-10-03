<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BusyPet.SignUp" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row sign-up">
        <div class="col-md-12 card">

            <div class="row">
                <div class="col-lg-12">
                    <h1>Create An Account</h1>
                    <p>You will be asked to enter your pet's or pets' information after you sign in.</p>
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <input type="text" id="usernameTextBox" placeholder="Username" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <input type="email" id="emailTextBox" placeholder="Email Address" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <input type="password" id="passwordTextBox" placeholder="Password" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <input type="password" id="confirmPasswordTextBox" placeholder="Confirm Password" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <button runat="server" class="btn btn-primary" value="Submit" onserverclick="SignUp_SubmitBtnClick">Submit</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
