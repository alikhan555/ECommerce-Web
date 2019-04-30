using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerData"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtPass.Text == "" || txtConfPass.Text == "" || txtAddress.Text == "")
            {
                lblMessage.Text = "All feilds must not be empty.";
            }

            else if (txtPass.Text != txtConfPass.Text)
            {
                lblMessage.Text = "Those passwords didn't match. Try again.";
            }            

            else
            {
                Customer customer = new Customer(txtFullName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, txtPass.Text);
                if (customer.Register())
                {
                    FormReset();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblMessage.Text = "Registration failed.";
                }                
            }
        }

        public void FormReset()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPass.Text = "";
            txtConfPass.Text = "";
            txtAddress.Text = "";
        }
    }
}