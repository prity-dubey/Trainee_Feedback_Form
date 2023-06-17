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
    public partial class SignUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkTraineeExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Trainee ID');</script>");
            }
            else
            {
                signup();
            }

        }
        void signup()
        {
            try
            {
                Response.Write("<script>alert('signup succesfull');</script>");


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into Sign_Up(Email_Id,Trainee_Id,Password,Re_Enter_Password) Values(@Email_Id,@Trainee_Id,@Password,@Re_Enter_Password)", con);
                cmd.Parameters.AddWithValue("@Email_Id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Trainee_Id", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Re_Enter_Password", TextBox3.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('signup succesfull');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }

        }
         bool checkTraineeExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select* from Sign_Up Where Trainee_id='" + TextBox4.Text.Trim() + "';", con);


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


        }
    }