using BusyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BusyPet
{
    public partial class _Default : Page
    {
        Utilities ut = new Utilities();

        protected void Page_Load(object sender, EventArgs e) {}

        public void SignIn_SubmitBtnClick(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // how to get the global site user (should be null info for now / don't need it here):
                //User user = Master.GetSiteUser();

                try
                {
                    string inEmail = emailTextBox.Value.ToString();
                    byte[] inPass = ut.ConvertStringToBytes(passwordTextBox.Value.ToString());

                    // TODO input validation

                    User userInstance = new Classes.User(inEmail, inPass);

                    // update site's current user with the logged in user
                    if (Master.SetSiteUser(userInstance) == true)
                    {
                        Session["User"] = userInstance;

                        // find and update the user's pets to display them
                        userInstance.GetPets();

                        // redirect user to the pet page once signed in
                        Response.Redirect("~/PetControl", false);
                    }
                    else
                    {
                        throw new Exception("Could not update user instance in Default.SignIn_SubmitBtnClick.");
                    }
                }
                catch (Exception ex)
                {
                    // display login error to user
                    Response.Redirect("~/Default.aspx?p=error&task=signin", false);

                    // TODO log error to database
                    ut.WriteErrorLog(ex, "Default.SignIn_SubmitBtnClick");
                }
            }
        }
    }
}