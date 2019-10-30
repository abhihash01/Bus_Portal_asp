using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_v1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Userid"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                else
                {
                    string adminid = (string)Session["Userid"];
                    Label1.Text = "Welcome  " + adminid;
                    
                    
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string source = DropDownList1.SelectedItem.Text.ToString();
            string dest= DropDownList2.SelectedItem.Text.ToString();
            string date = TextBox1.Text.ToString();
            Response.Redirect("~/LookNSelectBuses.aspx?src=" + source + "&dest=" + dest + "&date=" + date);
        }
    }
}