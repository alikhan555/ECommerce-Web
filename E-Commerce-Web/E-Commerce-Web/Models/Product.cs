using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace E_Commerce_Web.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public float ProductPrice { get; set; }

        public string ProductCatagoryID { get; set; }

        public int ProductStock { get; set; }

        public int NoOfSold { get; set; }

        public string ProductImagePath { get; set; }

        public int Quentity { get; set; }

        public DateTime ProductUpdateDate { get; set; }

        public FileUpload ImageUpload { get; set; }

        public Product()
        {

        }

        public Product(int ProductID, string ProductName, float ProductPrice)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.Quentity = 1;
        }

        public Product(int ProductID, string ProductName, float ProductPrice, string ProductImagePath)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.ProductCatagoryID = ProductCatagoryID;
            this.ProductImagePath = ProductImagePath;
        }

        public Product(string ProductName, float ProductPrice, string ProductCatagoryID, int ProductStock, FileUpload ImageUpload)
        {
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.ProductCatagoryID = ProductCatagoryID;
            this.ProductStock = ProductStock;
            this.ImageUpload = ImageUpload;
        }
        
        public void AddNewProduct()
        {
            string filePath = DBClient.AddNewProduct(ProductName, ProductPrice, ProductCatagoryID, ProductStock);
            ImageUpload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(filePath));
        }

        public bool GetProduct(TextBox ProductID, TextBox ProductName, TextBox ProductPrice, DropDownList ProductCatagoryID, TextBox ProductStock, Image ProductImagePath)
        {
            string qry = "SELECT * FROM Products WHERE ProductID = '" + ProductID.Text + "'";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if(DBClient.GetProduct(qry, dict))
            {
                ProductName.Text = dict["ProductName"];
                ProductPrice.Text = dict["ProductPrice"];
                ProductCatagoryID.SelectedValue = dict["ProductCatagoryID"];
                ProductStock.Text = dict["ProductStock"];
                ProductImagePath.ImageUrl = dict["ProductImagePath"];

                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool UpdateProduct(string ProductID, string ProductName, string ProductPrice, string ProductCatagoryID, string ProductStock)
        {
            string qry = "UPDATE Products SET ProductName='"+ProductName+ "' , ProductPrice='"+ ProductPrice + "' , ProductCatagoryID='"+ ProductCatagoryID + "' , ProductStock='"+ ProductStock + "' WHERE ProductID='"+ ProductID + "'";

            if (DBClient.QueryExecute(qry))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}