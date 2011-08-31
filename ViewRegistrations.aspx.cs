using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CSGeneral;

namespace ProductRegistration
{
    public partial class ViewRegistrations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=Registrations.csv");
            Response.Buffer = false;

            Response.ContentType = "text/plain";

            System.Data.DataView dv = (DataView) SqlDataSource1.Select(new DataSourceSelectArguments());
            DataTable Data = dv.ToTable();
            Response.Write(DataTableUtility.DataTableToCSV(Data, 1));
            Response.Flush();                 // send our content to the client browser.
            Response.SuppressContent = true;  // stops .net from writing it's stuff.
        }
    }
}