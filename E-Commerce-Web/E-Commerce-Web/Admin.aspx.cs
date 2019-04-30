using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administratorData"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(inputEmail.Value == "" || inputPassword.Value == "")
            {
                lblMessage.Text = "All feilds must be fill.";
            }
            else
            {
                Administrator administrator = new Administrator(inputEmail.Value, inputPassword.Value);
                if (administrator.Login())
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Login Failed. Username or Password is invalid.";
                }
            }
        }
    }
}