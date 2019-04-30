using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Checkout : System.Web.UI.Page
    {
        Customer customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerData"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                customer = (Customer)Session["customerData"];
                txtCustomerID.Value = customer.id.ToString();
                txtOrderAddress.Value = customer.Address;
                txtPhone.Value = customer.Phone;
                txtRecieverName.Value = customer.Name;
            }            
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if(Session["Cart"] == null)
            {
                lblMessage.Text = "Your cart is Empty. Add atleast one product in Cart";
            }
            else
            {
                List<Product> cart = (List<Product>) Session["Cart"];
                DBClient.OrderGenerate(txtCustomerID.Value, txtRecieverName.Value, txtOrderAddress.Value, txtPhone.Value, cart, lblMessage);
                
            }
        }
    }
}