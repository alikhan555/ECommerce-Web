using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public static List<Product> products;
        public List<Product> cartList;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMostFeaturedProducts();
            }

            // Add Product to card
            if (Request.QueryString.AllKeys.Contains("ProductID") && Request.QueryString.AllKeys.Contains("action"))
            {
                AddToCart();
            }

            if (Session["customerData"] != null)
            {
                Customer customer = (Customer)Session["customerData"];
                lblUserName.Text = customer.Name;
                HyperLogin.Text = "";
                hyperSignUp.Text = "";
                lblOR.Text = "";
                btnLogout.Visible = true;
            }
        }

        public void LoadMostFeaturedProducts()
        {
            string qry = "SELECT TOP 16 * FROM Products ORDER BY NoOfSold DESC";
            products = DBClient.GetListOfProducts(qry);
            lblProductHeadder.Text = "Featured Product";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string qry =    "SELECT ProductID,ProductName,ProductPrice,ProductImagePath, CatagoryID, CatagoryName " +
                            "FROM Products " +
                            "join Catagory " +
                            "ON Products.ProductCatagoryID = Catagory.CatagoryID " +
                            "WHERE Products.ProductName like '%"+txtSearch.Text+ "%' OR Catagory.CatagoryName like '%" + txtSearch.Text + "%'";
            products = DBClient.GetListOfProducts(qry);
            lblProductHeadder.Text = "Searched Products";
        }

        public void AddToCart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Product>();
            }

            string ProductID = Request.QueryString["ProductID"];
            string ProductName = Request.QueryString["ProductName"];
            string ProductPrice = Request.QueryString["ProductPrice"];
            bool alreadyExist = false;

            cartList = (List<Product>)Session["Cart"];

            foreach (Product product in cartList)
            {
                if (product.ProductID == int.Parse(ProductID))
                {
                    product.Quentity++;
                    alreadyExist = true;
                    break;
                }
            }

            if (alreadyExist == false)
            {
                cartList.Add(new Product(int.Parse(ProductID), ProductName, float.Parse(ProductPrice)));
            }

            //temporary show cart list
            //foreach(Product product in cartList)
            //{
            //    Response.Write("product ID : "+product.ProductID+"  ProductName : "+product.ProductName+"  ProductPrice : "+product.ProductPrice+"  ProductQTY : "+product.Quentity+"");
            //}

            // qry clean
            Response.Redirect("Default.aspx");
        }

        protected void btnEmptyCart_Click(object sender, EventArgs e)
        {
            Session["Cart"] = null;
        }
    }
}