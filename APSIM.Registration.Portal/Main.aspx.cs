using APSIM.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APSIM.Registration.Portal
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnSubmitClicked(object sender, EventArgs e)
        {
            bool isRegistered;
            try
            {
                string url = $"https://apsimdev.apsim.info/APSIM.Registration.Service/Registration.svc/IsRegistered?email={txtEmail.Text}";
                isRegistered = WebUtilities.CallRESTService<bool>(url);
            }
            catch
            {
                // Swallow exceptions and force user to re-register.
                isRegistered = false;
            }
            
            Response.Redirect(isRegistered ? "Downloads.aspx" : "Register.aspx", false);
        }
    }
}