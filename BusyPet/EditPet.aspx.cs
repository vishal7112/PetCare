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
    public partial class EditPet : Page
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
                // get information for the current pet from parameters
                try
                {
                    if (Session["Pet"] != null)
                    {
                        id_pet_name.Value = ((Pet)Session["Pet"]).petName.ToString();
                        id_pet_type.Value = ((Pet)Session["Pet"]).petType.ToString();
                        id_pet_sex.Value = ((Pet)Session["Pet"]).petSex.ToString();
                        id_pet_dob.Value = Convert.ToDateTime(((Pet)Session["Pet"]).petDateOfBirth.ToString()).ToString("MM/dd/yyyy");
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

        public void EditPet_SaveBtnClick(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ((Pet)Session["Pet"]).UpdatePet(id_pet_name.Value, id_pet_type.Value, id_pet_sex.Value, id_pet_dob.Value);

                    Response.Redirect("~/PetDetails.aspx", false);
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