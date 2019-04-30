using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Web.Models
{
    public class Administrator
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool LoginStatus { get; set; }

        public Administrator(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public bool Login()
        {
            string qry = "SELECT * FROM Administrator WHERE email='" + Email + "' AND pass='" + Password + "'";
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
                HttpContext.Current.Session["administratorData"] = this;
                return LoginStatus;
            }
            else
            {
                return LoginStatus;
            }
        }
    }
}