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
    public partial class AddPet : Page
    {
        Utilities ut = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // validate user currently logged in before giving access
            if (Master.GetSiteUser() == null || Master.GetSiteUser().userId < 1)
            {
                Response.Redirect("~/default", false);
            }
        }

        public void NewPet_AddBtnClick(object sender, EventArgs e)
        {
            try
            {

                Pet pet = new Pet(Master.GetSiteUser(), id_petname.Value.ToString(), id_type.Value.ToString(), id_petSex.Value.ToString(), id_petDateOfBirth.Value.ToString());

                if (id_more_pets_checkbox.Checked)
                {
                    this.Load += new System.EventHandler(this.Page_Load);
                    Response.Redirect("~/AddPet", false);
                }
                else
                {
                    Response.Redirect("~/PetControl", false);
                }
            }
            catch (Exception exception)
            {
                // log error
                ut.WriteErrorLog(exception, "AddPet.NewPet_AddBtnClick");

                // display user error
                Response.Redirect("~/AddPet.aspx?p=error&task=createPet", false);

            }

        }




    }
}