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

    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        // sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkMemberExists())
            {

                Response.Write("<script>alert('User Already Exist with this User ID, try other ID');</script>");
                
            }
            else if (TextBox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Name can not be blank');</script>");
            }
            else if (TextBox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Date can not be blank');</script>");
            }
            else if (TextBox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Date can not be blank');</script>");
            }
            else if (TextBox3.Text.Equals(""))
            {
                Response.Write("<script>alert('Contack No can not be blank');</script>");
            }
            else if (TextBox4.Text.Equals(""))
            {
                Response.Write("<script>alert('Email can not be blank');</script>");
            }
            else if (TextBox6.Text.Equals(""))
            {
                Response.Write("<script>alert('City can not be blank');</script>");
            }
            else if (TextBox7.Text.Equals(""))
            {
                Response.Write("<script>alert('Pincode can not be blank');</script>");
            }
            else if (TextBox5.Text.Equals(""))
            {
                Response.Write("<script>alert('Description can not be blank');</script>");
            }
            else if (TextBox8.Text.Equals(""))
            {
                Response.Write("<script>alert('Please enter ID');</script>");
            }
            else if (TextBox9.Text.Equals(""))
            {
                Response.Write("<script>alert('Please input Password');</script>");
            }
            else if (TextBox9.Text.Length < 6 || TextBox9.Text.Length > 9)
            {
                Response.Write("<script>alert('Enter Password between 6 to 9 character');</script>");
            }
            else
            {
                signUpNewUser();
            }
        }

        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_master_tbl where user_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewUser()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO user_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,user_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@user_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login page to Login');</script>");
                Response.Redirect("userlogin.aspx");
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           // Response.Redirect("userlogin.aspx");
        }

       
    }
}
