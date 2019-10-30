using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_v1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie c1 = Request.Cookies["AdminCookie"];
                if (c1 == null)
                {
                    Response.Redirect("~/LoginPageAdmin.aspx");
                }
                else
                {
                    string adminid = (string)c1["ID"];
                    Label1.Text = "Welcome  " + adminid;
                }

            }
            
        }
    }
}