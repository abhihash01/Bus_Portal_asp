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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Request.QueryString["src"];
                Label2.Text = Request.QueryString["dest"];
                Label3.Text = Request.QueryString["date"];

            }
        }

        protected void GridView2_SelectedIndexChanged1(object sender, GridViewSelectEventArgs e)
        {
            string busno = GridView2.Rows[e.NewSelectedIndex].Cells[1].Text;
            string  oper = GridView2.Rows[e.NewSelectedIndex].Cells[2].Text;
            string source = GridView2.Rows[e.NewSelectedIndex].Cells[3].Text;
            string dest= GridView2.Rows[e.NewSelectedIndex].Cells[4].Text;
            string date = GridView2.Rows[e.NewSelectedIndex].Cells[5].Text;
            string cost = GridView2.Rows[e.NewSelectedIndex].Cells[6].Text;
            string remainseats= GridView2.Rows[e.NewSelectedIndex].Cells[7].Text;
            string custid =(string) Session["Userid"];
            int seatcheck;
            int.TryParse(remainseats, out seatcheck);
            if (seatcheck == 0)
            {
                //display error message
                Label4.Text = "The selected bus is filled. Please select another bus";

            }
            else
            {
                //make connection to BusMaster and update only seats
                seatcheck = seatcheck - 1;
                string connString = WebConfigurationManager.ConnectionStrings["database"].ConnectionString;
                SqlConnection myConn = new SqlConnection(connString);
                try
                {
                    myConn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = myConn;
                    command.CommandText = "Update BusMasterRoute SET RemainSeats=" + seatcheck.ToString() + " WHERE BusNo=" + busno;

                    command.ExecuteNonQuery();

                   // SqlCommand command1 = new SqlCommand();
                   // command1.Connection = myConn;
                   // command1.CommandText = "Insert INTO BookingsMain (CustId) VALUES (" + custid +")";
                   // command1.ExecuteNonQuery();

                }
                catch { }
                finally { myConn.Close(); }


                string connectionString = WebConfigurationManager.ConnectionStrings["database"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                string sql = "INSERT INTO BookingsMain (Custid,BusNo,Operator,Source,Dest,Date,Cost) VALUES " + " (@custid,@busno,@operator,@source,@dest,@date,@cost)";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@custid", System.Data.SqlDbType.VarChar);
                    param[1] = new SqlParameter("@busno", System.Data.SqlDbType.VarChar);
                    param[2] = new SqlParameter("@operator", System.Data.SqlDbType.VarChar);
                    param[3] = new SqlParameter("@source", System.Data.SqlDbType.VarChar);
                    param[4] = new SqlParameter("@dest", System.Data.SqlDbType.VarChar);
                    param[5] = new SqlParameter("@date", System.Data.SqlDbType.VarChar);
                    param[6] = new SqlParameter("@cost", System.Data.SqlDbType.VarChar);

                    
                    param[0].Value = custid;
                    param[1].Value = busno;
                    param[2].Value = oper;
                    param[3].Value = source;
                    param[4].Value = dest;
                    param[5].Value = date;
                    param[6].Value = cost;


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
                Response.Redirect("~/Bookings.aspx");

                //add field in the new table
            }
            

        }
    }
}