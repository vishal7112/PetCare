using BusyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusyPet
{
    public partial class SignUp: Page
    {
        Utilities ut = new Utilities();

        protected void Page_Load(object sender, EventArgs e) {}

        public void SignUp_SubmitBtnClick(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                try
                {
                    // TODO input validation
                    // TODO redirect with specific error message for user if input is invalid

                    // create new user instance to store the user's information in the database
                    User user = new User(usernameTextBox.Value.ToString(), emailTextBox.Value.ToString(), ut.ConvertStringToBytes(passwordTextBox.Value.ToString()));
                    

                    // need to show confirmation message + ask them to sign in
                    // pass in parameter to tell this message to be displayed on postback
                    // redirect to home page, telling the page to display the confirmation message
                    Response.Redirect("~/Default.aspx?p=success&task=register", false);
                }
                catch (Exception exception)
                {
                    // log error
                    ut.WriteErrorLog(exception, "SignUp.SignUp_SubmitBtnClick");

                    // display user error
                    Response.Redirect("~/Default.aspx?p=error&task=register", false);
                }
            }
        }

        public void DuplicateEmailsUsed(Exception ex)
        {

        }
    }
}