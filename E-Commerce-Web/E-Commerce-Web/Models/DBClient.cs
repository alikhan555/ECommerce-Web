using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace E_Commerce_Web.Models
{
    public static class DBClient
    {
        static SqlConnection con;
        static SqlDataReader SDR;
        static DataTable dataTable;

        static DBClient()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-EK2F0PB\SQLEXPRESS;Initial Catalog=ECommerceDB;Integrated Security=True");
        }

        public static bool QueryExecute(string qry)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }

        }

        public static bool Login(string qry, Dictionary<string, string> dict)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SDR = cmd.ExecuteReader();

            if (SDR.HasRows)
            {
                SDR.Read();
                dict["id"] = SDR[0].ToString();
                dict["name"] = SDR["name"].ToString();
                dict["email"] = SDR["email"].ToString();
                dict["phone"] = SDR["phone"].ToString();
                dict["address"] = SDR["address"].ToString();
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }



        public static void FillDropDown(DropDownList dropDownList)          // dropdown
        {
            dropDownList.Items.Clear();

            dataTable = new DataTable();

            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Catagory", con);

            con.Open();

            SDA.Fill(dataTable);
            dropDownList.DataSource = dataTable;
            dropDownList.DataValueField = "CatagoryID";
            dropDownList.DataTextField = "CatagoryName";
            dropDownList.DataBind();

            con.Close();
        }

        public static bool GetProduct(string qry, Dictionary<string, string> dict)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader SDR = cmd.ExecuteReader();
                if (SDR.Read())
                {
                    dict["ProductName"] = SDR["ProductName"].ToString();
                    dict["ProductPrice"] = SDR["ProductPrice"].ToString();
                    dict["ProductCatagoryID"] = SDR["ProductCatagoryID"].ToString();
                    dict["ProductStock"] = SDR["ProductStock"].ToString();
                    dict["ProductImagePath"] = SDR["ProductImagePath"].ToString();
                }
                con.Close();

                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        public static List<Product> GetListOfProducts(string qry)
        {
            con.Open();
            List<Product> products = new List<Product>();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader SDR = cmd.ExecuteReader();
            while (SDR.Read())
            {
                products.Add(new Product(int.Parse(SDR["ProductID"].ToString()), SDR["ProductName"].ToString(), float.Parse(SDR["ProductPrice"].ToString()), SDR["ProductImagePath"].ToString()));
            }
            con.Close();
            return products;
        }

        public static string AddNewProduct(string ProductName, float ProductPrice, string ProductCatagoryID, int ProductStock)
        {
            SqlCommand cmd = new SqlCommand("AddNewProduct_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = ProductName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = ProductPrice;
            cmd.Parameters.Add("@ProductCatagoryID", SqlDbType.Int).Value = ProductCatagoryID;
            cmd.Parameters.Add("@ProductStock", SqlDbType.Int).Value = ProductStock;
            cmd.Parameters.Add("@ProductUpdateDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@ProductImagePath", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            string imagePath = cmd.Parameters["@ProductImagePath"].Value.ToString();
            con.Close();
            return imagePath;
        }

        public static void OrderGenerate(string CustomerID, string RecieverName, string Address, string Phone, List<Product> cartList, Label lblMessage)
        {
            SqlCommand cmd;
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                cmd = new SqlCommand("SPGenerateOrder", con, transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
                cmd.Parameters.Add("@RecieverName", SqlDbType.VarChar, 50).Value = RecieverName;
                cmd.Parameters.Add("@ReceiverAddress", SqlDbType.VarChar).Value = Address;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 11).Value = Phone;
                cmd.Parameters.Add("@DateOrdered", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                int OrderID = int.Parse(cmd.Parameters["@OrderID"].Value.ToString());

                foreach (Product product in cartList)
                {
                    cmd = new SqlCommand("SPCreateOrderDetails", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = product.ProductID;
                    cmd.Parameters.Add("@ProdudctQuentity", SqlDbType.Int).Value = product.Quentity;
                    cmd.ExecuteNonQuery();
                }

                cmd = new SqlCommand("UPDATE [Order] SET TotalPayment = (SELECT SUM(ProdudctQuentity * UnitPrice) FROM OrderDetail WHERE OrderID = '" + OrderID + "') WHERE OrderID = '" + OrderID + "'", con, transaction);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                lblMessage.Text = "Order Proceed Succeddfully";
                HttpContext.Current.Session["Cart"] = null;
            }
            catch
            {
                transaction.Rollback();
                lblMessage.Text = "Order Proceeding failed";
            }
            con.Close();
        }

        public static int CountRecords(string tableName)
        {
            string qry = "SELECT COUNT(*) FROM [" + tableName + "]";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }

        public static void GetFullData(string qry, GridView gridView)
        {
            con.Open();
            dataTable = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter(qry, con);
            SDA.Fill(dataTable);
            con.Close();

            gridView.DataSource = dataTable;
            gridView.DataBind();
        }

        public static DataTable GetFeaturedProductsTable()
        {
            dataTable = new DataTable();
            string qry = "SELECT top 50 percent NoOfSold AS 'No of Sold', ProductID 'Product ID', ProductName AS 'Product Name' , CatagoryName AS 'Catagory', ProductPrice 'Price (Rs)', ProductStock 'Stock (QTY)', CONVERT(varchar, ProductUpdateDate , 23) AS 'Update Date' "+
                         "From Products "+
                         "JOIN Catagory ON ProductCatagoryID = CatagoryID "+
                         "order by NoOfSold desc";

            SqlDataAdapter SDA = new SqlDataAdapter(qry,con);
            con.Open();
            SDA.Fill(dataTable);
            con.Close();
            
            return dataTable;
        }

        public static DataTable GetDataTable(string qry)
        {
            dataTable = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter(qry, con);
            con.Open();
            SDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }


    }
}