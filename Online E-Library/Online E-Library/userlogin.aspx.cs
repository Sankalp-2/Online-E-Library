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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('Login Successfull');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(1).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                    }

                   // Response.Write("<script>alert('error');</script>");
                    if(TextBox1.Text.Equals("") && TextBox2.Text.Equals(""))
                    {
                        Response.Write("<script>alert('Please enter user id and password');</script>");
                    }
                    else
                    {
                        Response.Redirect("WelcomePage.aspx");
                    }
                    
                }
                else if (TextBox1.Text.Equals(""))
                {
                    Response.Write("<script>alert('Please enter user id');</script>");
                }
                else if (TextBox2.Text.Equals(""))
                {
                    Response.Write("<script>alert('Please enter password');</script>");
                }
                else if (TextBox2.Text.Length < 6 || TextBox2.Text.Length > 9)
                {
                    Response.Write("<script>alert('Enter Password between 6 to 9 character');</script>");
                }

                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
