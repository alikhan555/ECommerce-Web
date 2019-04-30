using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DBClient.FillDropDown(dropCatagory);
            }
        }
              
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtProductName.Value == "" || txtProductPrice.Value == "" || txtProductStock.Value == "" || !fileProductImage.HasFile || dropCatagory.SelectedValue == (-1).ToString())
            {
                lblMessage.Text = "All feilds must be fill.";
            }
            else
            {                
                Product product = new Product(txtProductName.Value, float.Parse(txtProductPrice.Value), dropCatagory.SelectedValue, int.Parse(txtProductStock.Value), fileProductImage);
                product.AddNewProduct();

                Reset();
                lblMessage.Text = "New product add successfully.";
            }
        }

        public void Reset()
        {
            txtProductName.Value = "";
            txtProductStock.Value = "";
            txtProductPrice.Value = "";
            //dropCatagory.SelectedValue = 0.ToString();
        }
    }
}