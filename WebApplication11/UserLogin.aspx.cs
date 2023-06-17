using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

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
                SqlCommand cmd = new SqlCommand("select * from Sign_Up where Trainee_Id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "');</script>");
                        Response.Write("<script>alert('Login Successfull');</script>");

                        Response.Redirect("CompleteInfo.aspx");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }



            }
            catch (Exception )
            {
                Response.Write("<script>alert('ex');</script>");


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");

        }

       /* protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Sign_Up where Trainee_Id='\" + TextBox1.Text.Trim() + \"' AND password='\" + TextBox2.Text.Trim() + \"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('" + dr.GetValue(2).ToString() + "');</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }



            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('ex');</script>");


            }
        }*/

        
    }
}