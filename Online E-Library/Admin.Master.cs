using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_E_Library
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == " ")
                {
                    LinkButton2.Visible = true; // admin login link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton5.Visible = false; // hello admin link 
                }
                else if (Session["role"] == "admin")
                {
                    LinkButton2.Visible = false; // user login link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton5.Visible = true; // hello admin link button
                    LinkButton5.Text = "Hello " + Session["username"].ToString();


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            

            LinkButton2.Visible = true; // user login link button
            
            LinkButton3.Visible = false; // logout link button
            LinkButton5.Visible = false; // hello admin link button
            Response.Redirect("adminlogin.aspx");

        }
    }
}