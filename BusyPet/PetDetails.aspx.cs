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
    public partial class PetDetails : Page
    {
        Utilities ut = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // validate user currently logged in before giving access
            if (Master.GetSiteUser() == null || Master.GetSiteUser().userId < 1)
            {
                Response.Redirect("~/default", false);
            }
            else
            {
                if (Request.QueryString != null && Request.QueryString["task"] == "petdetails")
                {
                    // find pet id in user's pets dictionary to set it as the current pet to display
                    int paramId = Convert.ToInt16(Request.QueryString["id"]);

                    foreach (Pet pet in Master.GetSiteUser().pets.Values)
                    {
                        if (pet.petId == paramId)
                        {
                            Session["Pet"] = pet;
                            break;
                        }
                    }
                }

                // get information for the current pet from parameters
                try
                {
                    // get pet clicked on
                    if (Session["Pet"] != null)
                    {
                        id_pet_name_header.InnerText = ((Pet)Session["Pet"]).petName.ToString();
                        id_pet_type.InnerText = ((Pet)Session["Pet"]).petType.ToString();
                        id_pet_sex.InnerText = ((Pet)Session["Pet"]).petSex.ToString();
                        id_dob.InnerText = ((Pet)Session["Pet"]).petDateOfBirth.ToString();
                    }
                    else
                    {
                        throw new Exception("No pet object found.");
                    }
                }
                catch (Exception ex)
                {
                    // log error
                    ut.WriteErrorLog(ex, "PetDetails.Page_Load");

                    // display user error
                    Response.Redirect("~/PetControl.aspx?p=error&task=petDetails", false);
                }
            }
        }

        public void PetDetails_EditBtnClick(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                try
                {
                    Response.Redirect("~/EditPet", false);
                }
                catch (Exception exception)
                {
                    // log error
                    ut.WriteErrorLog(exception, "PetDetails.PetDetails_EditBtnClick");

                    // display user error
                    Response.Redirect("~/PetControl.aspx?p=error&task=petDetails", false);

                }
            }
        }

    }
}