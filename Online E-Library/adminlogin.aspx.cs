using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_E_Library
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Invalid Credentials');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from admin_login_tbl where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "');</script>");
                        Response.Write("<script>alert('Successful login');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                        //Session["status"] = dr.GetValue(10).ToString();
                    }
                        Response.Redirect("AdminHomePage.aspx");
                }

                else if(TextBox1.Text.Equals("") && TextBox2.Text.Equals(""))
                {
                    Response.Write("<script>alert('Please input ID and Password');</script>");
                }
                else if (TextBox1.Text.Equals(""))
                {
                    //Response.Redirect("AdminHomePage.aspx");
                    Response.Write("<script>alert('Please input ID');</script>");

                }
                else if(TextBox2.Text.Equals(""))
                {
                    Response.Write("<script>alert('Please input Password');</script>");
                }

                else
                {
                    //Response.Write("<script>alert('Invalid Admin');</script>");
                   Response.Write("<script>alert('Invalid Admin Credential');</script>");
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}