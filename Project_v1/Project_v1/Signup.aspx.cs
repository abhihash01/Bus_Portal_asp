using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Project_v1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ExecuteInsert(string Userid, string Password)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["database"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "INSERT INTO LoginClient (Userid,Password) VALUES " + " (@UserName,@Password)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Username", System.Data.SqlDbType.VarChar);
                param[1] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
 

                param[0].Value = Userid;
                param[1].Value = Password;
               

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExecuteInsert(TextBox1.Text, TextBox2.Text);
            //Response.Redirect("~/CustomerLogin.aspx");
            Label2.Text = "transfereing to client page";
        }

    }
}