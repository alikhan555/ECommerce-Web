using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class ViewCart : System.Web.UI.Page
    {
        public List<Product> cart = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Cart"] != null)
            {
                cart = (List<Product>)Session["Cart"];
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                lblMessage.Text = "Your cart is Empty. Add atleast one product in Cart";
            }
            else
            {
                if (Session["customerData"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Checkout.aspx");
                }
            }            
        }
    }
}