using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerData"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Value == "" || txtPass.Value == "")
            {
                lblMessage.Text = "All feilds must not be empty";
            }
            else
            {
                Customer customer = new Customer(txtEmail.Value, txtPass.Value);
                if (customer.Login())
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMessage.Text = "login failed. Email or Password is invalid.";
                }
            }
        }
    }
}