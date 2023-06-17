using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class CompleteInfo : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Write("<script>alert('signup succesfull');</script>");


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into Complete_Info_Table(Name,DOB,Contact,Email,College,Course,Department,Guide_Name,Project_Title,Trainee_Id,Password) Values(@Name,@DOB,@Contact,@Email,@College,@Course,@Department,@Guide_Name,@Project_Title,@Trainee_Id,@Password)", con);
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", TextBox3.Text.Trim());


                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@College", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Course", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Department", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Guide_Name", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Project_Title", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@Trainee_Id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox10.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Feedback.aspx");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }

        }
    }
}