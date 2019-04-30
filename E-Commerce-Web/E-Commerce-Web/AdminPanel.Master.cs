using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class AdminPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administratorData"] == null)
            {
                Response.Redirect("Admin.aspx");
            }
            else if (Session["administratorData"] != null)
            {
                Administrator administrator = (Administrator)Session["administratorData"];
                lblAdminName.Text = administrator.Name + " (" + administrator.id + ")";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Admin.aspx");
        }
    }
}