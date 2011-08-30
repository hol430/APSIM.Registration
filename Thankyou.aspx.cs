using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductRegistration
{
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["URL"] != null)
            {
                Label1.Text = "Your download will commence shortly.";
                Response.AddHeader("REFRESH", "1;URL=" + Request.QueryString["URL"]);

            }
        }
    }
}