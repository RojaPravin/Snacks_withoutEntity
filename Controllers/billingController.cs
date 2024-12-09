using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Snacks_withoutEntity.Models;

namespace Snacks_withoutEntity.Controllers
{
    public class billingController : Controller
    {
        string dbconnection = @"Data Source = DESKTOP-RNPM1SO; Initial Catalog = Snacks; Integrated Security = True ";
        // GET: billing
        public ActionResult Index()
        {
            List<billing> billingobj = new List<billing>();
            using (SqlConnection con = new SqlConnection(dbconnection)) 
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    billingobj.Add(new billing
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Cost = Convert.ToInt32(reader["Cost"].ToString()),
                        Company = reader["Company"].ToString(),
                    });

                }
                con.Close();
            }
            return View (billingobj);
        }

        // GET: billing/Details/5
        public ActionResult Details(int id)
        {
            billing billingobj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id , con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingobj = new billing
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Cost = Convert.ToInt32(reader["Cost"].ToString()),
                        Company = reader["Company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingobj);
        }

        // GET: billing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: billing/Create
        [HttpPost]
        public ActionResult Create(billing billingobj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_insert '" + billingobj.Name + "'," + billingobj.Cost + ",'" + billingobj.Company + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }

        // GET: billing/Edit/5
        public ActionResult Edit(int id)
        {
            billing billingobj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingobj = new billing
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Cost = Convert.ToInt32(reader["Cost"].ToString()),
                        Company = reader["Company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingobj);
        }

        // POST: billing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, billing billingobj)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_edit " + id + ",'" + billingobj.Name + "'," + billingobj.Cost + ",'" + billingobj.Company + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: billing/Delete/5
        public ActionResult Delete(int id)
        {
            billing billingobj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingobj = new billing
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Cost = Convert.ToInt32(reader["Cost"].ToString()),
                        Company = reader["Company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingobj);
        }

        // POST: billing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, billing billingobj)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_delete " + id ;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
