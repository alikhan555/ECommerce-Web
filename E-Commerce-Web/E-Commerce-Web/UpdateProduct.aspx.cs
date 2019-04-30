using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DBClient.FillDropDown(dropCatagory);
            }
        }

        protected void txtProductID_TextChanged(object sender, EventArgs e)
        {
            txtProductID.Focus();
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductStock.Text = "";
            imgProductImg.ImageUrl = null;
            dropCatagory.SelectedIndex = 0;


            if (txtProductID.Text == "")
            {
                lblIDMessage.Text = "Product ID is empty.";
            }
            else if(txtProductID.Text != "")
            {
                Product product = new Product();
                if(product.GetProduct(txtProductID, txtProductName, txtProductPrice, dropCatagory, txtProductStock, imgProductImg))
                {
                    lblIDMessage.Text = "Product exist.";
                }
                else
                {
                    lblIDMessage.Text = "Product ID does not exist.";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            if(product.UpdateProduct(txtProductID.Text, txtProductName.Text, txtProductPrice.Text, dropCatagory.SelectedValue,txtProductStock.Text))
            {
                lblMessage.Text = "Product Updated successfully";
                Reset();
            }
            else
            {
                lblMessage.Text = "Update failed.";
            }
        }
        public void Reset()
        {
            txtProductID.Text = "";
            txtProductID.Focus();
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductStock.Text = "";
            imgProductImg.ImageUrl = null;
            dropCatagory.SelectedIndex = 0;
            txtProductID.Text = "";
            lblIDMessage.Text = "";
        }
    }
}