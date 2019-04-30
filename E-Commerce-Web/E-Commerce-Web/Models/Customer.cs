using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Web.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool LoginStatus { get; set; }

        public Customer(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public Customer(string name, string email, string phone, string address, string password)
        {
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
            this.Password = password;
        }

        public bool Register()
        {
            string qry = "INSERT INTO Customer ([name],phone,[address],email,pass,registrationDate) " +
                         "VALUES('" + Name + "' , '" + Phone + "' , '" + Address + "' , '" + Email + "' , '" + Password + "','" + DateTime.Now + "')";
            if(DBClient.QueryExecute(qry))  // this method is bool, 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Login()
        {
            string qry = "SELECT * FROM Customer WHERE email='"+Email+"' AND pass='"+Password+"'";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            this.LoginStatus = DBClient.Login(qry, dict);
            if (LoginStatus == true)
            {
                this.id = int.Parse(dict["id"]);
                this.Name = dict["name"];
                this.Phone = dict["phone"];
                this.Address = dict["address"];
                this.Email = dict["email"];
                this.Password = null;
                HttpContext.Current.Session["customerData"] = this;
                return LoginStatus;
            }
            else
            {
                return LoginStatus;
            }            
        }
    }
}