using BusyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BusyPet
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // display hidden nav links if user is logged in
                if (Session["User"] != null)
                {
                    id_pets_nav_link.Style.Add("display", "inline-block");
                    id_logout_nav_link.Style.Add("display", "inline-block");
                }

                // display user success or error messages if parameters are passed in for indication
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["p"].ToLower() == "success")
                    {
                        // display success message to the user
                        if (Request.QueryString["task"].ToLower() == "register")
                        {
                            user_message.InnerText = "Your account has been created! Please sign in.";
                            user_message_div.Visible = true;
                            user_message_icon.Visible = true;
                        }
                        else if (Request.QueryString["task"].ToLower() == "logout")
                        {
                            Session["User"] = null;

                            // have to specify since we don't reload here
                            id_pets_nav_link.Style.Add("display", "none");
                            id_logout_nav_link.Style.Add("display", "none");

                            user_message.InnerText = "You have been signed out.";
                            user_message_div.Visible = true;
                            user_message_icon.Visible = true;
                        }
                    }
                    else if (Request.QueryString["p"].ToLower() == "error")
                    {
                        // display error message to user
                        if (Request.QueryString["task"].ToLower() == "signin")
                        {
                            user_message.InnerText = "There was a problem signing you in. Please try again or visit our Contact page to request assistance.";
                            user_message_div.Visible = true;
                            user_error_icon.Visible = true;
                        }
                        else if (Request.QueryString["task"].ToLower() == "register")
                        {
                            user_message.InnerText = "Your account could not be created. That account or login name might already exist. If you need help, please visit our Contact page to request assistance.";
                            user_message_div.Visible = true;
                            user_error_icon.Visible = true;
                        }
                        else if (Request.QueryString["Task"].ToLower() == "createPet")
                        {
                            user_message.InnerText = "Your pet could not be created. Please try again or visit our Contact page to request assistance.";
                            user_message_div.Visible = true;
                            user_error_icon.Visible = true;
                        }
                        else if (Request.QueryString["Task"].ToLower() == "petDetails")
                        {
                            user_message.InnerText = "There was a problem retrieving your pet's information. Please try again or visit our Contact page to request assistance.";
                            user_message_div.Visible = true;
                            user_error_icon.Visible = true;
                        }
                    }
                }
            }
        }

        public User GetSiteUser()
        {
            return (User)Session["User"];
        }

        public bool SetSiteUser(User inUser)
        {
            try
            {
                // updates the current site user with the login user and their credentials as attributes
                Session["User"] = inUser;

                // finds the user in the database and updates the instance with the rest of their info
                ((User)Session["User"]).FindUser();

                // check that the user was found in the database and the instance was updated
                if (((User)Session["User"]).userId < 1)
                {
                    // return an indication that the user instance was not found or updated
                    return false;
                }

                // lets the caller know that the process was successful
                return true;
            }
            catch (Exception e)
            {
                // display login error to user
                Response.Redirect("~/Default.aspx?p=error&task=existingemail", false);

                // return indication that there was a problem
                return false;
            }
        }
    }
}