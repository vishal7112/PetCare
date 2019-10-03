using BusyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusyPet
{
    public partial class PetControl : System.Web.UI.Page
    {
        Utilities ut = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // validate user currently logged in before giving access
            if (Session["User"] == null || ((User)Session["User"]).userId < 1)
            {
                Response.Redirect("~/default", false);
            }
        }
    }
}