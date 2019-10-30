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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string l1 = (string)Session["Userid"];
            Label1.Text = l1;
        }
        protected void Grid_del(object sender, GridViewDeleteEventArgs e)
        {
            string bno = (string)e.Values["BusNo"].ToString();
            int noseats=0;

            string connString = WebConfigurationManager.ConnectionStrings["database"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connString);
            try
            {
                myConn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = myConn;
                command.CommandText = "Select RemainSeats FROM BusMasterRoute WHERE BusNo=@bno";
                command.Parameters.AddWithValue("@bno", bno);
                SqlDataReader myReader;
                myReader = command.ExecuteReader();
                myReader.Read();
                noseats = (int)myReader["RemainSeats"];
                //Label2.Text = noseats.ToString();
                noseats++;
                Label2.Text = noseats.ToString();
             
            }
            catch { }
            finally { myConn.Close(); }
            try
            {
                myConn.Open();
                SqlCommand command1 = new SqlCommand();
                command1.Connection = myConn;
                command1.CommandText = "Update BusMasterRoute Set RemainSeats=@remain WHERE BusNo=@bno";
                command1.Parameters.AddWithValue("@bno", bno);
                command1.Parameters.AddWithValue("@remain", noseats.ToString());
                command1.ExecuteNonQuery();
            }
            catch { }
            finally { myConn.Close(); }

        }
    }
}